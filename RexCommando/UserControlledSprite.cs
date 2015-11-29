using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RexCommando
{
    public enum Animation { Run, Stand, Jump, RunShoot, StandShoot, JumpShoot };
    public enum edge { Top, Bottom, Left, Right, None };
    public enum LookingDirection {Left, Right};
   
    class UserControlledSprite: Sprite
    {
        public bool isRunning = false;
        public bool isOnGround = false;
        public bool isShooting = false;
        public bool isClimbing = false;
        public LookingDirection LookingDirection = LookingDirection.Right;
        private bool movedLeft = false;

        Vector2 inputDirection = Vector2.Zero;
        public edge collisionSide = edge.None;

        //Sound effects
        SoundEffect jumpSound;
        SoundEffectInstance jumpSoundIns;
        
        // Jumping state
        public bool isJumping = false;
        private bool wasJumping;
        private float jumpTime;
        Vector2 jumpVelocity;
        float startMove = 1;

        // Constants for controlling vertical movement
        private const float MaxJumpTime = 0.5f;
        private const float JumpLaunchVelocity = -140.0f;
        private const float GravityAcceleration = 3400.0f;
        private const float MaxFallSpeed = 550.0f;
        private const float JumpControlPower = 0.14f;

        public Animation currentAnimation = Animation.Stand;

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, 
            Point currentFrame, Point sheetSize, Vector2 speed, bool hasGravity, Game game)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, hasGravity, game)
        {
            LoadContent();
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, 
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, bool hasGravity, Game game)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame, hasGravity, game)
        {
            LoadContent();
        }
        
        public override void LoadContent()
        {
            jumpSound = game.Content.Load<SoundEffect>(@"Sound/Effects/jump");
            jumpSoundIns = jumpSound.CreateInstance();
            base.LoadContent();
        }

        // Calculate a vector direction based on which key are pressed.
        public override Vector2 direction()
        {
            //If dead dont update
            if (this.isDead)
                return Vector2.Zero;

            inputDirection = Vector2.Zero;
            Keys[] keys = Keyboard.GetState().GetPressedKeys();

            if (Keyboard.GetState().IsKeyDown(Keys.Left) )
            {
                _ExplosionManager.AddPuff(new Vector2(this.collisionRect.Right - 20, 
                                this.collisionRect.Bottom), this.textureImage);

                if (LookingDirection == LookingDirection.Right)
                {
                    movedLeft = true;
                    LookingDirection = LookingDirection.Left;
                }

                if (collisionSide != edge.Right)
                {
                    inputDirection.X -= 1;
                }

                isRunning = true;
                effect = SpriteEffects.FlipHorizontally;
                collisionOffsetX = 52; 

                if (isJumping == false && isRunning == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        setAnimation(Animation.RunShoot);
                    }
                    else
                        setAnimation(Animation.Run);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) || this.startMove > 0)
            {
                _ExplosionManager.AddPuff(new Vector2(this.collisionRect.Left + 20,
                                this.collisionRect.Bottom), this.textureImage);

                if (collisionSide != edge.Left)
                {
                    inputDirection.X += 1;
                }

                isRunning = true;
                LookingDirection = LookingDirection.Right;
                effect = SpriteEffects.None;
                collisionOffsetX = -4;

                if (isJumping == false && isRunning == true)
                {

                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        setAnimation(Animation.RunShoot);
                    }
                    else
                        setAnimation(Animation.Run);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && isJumping == false)
            {
                // If climbing then player can move up
                if (isClimbing == true)
                {
                    inputDirection.Y -= 1;
                }
                // Otherwise the player can jump
                else
                {
                    isJumping = true;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                inputDirection.Y += 1;
            }

            //No keys were pressed
            if (keys.Length == 0)
            {
                isRunning = false;
                if (isJumping == false)
                {
                    setAnimation(Animation.Stand);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (isShooting == true && isJumping == true)
                {
                    setAnimation(Animation.JumpShoot);
                }
                if (isJumping == false && isRunning == false)
                {
                    setAnimation(Animation.StandShoot);
                }
            }

            //base.direction(); 
            // Code to make sure that when a player faces left they are not trapped inside a platform wall by shifting the image 
            // left by collisionOffsetX
            //if (movedLeft)
            //{
            //    movedLeft = false; 
            //    return (inputDirection * speed - new Vector2(collisionOffsetX, 0));
            //}
            //else
                return inputDirection * speed;
        }

        // Update the position of the player by adding calculated vectors based on the keys pressed
        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            this.startMove -= 0.1f;

            //Apply gravity from base class 
            //Calculate and apply the jump velocity
            jumpVelocity.Y = DoJump(jumpVelocity.Y, gameTime);
            //if(!isOnGround)
            float gravityDiv = 2.0f;
            if (!this.isOnGround)
                gravityDiv = 1.0f;

            this.isOnGround = false;
            position.Y += GravityConstant / gravityDiv;
            //isOnGround = false;
            //Apply jump velocity
            position += jumpVelocity;
            //Apply key presses
            position += direction();

            // Do not let the player go ouside the boundaries of the world view. This is different from the playing area (client Bounds)
            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X > Game1.worldWidth - collisionFrameSizeX)
                position.X = Game1.worldWidth - collisionFrameSizeX;
            if (position.Y > Game1.worldHeight - frameSize.Y)
            {
                position.Y = Game1.worldHeight - frameSize.Y;
                isOnGround = true;
            }

            base.Update(gameTime, clientBounds);
        }
         // What the player does when they collide with a ladder.
        public void LadderCollision(Rectangle objectRect)
        {

        }

        // What the player does when they collide with a fixed platform.
        public void PlatformCollisionEdge(Rectangle objectRect, Texture2D platTexture)
        {
            collisionSide = edge.None;

            float diffLeftRight = collisionRect.Left - objectRect.Right;
            float diffRightLeft = collisionRect.Right - objectRect.Left;
            float diffTopBottom = collisionRect.Top - objectRect.Bottom;
            float diffBottomTop = collisionRect.Bottom - objectRect.Top;

            if(Math.Abs(diffLeftRight) < Math.Abs(diffRightLeft) && 
                Math.Abs(diffLeftRight) < Math.Abs(diffTopBottom) && 
                Math.Abs(diffLeftRight) < Math.Abs(diffBottomTop))
            {
                this.position.X += Math.Abs(diffLeftRight);

                //If player is moving add dust
                if (this.inputDirection.X != 0)
                {
                    _ExplosionManager.AddPuff(new Vector2(objectRect.Right,
                                                objectRect.Center.Y), platTexture);
                }
            }
            else if (Math.Abs(diffRightLeft) < Math.Abs(diffLeftRight) &&
                Math.Abs(diffRightLeft) < Math.Abs(diffTopBottom) &&
                Math.Abs(diffRightLeft) < Math.Abs(diffBottomTop))
            {
                this.position.X -= Math.Abs(diffRightLeft);

                //If player is moving add dust
                if (this.inputDirection.X != 0)
                {
                    _ExplosionManager.AddPuff(new Vector2(objectRect.Left,
                                                objectRect.Center.Y), platTexture);
                }
            }
            else if (Math.Abs(diffTopBottom) < Math.Abs(diffRightLeft) &&
                Math.Abs(diffTopBottom) < Math.Abs(diffLeftRight) &&
                Math.Abs(diffTopBottom) < Math.Abs(diffBottomTop))
            {
                this.position.Y += Math.Abs(diffTopBottom);

                //If player is moving add dust
                if (this.inputDirection.X != 0)
                {
                    _ExplosionManager.AddPuff(new Vector2(objectRect.Center.X,
                                                objectRect.Bottom), platTexture);
                }
            }
            else if (Math.Abs(diffBottomTop) < Math.Abs(diffRightLeft) &&
                Math.Abs(diffBottomTop) < Math.Abs(diffTopBottom) &&
                Math.Abs(diffBottomTop) < Math.Abs(diffLeftRight))
            {
                this.position.Y -= Math.Abs(diffBottomTop);
                isOnGround = true;

                //If player is moving add dust
                if (this.inputDirection.X != 0)
                {
                    _ExplosionManager.AddPuff(new Vector2(objectRect.Center.X,
                                                objectRect.Top), platTexture);
                }
            }
        }
        //public void PlatformCollisionEdge(Rectangle objectRect)
        //{
        //    //Top Collision
        //    //The bottom (y) of the player is between the top and bottom of the item being collided with
        //    if (collisionRect.Y + collisionRect.Height > objectRect.Y && collisionRect.Y + collisionRect.Height < objectRect.Y + objectRect.Height)
        //    {
        //        collisionSide = edge.Top; 
        //        position = new Vector2(Position.X, objectRect.Top - frameSize.Y);
        //        isOnGround = true;
        //    }
        //    //Bottom Collision
        //    // the top (y) of the player is between the top and bottom of the item being collided with
        //    else if (collisionRect.Y < objectRect.Y + objectRect.Height && collisionRect.Y + collisionRect.Height > objectRect.Y + objectRect.Height)
        //    {
        //        collisionSide = edge.Bottom;
        //        if (isJumping)
        //        {
        //            position = new Vector2(Position.X, objectRect.Y + objectRect.Height);
        //        }
        //        else
        //        {
        //            if (collisionRect.X < objectRect.X + objectRect.Width && collisionRect.X + collisionRect.Width > objectRect.X + objectRect.Width)
        //            {
        //                collisionSide = edge.Right;
        //                //position = new Vector2(objectRect.X + objectRect.Width - collisionOffsetX, position.Y);

        //            }

        //            else if (collisionRect.X + collisionRect.Width > objectRect.X && collisionRect.X < objectRect.X)
        //            {
        //                collisionSide = edge.Left;
        //                //position = new Vector2(objectRect.X - collisionRect.Width, position.Y);
        //            }
        //        }
        //    }

        //    else if (collisionRect.X < objectRect.X + objectRect.Width && collisionRect.X + collisionRect.Width > objectRect.X + objectRect.Width)
        //    {
        //        collisionSide = edge.Right;
        //        position = new Vector2(objectRect.X + objectRect.Width - collisionOffsetX, position.Y);

        //    }

        //    else if (collisionRect.X + collisionRect.Width > objectRect.X && collisionRect.X < objectRect.X)
        //    {
        //        collisionSide = edge.Left;
        //        position = new Vector2(objectRect.X - collisionRect.Width, position.Y);
        //    }
              
        //    else
        //    {
        //        collisionSide = edge.None;
        //    }
        //}

        private float DoJump(float velocityY, GameTime gameTime)
        {
            // If the player wants to jump
            if (isJumping)
            {
                // Begin or continue a jump
                if ((!wasJumping) || jumpTime > 0.0f)
                {
                    if (jumpTime == 0.0f)
                    {
                        isOnGround = false;
                        jumpSoundIns.Play();
                        setAnimation(Animation.Jump);
                        // Change the size of the collision rectangle size since jumping image is bigger
                        collisionFrameSizeY = 10;
                        collisionOffsetY = 10;
                    }
                    jumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                // If we are in the ascent of the jump
                if (0.0f < jumpTime && jumpTime <= MaxJumpTime)
                {
                    // Fully override the vertical velocity with a power curve that gives players more control over the top of the jump
                    velocityY = JumpLaunchVelocity * (1.0f - (float)Math.Pow(jumpTime / MaxJumpTime, JumpControlPower));
                }
                else
                {
                    // Reached the apex of the jump
                    jumpTime = 0.0f;
                    velocityY = 0;
                }

                if (isOnGround == true)
                {
                    isJumping = false;
                    setAnimation(Animation.Stand);
                    // Set the size of the collision rectangle back to standing image
                    collisionFrameSizeY = 40;
                    collisionOffsetY = 40;
                    velocityY = 0;
                }
            }
            else
            {
                // Continues not jumping or cancels a jump in progress
                jumpTime = 0.0f;
                velocityY = 0;
            }
            wasJumping = isJumping;

            return velocityY;
        }

        // Set the animation to play based on the state of the player
        public void setAnimation(Animation animation)
        {
            if (animation == Animation.Run)
            {
                currentFrame.Y = 0;
                sheetSize.X = 4; 
            }
            if (animation == Animation.Stand)
            {
                currentFrame.Y = 1;
                sheetSize.X = 4; 
            }
            if (animation == Animation.Jump)
            {
                currentFrame.Y = 2;
                sheetSize.X = 2;
            }
            if (animation == Animation.RunShoot)
            {
                currentFrame.Y = 3;
                sheetSize.X = 4; 
            }
            if (animation == Animation.StandShoot)
            {
                currentFrame.Y = 4;
                sheetSize.X = 2; 
            }
            if (animation == Animation.JumpShoot)
            {
                currentFrame.Y = 5;
                sheetSize.X = 1;
            }
        }
    }
}

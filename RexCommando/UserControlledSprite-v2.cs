using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace MegaMan
{
    class UserControlledSprite: Sprite
    {
        private bool isOnGround= false;
        Game game;
        SoundEffect jumpSound;
        SoundEffectInstance jumpSoundIns;
        
        // Jumping state
        private bool isJumping = false;
        private bool wasJumping;
        private float jumpTime;
        Vector2 jumpVelocity;


        // Constants for controlling vertical movement
        private const float MaxJumpTime = 0.5f;
        private const float JumpLaunchVelocity = -120.0f;
        private const float GravityAcceleration = 3400.0f;
        private const float MaxFallSpeed = 550.0f;
        private const float JumpControlPower = 0.14f; 


        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, 
            Point currentFrame, Point sheetSize, Vector2 speed, bool hasGravity, Game userGame)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, hasGravity)
        {
            game = userGame;
            LoadContent();
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, 
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, bool hasGravity, Game userGame)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed,
            millisecondsPerFrame, hasGravity)
        {
            LoadContent();
        }
        
        public void LoadContent()
        {
            jumpSound =  game.Content.Load<SoundEffect>(@"Sound/Effects/jump");
            jumpSoundIns = jumpSound.CreateInstance();
        }

        public override Vector2 direction()
        {
            Vector2 inputDirection = Vector2.Zero;
            Keys[] keys = Keyboard.GetState().GetPressedKeys();

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                inputDirection.X -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                inputDirection.X += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && isJumping == false)
            {
                isJumping = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                inputDirection.Y += 1;
            }
            if (keys.Length == 0)
            { 

            }   
            //base.direction(); 
            return inputDirection * speed;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            //Apply gravity from base class 
            base.direction();
            //Calculate and jump velocity
            jumpVelocity.Y = DoJump(jumpVelocity.Y, gameTime);
            //Apply jump velocity
            position += jumpVelocity;
            //Apply key presses
            position += direction();

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X > clientBounds.Width - frameSize.X)
                position.X = clientBounds.Width - frameSize.X;
            if (position.Y > clientBounds.Height - frameSize.Y)
            {
                position.Y = clientBounds.Height - frameSize.Y;
                isOnGround = true;
            }

            base.Update(gameTime, clientBounds);
        }

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
                    //SetAnimation(Animation.jump);
                }
                if (isOnGround == true)
                    isJumping = false;
            }
            else
            {
                // Continues not jumping or cancels a jump in progress
                jumpTime = 0.0f;
            }
            wasJumping = isJumping;

            return velocityY;
        }
    }
}

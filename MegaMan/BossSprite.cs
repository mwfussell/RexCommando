using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MegaMan
{
    enum BossType { Jumping, Flying, Running };
    enum ShootType { Bullet, Seahorse }

    // The default Boss jumps around and shoots bullets
    class BossSprite : Sprite
    {
        //Boss Health 
        public int health = 10;
        public BossType bossType;
        public ShootType shootType;

        //Player Tracking
        UserControlledSprite Player;
        Vector2 originalSpeed;
        float runWait = 0.0f;
        float runWaitMax = 2.0f;
        bool playerDetected = false;

        List<Sprite> Enemies;

        //Bullets
        List<Sprite> Bullets;
        LookingDirection lookingDirection = LookingDirection.Left;
        int bulletsperRound = 2;
        int bulletSpeed = 10;
        int bulletCount = 2;
        float bulletWait = 0.0f;
        float bulletWaitMax = 0.2f;
        float bulletRepeatWait = 0.0f;
        float bulletRepeatWaitMax = 2.0f;
        public Texture2D bulletTexture;

        // Jumping state
        public bool isJumping = false;
        private bool wasJumping;
        private float jumpTime;
        Vector2 jumpVelocity;
        public bool isOnGround = true;

        // Constants for controlling vertical movement of the Jumping Boss 
        private const float MaxJumpTime = 0.5f;
        private const float JumpLaunchVelocity = -120.0f;
        private const float GravityAcceleration = 2400.0f;
        private const float MaxFallSpeed = 550.0f;
        private const float JumpControlPower = 0.19f;

        // Value for Flying Boss
        float flyingWait = 0.0f;
        int flyingWaitMax = 1000;

        int BlockSize = 72;

        public BossSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, bool hasGravity, Game game,
            UserControlledSprite player, List<Sprite> bullets, int blockSize, int startHealth, int bulletsPerRound, List<Sprite> enemies)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, hasGravity, game)
        {
            Player = player;
            originalSpeed = speed;
            Bullets = bullets;
            BlockSize = blockSize;
            health = startHealth;
            bulletsperRound = bulletsPerRound;
            bulletTexture = game.Content.Load<Texture2D>(@"Sprites/Bullets/BulletWhite");
            Enemies = enemies;
        }
        public BossSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, bool hasGravity, Game game)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame, hasGravity, game)
        {
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            switch (bossType)
            {
                case BossType.Jumping:
                    //Apply gravity from base class 
                    base.direction();
                    position += speed;
                    //Constantly Jump. Calculate and apply the jump velocity if on the ground.
                    if (isOnGround == true)
                    {
                        isJumping = true;
                    }
                    jumpVelocity.Y = DoJump(jumpVelocity.Y, gameTime);
                    //Apply jump velocity
                    position += jumpVelocity;

                    // Always run towards the player when detected.
                    runWait += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (Math.Abs(Position.X - Player.Position.X) < frameSize.X * 3)
                    {
                        playerDetected = true;
                    }

                    if (speed.X > 0)
                    {
                        effect = SpriteEffects.None;
                        lookingDirection = LookingDirection.Right;
                    }

                    else
                    {
                        effect = SpriteEffects.FlipHorizontally;
                        lookingDirection = LookingDirection.Left;
                    }

                    if (playerDetected && runWait > runWaitMax)
                    {
                        if (Math.Sign(Position.X - Player.Position.X) == -1)
                        {
                            speed = new Vector2(5, 0);
                        }
                        else
                        {
                            speed = new Vector2(-5, 0);
                        }
                        runWait = 0;
                    }
                    break;

                case BossType.Flying:
                    // Wait a random period of time and then change direction in the Y axis
                    flyingWait += (float)gameTime.ElapsedGameTime.Milliseconds;
                    if (flyingWait > flyingWaitMax)
                    {
                        flyingWaitMax = ((Game1)game).rnd.Next(200, 2000);
                        speed *= -1;
                        flyingWait = 0;
                    }

                    position += speed;
                    break;

                case BossType.Running:
                    position += speed;
                    runWait += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (Math.Abs(Position.X - Player.Position.X) < frameSize.X * 5)
                    {
                        playerDetected = true;
                    }

                    if (speed.X > 0)
                        effect = SpriteEffects.None;
                    else
                        effect = SpriteEffects.FlipHorizontally;

                    if (playerDetected && runWait > runWaitMax)
                    {
                        if (Math.Sign(Position.X - Player.Position.X) == -1)
                        {
                            speed = new Vector2(5, 0);
                        }
                        else
                        {
                            speed = new Vector2(-5, 0);
                        }
                        runWait = 0;
                    }

                    break;

                default:
                    break;
            }

            // Do not let the Boss go ouside the boundaries of the world view. This is different from the playing area (client Bounds)
            // Note: the Boss world is smaller that full world by half minus a block size.
            if (position.X < 0)
                position.X = 0;
            if (position.Y < Game1.worldHeight - collisionFrameSizeY - 9 * BlockSize)
            {
                position.Y = Game1.worldHeight - collisionFrameSizeY - 9 * BlockSize;
                // If this is a flying boss and hit the top edge, change direction
                if (bossType == BossType.Flying)
                    speed.Y *= -1;
            }

            if (position.X > Game1.worldWidth / 2 - collisionFrameSizeX - BlockSize)
                position.X = Game1.worldWidth / 2 - collisionFrameSizeX - BlockSize;
            if (position.Y > Game1.worldHeight - frameSize.Y - BlockSize)
            {
                position.Y = Game1.worldHeight - frameSize.Y - BlockSize;
                isOnGround = true;
                // If this is a flying boss and hit the bottom edge, change direction
                if (bossType == BossType.Flying)
                    speed.Y *= -1;
            }

            // Fire bullets in batches based on the wait time interval
            bulletRepeatWait += (float)gameTime.ElapsedGameTime.TotalSeconds;
            bulletWait += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (bulletRepeatWait > bulletRepeatWaitMax)
            {
                if (lookingDirection == LookingDirection.Left && bulletWait > bulletWaitMax)
                {
                    switch (shootType)
                    {
                        case ShootType.Bullet:
                            bulletSpeed = -10;
                            Bullets.Add(new AutomatedSprite(bulletTexture,
                                        new Vector2(this.Position.X - 20, this.Position.Y + 80),
                                        new Point(24, 20), 0, new Point(0, 0), new Point(1, 1), new Vector2(bulletSpeed, 0), false, game));
                            break;
                        case ShootType.Seahorse:
                            for (int yPos = Game1.worldHeight - BlockSize * 3; yPos > Game1.worldHeight - BlockSize * 6; yPos = yPos - 144)
                            {
                                Sprite seahorse = new AutomatedSprite(game.Content.Load<Texture2D>(@"Sprites/Enemies/WaterSeaHorse"),
                                                    new Vector2(BlockSize * 14, yPos),
                                                    new Point(64, 144), 0, new Point(0, 0), new Point(1, 1), new Vector2(-4, 0), false, game);
                                seahorse.effect = SpriteEffects.FlipHorizontally;
                                Enemies.Add(seahorse);
                            }
                            for (int yPos = Game1.worldHeight - BlockSize * 3; yPos > Game1.worldHeight - BlockSize * 6; yPos = yPos - 144)
                            {
                                Sprite seahorse = new AutomatedSprite(game.Content.Load<Texture2D>(@"Sprites/Enemies/WaterSeaHorse"),
                                                    new Vector2(BlockSize * 13, yPos),
                                                    new Point(64, 144), 0, new Point(0, 0), new Point(1, 1), new Vector2(-4, 0), false, game);
                                seahorse.effect = SpriteEffects.FlipHorizontally;
                                Enemies.Add(seahorse);
                            }

                            break;
                    }

                    bulletWait = 0;
                    bulletCount--;
                }

                else if (lookingDirection == LookingDirection.Right && bulletWait > bulletWaitMax)
                {
                    bulletSpeed = 10;
                    Bullets.Add(new AutomatedSprite(bulletTexture,
                                new Vector2(this.Position.X + 100, this.Position.Y + 80),
                                new Point(24, 20), 0, new Point(0, 0), new Point(1, 1), new Vector2(bulletSpeed, 0), false, game));
                    bulletWait = 0;
                    bulletCount--;
                }

                if (bulletCount < 1)
                {
                    bulletRepeatWait = 0;
                    bulletCount = bulletsperRound;
                }
            }

            base.Update(gameTime, clientBounds);
        }

        private float DoJump(float velocityY, GameTime gameTime)
        {
            // If the Boss wants to jump
            if (isJumping)
            {
                // Begin or continue a jump
                if ((!wasJumping) || jumpTime > 0.0f)
                {
                    if (jumpTime == 0.0f)
                    {
                        isOnGround = false;
                        //jumpSoundIns.Play();
                        //setAnimation(Animation.Jump);
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
                    //setAnimation(Animation.Stand);
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
    }
}

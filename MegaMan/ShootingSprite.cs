using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MegaMan
{
    class ShootingSprite : Sprite
    {
        const int bulletsperRound = 5;
        List<Sprite> Bullets;
        LookingDirection lookingDirection = LookingDirection.Left;
        int bulletMaxSpeed = 15;
        int bulletMinSpeed = 8;
        int bulletSpeed = 10;
        int bulletCount = bulletsperRound;
        float bulletWait = 0.0f;
        float bulletWaitMax = 0.2f;
        float bulletRepeatWait = 0.0f;
        float bulletRepeatWaitMax = 3.0f;
        int bulletSpawnMinMilliSeconds = 1000;
        int bulletSpawnMaxMilliSeconds = 3000;
        
        public ShootingSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
                              Point currentFrame, Point sheetSize, Vector2 speed, bool hasGravity, Game game,
                              List<Sprite> bullets, LookingDirection lookimgdirection)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, hasGravity, game)
        {
            collisionOffset = 20;
            Bullets = bullets;
            lookingDirection = lookimgdirection;
            bulletRepeatWaitMax = ((float)((Game1)game).rnd.Next(bulletSpawnMinMilliSeconds, bulletSpawnMaxMilliSeconds)) / 1000;
        }
        public ShootingSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
                              Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, bool hasGravity, Game game,
                              List<Sprite> bullets, LookingDirection lookimgdirection)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame, hasGravity, game)
        {
            collisionOffset = 20;
            Bullets = bullets;
            lookingDirection = lookimgdirection;
            bulletRepeatWaitMax = ((float)((Game1)game).rnd.Next(bulletSpawnMinMilliSeconds, bulletSpawnMaxMilliSeconds)) / 1000;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            bulletRepeatWait += (float)gameTime.ElapsedGameTime.TotalSeconds; 
            bulletWait += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (lookingDirection == LookingDirection.Right)
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effect = SpriteEffects.None;
            }
            if (bulletRepeatWait > bulletRepeatWaitMax)
            {
                if (lookingDirection == LookingDirection.Left && bulletWait > bulletWaitMax)
                {
                    //bulletSpeed  = - ((Game1)game).rnd.Next(bulletMinSpeed, bulletMaxSpeed);
                    bulletSpeed = -10;
                    Bullets.Add(new AutomatedSprite(game.Content.Load<Texture2D>(@"Sprites/Bullets/TurretBullet"),
                                new Vector2(this.Position.X - 20, this.Position.Y + 8),
                                new Point(24, 20), 0, new Point(0, 0), new Point(1, 1), new Vector2(bulletSpeed, 0), false, game));
                    bulletWait = 0;
                    bulletCount--;
                }

                else if (lookingDirection == LookingDirection.Right && bulletWait > bulletWaitMax)
                {
                    //bulletSpeed = ((Game1)game).rnd.Next(bulletMinSpeed, bulletMaxSpeed);
                    bulletSpeed = 10;
                    Bullets.Add(new AutomatedSprite(game.Content.Load<Texture2D>(@"Sprites/Bullets/TurretBullet"),
                                new Vector2(this.Position.X + 80, this.Position.Y + 8),
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
    }
}

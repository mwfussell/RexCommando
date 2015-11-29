using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RexCommando
{
    class RunningSprite : Sprite
    {
        UserControlledSprite Player;
        Vector2 originalSpeed;
        float runWait = 0.0f;
        float runWaitMax = 2.0f;
        bool playerDetected = false;

        public RunningSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, bool hasGravity, Game game, UserControlledSprite player)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, hasGravity, game)
        {
            Player = player;
            originalSpeed = speed;
            
        }
        public RunningSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, bool hasGravity, Game game)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame, hasGravity, game)
        {
        }

        public override Vector2 direction()
        {
            base.direction();
            return speed;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position += this.direction();
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

            base.Update(gameTime, clientBounds);
        }
    }
}

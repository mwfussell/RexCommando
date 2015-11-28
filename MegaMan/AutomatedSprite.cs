using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MegaMan
{
    // This sprite moves a certain speed until it hit a platform and then changes direction
    class AutomatedSprite: Sprite
    {
        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, 
            Point currentFrame, Point sheetSize, Vector2 speed, bool hasGravity, Game game)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, hasGravity, game)
        { 
        }
        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, 
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

            if (speed.X > 0)
                effect = SpriteEffects.FlipHorizontally;
            else
                effect = SpriteEffects.None;
            base.Update(gameTime, clientBounds);
        }   
    }
}

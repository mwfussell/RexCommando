using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RexCommando
{
    // This sprite moves a certain for a *fixed* travel distance before it changes direction. 
    // It still changesdirection if it hits platform
    class TravelSprite : Sprite
    {
        public TravelSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, bool hasGravity, Game game, Vector2 travelDistance)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, hasGravity, game)
        {
            distance = travelDistance;
        }
        public TravelSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, bool hasGravity, Game game, Vector2 travelDistance)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame, hasGravity,
                   game)
        {
            distance = travelDistance;
        }

    }
}

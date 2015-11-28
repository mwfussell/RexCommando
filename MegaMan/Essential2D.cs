using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MegaMan
{
    public static class Essential2D
    {
        public static Texture2D lineTexture { get; set; }

        public static void Drawline(Vector2 start, Vector2 end, SpriteBatch spritebatch)
        {
            Vector2 vectordiff = end - start;
            int length = (int)vectordiff.Length();
            vectordiff.Normalize();
            for (int i =0; i< length; i++)
            {
                spritebatch.Draw(lineTexture, start + i * vectordiff, Color.WhiteSmoke);
            }
        }
    }
}

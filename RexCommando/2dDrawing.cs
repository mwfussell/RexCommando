using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RexCommando
{
    class TwodDrawing
    {
        public static void DrawLine(Vector2 start, Vector2 end, SpriteBatch spritebatch, Texture2D texture)
        {
            Vector2 vectorDif = end - start;
            int length = (int)vectorDif.Length();
            vectorDif.Normalize();
            for (int i = 0; i <= length; i++)
            {
                spritebatch.Draw(texture, start + i * vectorDif, Color.Tomato);
            }
        }
        public static void DrawCircle(Vector2 center, int radius, SpriteBatch spritebatch, Texture2D texture)
        {
            for (double i = 0; i < Math.PI * 2; i = i + 0.01)
            {
                Vector2 pointtodraw = new Vector2((float)(Math.Cos(i) * radius), (float)(Math.Sin(i) * radius))+ center;
                spritebatch.Draw(texture, pointtodraw, Color.Tomato);
            }
        }

    }
}

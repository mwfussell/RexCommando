using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RexCommando
{
    public static class _ExplosionManager
    {
        public static List<Explosion> explosions;

        public static void AddBasic(Vector2 Position, Texture2D Texture)
        {
            Explosion exp = new Explosion(Position, Texture);
            exp.InitialiseBasic();
            explosions.Add(exp);
        }
        public static void AddQuick(Vector2 Position, Texture2D Texture)
        {
            Explosion exp = new Explosion(Position, Texture);
            exp.InitialiseQuick();
            explosions.Add(exp);
        }
        public static void AddPop(Vector2 Position, Texture2D Texture)
        {
            Explosion exp = new Explosion(Position, Texture);
            exp.InitialisePop();
            explosions.Add(exp);
        }
        public static void AddPuff(Vector2 Position, Texture2D Texture)
        {
            Explosion exp = new Explosion(Position, Texture);
            exp.InitialisePuff();
            explosions.Add(exp);
        }
        public static void AddHuge(Vector2 Position, Texture2D Texture)
        {
            Explosion exp = new Explosion(Position, Texture);
            exp.InitialiseHuge();
            explosions.Add(exp);
        }
        public static void Initialise()
        {
            explosions = new List<Explosion>();
        }
        public static void Update()
        {
            for(int i = 0; i < explosions.Count; ++i)
            {
                explosions[i].Update();

                if(explosions[i].IsDead())
                {
                    explosions.RemoveAt(i);
                    --i;
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < explosions.Count; ++i)
            {
                explosions[i].Draw(spriteBatch);
            }
        }
    }
}

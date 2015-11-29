namespace RexCommando
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public struct BackgroundSprite
    {
        public Texture2D Texture;
        
        public Vector2 Position;

        public void Draw(SpriteBatch spriteBatch)
        {
            if(Texture != null)
                spriteBatch.Draw(Texture, Position, null, Color.FromNonPremultiplied(200, 200, 200, 255), 
                                    0, Vector2.Zero, 1, SpriteEffects.None, 0.5f );
        }
    }
}

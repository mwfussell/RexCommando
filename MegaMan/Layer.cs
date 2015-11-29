namespace RexCommando
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    
    public class Layer
    {
        private readonly Camera _camera;
        
        public Layer(Camera camera)
        {
            _camera = camera;
            Parallax = Vector2.One;
            Sprites = new List<BackgroundSprite>();
        }

        public Vector2 Parallax { get; set; }

        public List<BackgroundSprite> Sprites { get; private set; }

        public void Draw(SpriteBatch spriteBatch)
	    {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(Parallax));
    	    
            foreach(BackgroundSprite sprite in Sprites)
		        sprite.Draw(spriteBatch);
            
            spriteBatch.End();
	    }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, _camera.GetViewMatrix(Parallax));
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return Vector2.Transform(screenPosition, Matrix.Invert(_camera.GetViewMatrix(Parallax)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RexCommando
{
    abstract class Sprite
    {
        public Game game;
        public Texture2D textureImage;
        public Point frameSize;
        public Point currentFrame;
        public Point sheetSize;
        public SpriteEffects effect = SpriteEffects.None;

        // Collision Rectangle variables
        public bool drawCollisionRect = false;
        public bool drawFrameRect = false;

        Texture2D lineTexture;
        public int collisionFrameSizeX;
        public int collisionFrameSizeY;
        public int collisionOffsetX;
        public int collisionOffsetY;
        protected Rectangle collisionRectInternal;

        int timeSinceLastFrame = 0;
        int millisecondPerFrame;
        const int defaultMillisecondsPerFrame = 150;
        public Vector2 speed;
        public Vector2 position;
        public Vector2 origin;
        public Vector2 distance = Vector2.Zero;
        public Color color;
        public bool isDead;

        protected bool HasGravity = false;
        protected float GravityConstant = 10.0f;
        
        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, bool hasGravity, Game game)
            : this(textureImage, position, frameSize, collisionOffset,
            currentFrame, sheetSize, speed, defaultMillisecondsPerFrame, hasGravity, game)
        {
            this.color = Color.White;
            this.isDead = false;
        }
        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, bool hasGravity, Game game)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.origin = position;
            this.frameSize = frameSize;
            this.collisionFrameSizeX = collisionOffset;
            this.collisionFrameSizeY = collisionOffset;
            this.collisionOffsetX = collisionOffset;
            this.collisionOffsetY = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondPerFrame = millisecondsPerFrame;
            this.HasGravity = hasGravity;
            this.game = game;
            this.color = Color.White;
            this.isDead = false;

            LoadContent();
        }

        // Get current position of the sprite
        public Vector2 Position
        {
            get { return position; }
            set { position = Position; }
        }

        // Set a distance for the sprite that it can travel
        public Vector2 Distance
        {
            get { return distance; }
            set { distance = Distance; }
        }

        // Get the direction of the sprite
        public virtual Vector2 direction()
        {
            //If dead dont update
            if (this.isDead)
                return Vector2.Zero;

            if (HasGravity == true)
                position.Y += GravityConstant;
            return position;
        }

        // Change the speed  of the sprite
        public Vector2 Speed
        {
            get { return speed; }
            set { speed = Speed; }
        }

        //Turn on drawing the collision rectangle for this sprite to help with debugging collision issues
        //public bool DrawCollisionRect
        //{
        //    get { return drawCollisionRect; }
        //    set { drawCollisionRect = DrawCollisionRect;}
        //}

        public virtual void LoadContent()
        {
            lineTexture = game.Content.Load<Texture2D>(@"Backgrounds/Dot");
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            if (this.isDead)
                return;

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame = 0;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    //++currentFrame.Y;
                   // if (currentFrame.Y >= sheetSize.Y)
                       // currentFrame.Y = 0;
                }
            }
            if (distance != Vector2.Zero)
            { 
                if (Math.Abs(position.X - origin.X) > distance.X)
                {
                    speed = speed * -1;
                }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (this.isDead)
                return;

            spriteBatch.Draw(textureImage,
                            position,
                            new Rectangle(currentFrame.X * frameSize.X,
                                currentFrame.Y * frameSize.Y,
                                frameSize.X, frameSize.Y),
                                this.color, 0, Vector2.Zero,
                                1f, effect, 0);

            if (drawCollisionRect == true)
            {
                // Draw the Collision Rect for the player to help with debugging collisions
                Rectangle rect = collisionRect;

                TwodDrawing.DrawLine(new Vector2(rect.X, rect.Y),
                                     new Vector2(rect.X, rect.Bottom), spriteBatch, lineTexture);
                TwodDrawing.DrawLine(new Vector2(rect.X, rect.Y),
                                     new Vector2(rect.Right, rect.Y), spriteBatch, lineTexture);
                TwodDrawing.DrawLine(new Vector2(rect.Right, rect.Y),
                                     new Vector2(rect.Right, rect.Bottom), spriteBatch, lineTexture);
                TwodDrawing.DrawLine(new Vector2(rect.X, rect.Bottom),
                                     new Vector2(rect.Right, rect.Bottom), spriteBatch, lineTexture);

            }
            if (drawFrameRect == true)
            {
                // Draw the Collision Rect for the player to help with debugging collisions
                Rectangle rect = new Rectangle((int)position.X, (int)position.Y, frameSize.X, frameSize.Y);

                TwodDrawing.DrawLine(new Vector2(rect.X, rect.Y),
                                     new Vector2(rect.X, rect.Bottom), spriteBatch, lineTexture);
                TwodDrawing.DrawLine(new Vector2(rect.X, rect.Y),
                                     new Vector2(rect.Right, rect.Y), spriteBatch, lineTexture);
                TwodDrawing.DrawLine(new Vector2(rect.Right, rect.Y),
                                     new Vector2(rect.Right, rect.Bottom), spriteBatch, lineTexture);
                TwodDrawing.DrawLine(new Vector2(rect.X, rect.Bottom),
                                     new Vector2(rect.Right, rect.Bottom), spriteBatch, lineTexture);
            }
        }

        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                    (int)position.X + collisionOffsetX,
                    (int)position.Y + collisionOffsetY,
                    frameSize.X - (collisionFrameSizeX),
                    frameSize.Y - (collisionFrameSizeY));
            }
            set
            {
                collisionRectInternal = collisionRect;
            }
        }
            
        public Boolean onScreen(Rectangle screen)
        {
            if(position.X > screen.Width || 
                position.Y > screen.Height ||
                position.X + frameSize.X < screen.X ||
                position.Y + frameSize.Y < screen.Y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

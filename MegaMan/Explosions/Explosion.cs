using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MegaMan
{
    public class Particle
    {
        //Variables
        private Vector2 position;
        private Texture2D texture;
        private Vector2 direction;
        private float speed;
        private float friction;
        private float rotation;
        private byte opacity;
        private Rectangle cutSize;
        private bool hasGravity;

        private int size = 20;

        //Costructs
        public Particle()
        {
            this.Initialise();
        }
        public Particle(Vector2 Position, Texture2D Texture, Vector2 Direction,
                        float Speed, int Size, bool HasGravity, Random Rand)
        {
            this.Initialise();

            this.position = Position;
            this.texture = Texture;
            this.direction = Direction;
            this.speed = Speed;
            this.size = Size;
            this.hasGravity = HasGravity;

            this.rotation = (float)(Rand.NextDouble() * Math.PI * 2.0f);
            //Randomly select parts of the image
            this.cutSize.Width = size;
            this.cutSize.Height = size;
            this.cutSize.X = Rand.Next(0, this.texture.Width - size);
            this.cutSize.Y = Rand.Next(0, this.texture.Height - size);
        }

        //Methods
        private void Initialise()
        {
            //Set basic values
            this.position = Vector2.Zero;
            this.texture = null;
            this.direction = Vector2.One;
            this.speed = 5.0f;
            this.friction = 0.9f;
            this.hasGravity = true;
            this.rotation = 0.0f;
            this.opacity = 255;

            this.cutSize = new Rectangle(0, 0, size, size);
        }
        public void Update()
        {
            //move particle
            this.position += this.direction * this.speed;

            //Add fake gravity based on speed of particle - inversely proportional
            if(this.hasGravity)
                this.position.Y += 5.0f * (1.0f / this.speed);

            //make particles fade
            this.opacity = (byte)Math.Min(255, Math.Max(0, 255 * this.speed));

            //Slow down particle
            this.speed *= this.friction;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, this.cutSize, 
                            Color.FromNonPremultiplied(255, 255, 255, this.opacity), this.rotation,
                            Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
        }
        public bool IsDead() { return this.speed < 0.01f; }

        //Get/Set
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public float PosX
        {
            get { return this.position.X; }
            set { this.position.X = value; }
        }
        public float PosY
        {
            get { return this.position.Y; }
            set { this.position.Y = value; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

    }

    public class Explosion
    {
        //Variables
        private List<Particle> particles;
        private Vector2 position;
        private Texture2D texture;
        private Random random = new Random();

        //Constructs
        public Explosion()
        {
            this.particles = new List<Particle>();
            this.position = Vector2.Zero;
            this.texture = null;

            //this.InitialiseBasic();
        }
        public Explosion(Vector2 Position, Texture2D Texture)
        {
            this.particles = new List<Particle>();
            this.position = Position;
            this.texture = Texture;

            //this.InitialiseBasic();
        }

        //Methods
        public void InitialiseBasic()
        {
            int partCount = random.Next(50, 100);
            for(int i = 0; i < partCount; ++i)
            {
                float randAngleRad = (float)(this.random.Next(0, 360) * Math.PI / 180.0f);
                Vector2 randDirection = Vector2.Zero;
                randDirection.X = (float)Math.Cos(randAngleRad);
                randDirection.Y = (float)Math.Sin(randAngleRad);

                this.particles.Add(new Particle(this.position, this.texture,
                                    randDirection, this.random.Next(0, 20), 20, true, this.random));
            }
        }
        public void InitialiseQuick()
        {
            int partCount = random.Next(0, 2);
            for (int i = 0; i < partCount; ++i)
            {
                float randAngleRad = (float)(this.random.Next(0, 360) * Math.PI / 180.0f);
                Vector2 randDirection = Vector2.Zero;
                randDirection.X = (float)Math.Cos(randAngleRad);
                randDirection.Y = (float)Math.Sin(randAngleRad);

                this.particles.Add(new Particle(this.position, this.texture,
                                    randDirection, this.random.Next(0, 3), 8, false, this.random));
            }
        }
        public void InitialisePop()
        {
            int partCount = random.Next(15, 30);
            for (int i = 0; i < partCount; ++i)
            {
                float randAngleRad = (float)(this.random.Next(0, 360) * Math.PI / 180.0f);
                Vector2 randDirection = Vector2.Zero;
                randDirection.X = (float)Math.Cos(randAngleRad);
                randDirection.Y = (float)Math.Sin(randAngleRad);

                this.particles.Add(new Particle(this.position, this.texture,
                                    randDirection, this.random.Next(0, 3), 8, false, this.random));
            }
        }
        public void InitialisePuff()
        {
            int partCount = random.Next(0, 6);
            for (int i = 0; i < partCount; ++i)
            {
                float randAngleRad = (float)(this.random.Next(180, 360) * Math.PI / 180.0f);
                Vector2 randDirection = Vector2.Zero;
                randDirection.X = (float)Math.Cos(randAngleRad);
                randDirection.Y = (float)Math.Sin(randAngleRad);

                this.particles.Add(new Particle(this.position, this.texture,
                                    randDirection, this.random.Next(0, 3), 8, false, this.random));
            }
        }
        public void InitialiseHuge()
        {
            int partCount = random.Next(250, 400);
            for (int i = 0; i < partCount; ++i)
            {
                float randAngleRad = (float)(this.random.Next(0, 360) * Math.PI / 180.0f);
                Vector2 randDirection = Vector2.Zero;
                randDirection.X = (float)Math.Cos(randAngleRad);
                randDirection.Y = (float)Math.Sin(randAngleRad);

                this.particles.Add(new Particle(this.position, this.texture,
                                    randDirection, this.random.Next(0, 50), 
                                    this.random.Next(10, 25), true, this.random));
            }
        }
        public void Update()
        {
            for (int i = 0; i < this.particles.Count; ++i)
            {
                this.particles[i].Update();

                if (this.particles[i].IsDead())
                {
                    this.particles.RemoveAt(i);
                    --i;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < this.particles.Count; ++i)
            {
                this.particles[i].Draw(spriteBatch);
            }
        }
        public bool IsDead() { return this.particles.Count == 0; }

        //Get/Set
    }
}

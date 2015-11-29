namespace RexCommando
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    using System;

    public class Camera
    {
        private readonly Viewport _viewport;
        private Vector2 _position;
        private Vector2 _positionTarget;
        private Rectangle? _limits;

        private Vector2 shakeValue;

        //Camera Shake (set to base values)
        int shakeRange = 5;
        float shakeCamTimer = 0.0f;
        float shakeDecline = 1.0f;
        Random random = new Random();

        //increase this value to slow the camera following,
        // decrease to a minimum of 1 to make the camera follow faster
        float cameraFlow = 25.0f;

        public Camera(Viewport viewport)
        {
            _viewport = viewport;
            Origin = new Vector2(_viewport.Width / 2.0f, _viewport.Height / 2.0f);
            Zoom = 1.0f;
        }

        public Viewport Viewport
        {
            get
            {
                return _viewport;
            }
        }

        public Vector2 ShakeValue
        {
            get { return this.shakeValue; }
            set { this.shakeValue = value; }
        }
        
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set 
            {
                //_position = value;  

                //// If there's a limit set and there's no zoom or rotation clamp the position
                //if(Limits != null && Zoom == 1.0f && Rotation == 0.0f)
                //{
                //   _position.X = MathHelper.Clamp(_position.X, Limits.Value.X, Limits.Value.X + Limits.Value.Width - _viewport.Width);
                //   //_position.X = MathHelper.Clamp(_position.X, Limits.Value.X, Limits.Value.X + Limits.Value.Width);
                //   _position.Y = MathHelper.Clamp(_position.Y, Limits.Value.Y, Limits.Value.Y + Limits.Value.Height - _viewport.Height);
                //   //_position.Y = MathHelper.Clamp(_position.Y, Limits.Value.Y, Limits.Value.Y + Limits.Value.Height);
                //}

                _positionTarget = value;

                // If there's a limit set and there's no zoom or rotation clamp the position
                if (Limits != null && Zoom == 1.0f && Rotation == 0.0f)
                {
                    _positionTarget.X = MathHelper.Clamp(_positionTarget.X, Limits.Value.X, Limits.Value.X + Limits.Value.Width - _viewport.Width);
                    //_position.X = MathHelper.Clamp(_position.X, Limits.Value.X, Limits.Value.X + Limits.Value.Width);
                    _positionTarget.Y = MathHelper.Clamp(_positionTarget.Y, Limits.Value.Y, Limits.Value.Y + Limits.Value.Height - _viewport.Height);
                    //_position.Y = MathHelper.Clamp(_position.Y, Limits.Value.Y, Limits.Value.Y + Limits.Value.Height);
                }
                
                Vector2 diff = Vector2.Subtract(_positionTarget, _position);
                this._position += diff / cameraFlow;
            }
        }

        public Vector2 Origin { get; set; }
        
        public float Zoom { get; set; }
        
        public float Rotation { get; set; }

       
        public Rectangle? Limits
        {
            get
            {
                return _limits;
            }
            set
            {
                if(value != null)
                {
                    // Assign limit but make sure it's always bigger than the viewport
                    _limits = new Rectangle
                    {
                        X = (int)(value.Value.X - this.shakeValue.X),
                        Y = (int)(value.Value.Y - this.shakeValue.X),
                        Width = (int)(System.Math.Max(_viewport.Width, value.Value.Width) + this.shakeValue.X),
                        Height = (int)(System.Math.Max(_viewport.Height, value.Value.Height) + this.shakeValue.Y)
                    };

                    // Validate camera position with new limit
                    Position = Position;
                }
                else
                {
                    _limits = null;
                }
            }
        }

        public Matrix GetViewMatrix(Vector2 parallax)
        {
            return Matrix.CreateTranslation(new Vector3(-(Position + this.shakeValue) * parallax, 0.0f)) *
                   Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(Zoom, Zoom, 1.0f) *
                   Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }

        public void LookAt(Vector2 position)
        {
            Position = position - new Vector2(_viewport.Width / 2.0f, _viewport.Height / 2.0f);

            this.Shake();
        }

        public void Move(Vector2 displacement, bool respectRotation = false)
        {
            if (respectRotation)
            {
                displacement = Vector2.Transform(displacement, Matrix.CreateRotationZ(-Rotation));
            }
            
            Position += displacement;
        }

        public void NewShake(int ShakeRange, float ShakeLength)
        {
            this.shakeRange = ShakeRange;
            this.shakeCamTimer = ShakeLength;
        }
        public void Shake()
        {
            if (this.shakeCamTimer >= 0)
            {
                this.shakeCamTimer -= this.shakeDecline;
                this.ShakeValue = new Vector2(random.Next(-this.shakeRange, this.shakeRange),
                                        random.Next(-this.shakeRange, this.shakeRange));
            }
        }
    }
}

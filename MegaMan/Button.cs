using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace RexCommando
{
    public enum ButtonStateM
    {
        On, Off
    }

    public class Button
    {

        //Variables
        Texture2D texture;
        Vector2 position;
        Vector2 targetPosition;
        Vector2 origin;
        public ButtonStateM state;
        float scale;
        float targetScale;
        Color color;
        Color targetColor;
        Color darkColor = Color.FromNonPremultiplied(100, 100, 100, 255);

        //Constructs
        public Button()
        {
            this.Initialise();
        }
        public Button(Texture2D Texture, Vector2 PositionTarget, Vector2 PositionStart)
        {
            this.Initialise();

            this.texture = Texture;
            this.targetPosition = PositionTarget;
            this.position = PositionStart;
            this.origin.X = this.texture.Width / 2;
            this.origin.Y = this.texture.Height / 2;
        }

        //Methods
        public void Initialise()
        {
            this.texture = null;
            this.position = Vector2.Zero;
            this.targetPosition = Vector2.Zero;
            this.origin = Vector2.Zero;
            this.state = ButtonStateM.Off;
            this.scale = 0.0f;
            this.targetScale = 0.4f;
            this.color = Color.White;
            this.targetColor = darkColor;

        }
        public void ChangeState(ButtonStateM newState)
        {
            switch(newState)
            {
                case ButtonStateM.Off:
                    this.targetScale = 0.4f;
                    this.targetColor = darkColor;
                    break;
                case ButtonStateM.On:
                    this.targetScale = 0.75f;
                    this.targetColor = Color.White;
                    break;
            }

            this.state = newState;
        }
        public void Update()
        {
            float rateConst = 20.0f;

            //Gradually scale
            float rate = this.targetScale - this.scale;
            this.scale += rate / rateConst;

            //Gradually change color
            int rRate = this.targetColor.R - this.color.R;
            this.color.R += (byte)(rRate / rateConst);
            int gRate = this.targetColor.G - this.color.G;
            this.color.G += (byte)(gRate / rateConst);
            int bRate = this.targetColor.B - this.color.B;
            this.color.B += (byte)(bRate / rateConst);

            //Gradually move to target
            Vector2 diff = Vector2.Subtract(this.targetPosition, this.position);
            this.position += diff / 20.0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Bit hacky but using update in the draw cause im lazyyyy
            this.Update();


            //Draw Shadow
            Color shadow = Color.FromNonPremultiplied(0, 0, 0, (int)(80 * (0.8f / this.scale)));
            Vector2 shadowOffset = Vector2.Zero;
            shadowOffset.X = this.position.X - (this.scale * this.scale * 100);
            shadowOffset.Y = this.position.Y + (this.scale * this.scale * 100);
            spriteBatch.Draw(this.texture, shadowOffset, null, shadow,
                                0.0f, this.origin, this.scale, SpriteEffects.None, 0.0f);

            //Draw main object
            spriteBatch.Draw(this.texture, this.position, null, this.color,
                     0.0f, this.origin, this.scale, SpriteEffects.None, 0.0f);
        }

    }
}

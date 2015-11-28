using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MegaMan
{
    public class BackgroundItem
    {
        //Private Variables
        private Texture2D image;
        private Vector2 position;

        //Constructs
        public BackgroundItem()
        {
            this.image = null;
            this.position = Vector2.Zero;
        }

        public BackgroundItem(Texture2D Image, Vector2 Position)
        {
            this.image = Image;
            this.position = Position;
        }

        public BackgroundItem(BackgroundItem backCopy)
        {
            this.image = backCopy.GetImage();
            this.position = backCopy.GetPos();
        }

        //Public Variable Access (Get, Set)
        public Vector2 GetPos() { return this.position; }
        public void SetPos(Vector2 NewPos) { this.position = NewPos; }
        public void ShiftXPos(float shiftAmount) { this.position.X += shiftAmount; }

        public Texture2D GetImage() { return this.image; }
    }
}

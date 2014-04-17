using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Annihilation_Quest
{
    class Button
    {
        public SpriteBatch sb;
        public SpriteFont SF { get; set; }
        public string Text { get; set; }
        public Rectangle Hitbox { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }

        public Button(SpriteFont SF, string text, Vector2 position, Vector2 size, SpriteBatch sb)
        {
            this.SF = SF;
            this.Text = text;
            this.Position = position;
            this.Hitbox = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            this.Color = Color.Black;
            this.sb = sb;
        }

        public void Draw()
        {
            sb.Begin();
            sb.DrawString(this.SF, this.Text, this.Position, this.Color);
            sb.End();
        }
        
    }
}

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
    class Obstacle
    {
        public Rectangle Hitbox;
        public Vector2 Position { get; set; }
        SpriteBatch sb;
        public List<Texture2D> sprites = new List<Texture2D>();

        public Obstacle(Vector2 size, Vector2 position, SpriteBatch sb)
        {
            this.Position = position;
            this.Hitbox = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            this.sb = sb;
        }

        public void Draw()
        {
            sb.Begin();
            sb.Draw(sprites[0], Hitbox, Color.White);
            sb.End();
        }

        public void Contact(Hero L)
        {
            if (this.Hitbox.Top <= L.Hitbox.Bottom && this.Hitbox.Bottom > L.Hitbox.Bottom && this.Hitbox.Top > L.Hitbox.Top && this.Hitbox.Right > L.Hitbox.Left && this.Hitbox.Left < L.Hitbox.Right && L.Moving.Y >= 0)
            {
                L.Jump = 0;
                L.Moving = new Vector2(L.Moving.X, 0);
                //L.Position = new Vector2(L.Position.X, this.Hitbox.Top - L.Hitbox.Height);
            }
            if (this.Hitbox.Right >= L.Hitbox.Left && this.Hitbox.Left < L.Hitbox.Left && this.Hitbox.Right < L.Hitbox.Right && this.Hitbox.Top < L.Hitbox.Bottom && this.Hitbox.Bottom > L.Hitbox.Top && L.Moving.X <= 0)
            {
                L.Moving = new Vector2(0, L.Moving.Y);
                //L.Position = new Vector2(this.Hitbox.Right, L.Position.Y);
            }
            if (this.Hitbox.Left <= L.Hitbox.Right && this.Hitbox.Right > L.Hitbox.Right && this.Hitbox.Left > L.Hitbox.Left && this.Hitbox.Top < L.Hitbox.Bottom && this.Hitbox.Bottom > L.Hitbox.Top && L.Moving.X >= 0)
            {
                L.Moving = new Vector2(0, L.Moving.Y);
                //L.Position = new Vector2(this.Hitbox.Left - L.Hitbox.Width, L.Position.Y);
            }
            if (this.Hitbox.Bottom >= L.Hitbox.Top && this.Hitbox.Top < L.Hitbox.Top && this.Hitbox.Bottom < L.Hitbox.Bottom && this.Hitbox.Right > L.Hitbox.Left && this.Hitbox.Left < L.Hitbox.Right && L.Moving.Y <= 0)
            {
                L.Moving = new Vector2(L.Moving.X, 0);
                //L.Position = new Vector2(L.Position.X, this.Hitbox.Bottom);
            }
        }

        public void Scrolling(Vector2 P)
        {
            this.Position += P;
            Hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, Hitbox.Width, Hitbox.Height);
        }

    }
}

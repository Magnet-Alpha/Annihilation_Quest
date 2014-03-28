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
        Rectangle Hitbox;
        Vector2 Position { get; set; }
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
                L.Moving = new Vector2(L.Moving.X, 0);
            if (this.Hitbox.Right >= L.Hitbox.Left && this.Hitbox.Left < L.Hitbox.Left && this.Hitbox.Right < L.Hitbox.Right  && L.Moving.X <= 0)
                L.Moving = new Vector2(0, L.Moving.Y);
            if (this.Hitbox.Left <= L.Hitbox.Right && this.Hitbox.Right > L.Hitbox.Right && this.Hitbox.Left > L.Hitbox.Left && L.Moving.X >= 0)
                L.Moving = new Vector2(0, L.Moving.Y);
        }

    }
}

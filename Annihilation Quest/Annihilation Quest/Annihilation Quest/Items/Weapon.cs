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
    class Weapon
    {
        public Rectangle Hitbox { get; set; }
        public Vector2 Position { get; set; }
        public List<Texture2D> sprites = new List<Texture2D>();
        public SpriteBatch sb;

        public Weapon(Vector2 size, Vector2 position, SpriteBatch sb, ContentManager c)
        {
            this.Hitbox = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            this.Position = position;
            this.sb = sb;
            sprites.Add(c.Load<Texture2D>("Sword1"));
        }

        public void Draw()
        {
            sb.Begin();
            sb.Draw(sprites[0], Hitbox, Color.White);
            sb.End();
        }
    }
}

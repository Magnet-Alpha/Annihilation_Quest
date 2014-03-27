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
    class Living
    {
        public Rectangle Hitbox { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Moving { get; set; }
        public SpriteBatch sb;
        public int HP { get; set; }
        protected int maxHP;
        public List<Texture2D> sprites = new List<Texture2D>();

        public Living(Vector2 size, Vector2 position, SpriteBatch sb, ContentManager c, int hp)
        {
            this.Hitbox = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            this.Position = position;
            this.Moving = new Vector2(0, 0);
            this.sb = sb;
            this.HP = hp;
            this.maxHP = hp;
        }

        public void Move()
        {
            this.Position = this.Position + this.Moving;
            this.Hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, Hitbox.Width, Hitbox.Height);
        }

        public void Draw()
        {
            sb.Begin();
            sb.Draw(sprites[0], Hitbox, Color.White);
            sb.End();
        }
    }
}

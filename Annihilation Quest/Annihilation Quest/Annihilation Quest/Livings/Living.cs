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
        public int Speed { get; set; }
        protected int ospeed;
        public List<Texture2D> sprites = new List<Texture2D>();
        public Etat State { get; set; }
        public int Atk { get; set; }
        public int Side { get; set; }

        public Living(Vector2 size, Vector2 position, SpriteBatch sb, ContentManager c, int hp, int speed, int atk)
        {
            this.Hitbox = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            this.Position = position;
            this.Moving = new Vector2(0, 0);
            this.sb = sb;
            this.HP = hp;
            this.maxHP = hp;
            this.Speed = speed;
            this.ospeed = speed;
            this.Atk = atk;
            this.State = Etat.Alive;
            this.Side = -1;
        }

        public Vector2 Move()
        {
            //this.Position = this.Position + new Vector2(this.Moving.X * this.Speed, this.Moving.Y);
            //this.Hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, Hitbox.Width, Hitbox.Height);
            return (new Vector2(this.Moving.X * this.Speed, this.Moving.Y));
        }

        public virtual void Draw()
        {
            if (Side == -1)
            {
                sb.Begin();
                sb.Draw(sprites[0], Hitbox, Color.White);
                sb.End();
            }
            else
            {
                sb.Begin();
                sb.Draw(sprites[0], Hitbox, new Rectangle(0, 0, Hitbox.Width, Hitbox.Height), Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                sb.End();
            }
        }

        public void Gravity(GameTime g)
        {
            this.Moving = new Vector2(this.Moving.X, this.Moving.Y + 12 * (float)g.ElapsedGameTime.TotalSeconds);
        }

        public void SpeedBonus(int bonus)
        {
            this.Speed = this.ospeed * bonus;
        }
    }
}

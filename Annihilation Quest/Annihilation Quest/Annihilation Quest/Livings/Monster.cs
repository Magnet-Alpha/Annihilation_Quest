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
    class Monster : Living
    {
        public int Invincibility { get; set; }

        public Monster(Vector2 size, Vector2 position, SpriteBatch sb, ContentManager c, int hp, int speed, int atk)
            : base(size, position, sb, c, hp, speed, atk)
        {
        }

        public void Scrolling(Vector2 P)
        {
            this.Position += P;
            Hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, Hitbox.Width, Hitbox.Height);
        }

        public void Contact(Hero L)
        {
            if (L.Invincibility == 0)
            {
                if (this.Hitbox.Top <= L.Hitbox.Bottom && this.Hitbox.Bottom > L.Hitbox.Bottom && this.Hitbox.Top > L.Hitbox.Top && this.Hitbox.Right > L.Hitbox.Left && this.Hitbox.Left < L.Hitbox.Right)
                {
                        L.Damage(Atk);
                }
                else if (this.Hitbox.Right >= L.Hitbox.Left && this.Hitbox.Left < L.Hitbox.Left && this.Hitbox.Right < L.Hitbox.Right && this.Hitbox.Top < L.Hitbox.Bottom && this.Hitbox.Bottom > L.Hitbox.Top)
                {
                        L.Damage(Atk);
                }
                else if (this.Hitbox.Left <= L.Hitbox.Right && this.Hitbox.Right > L.Hitbox.Right && this.Hitbox.Left > L.Hitbox.Left && this.Hitbox.Top < L.Hitbox.Bottom && this.Hitbox.Bottom > L.Hitbox.Top)
                {
                        L.Damage(Atk);
                }
                else if (this.Hitbox.Bottom >= L.Hitbox.Top && this.Hitbox.Top < L.Hitbox.Top && this.Hitbox.Bottom < L.Hitbox.Bottom && this.Hitbox.Right > L.Hitbox.Left && this.Hitbox.Left < L.Hitbox.Right)
                {
                        L.Damage(Atk);
                }
            }
        }

        public void Damage(int atk)
        {
            this.HP -= atk;
            this.Invincibility = 1;
        }

        public override void Draw()
        {
            if (Invincibility != 0)
            {
                if (Invincibility % 15 < 8)
                    base.Draw();
                Invincibility++;
                if (Invincibility == 60)
                    Invincibility = 0;
            }
            else
                base.Draw();
        }
    }
}

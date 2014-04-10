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
        public Rectangle AttackHitbox { get; set; }
        public Vector2 Position { get; set; }
        public List<Texture2D> sprites = new List<Texture2D>();
        public SpriteBatch sb;
        public Etat State { get; set; }
        public Living Owner { get; set; }
        public int Attacking { get; set; }
        public int NumHit { get; set; }
        public List<Breakable> HitItems = new List<Breakable>();
        public int Side { get; set; }

        public Weapon(Vector2 size, Vector2 position, SpriteBatch sb, ContentManager c, Living L)
        {
            this.Hitbox = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            this.AttackHitbox = new Rectangle((int)position.X - 64, (int)position.Y - 64, (int)size.X * 2, (int)size.Y *2);
            this.Position = position;
            this.sb = sb;
            sprites.Add(c.Load<Texture2D>("Sword1"));
            this.State = Etat.Alive;
            this.Owner = L;
            this.NumHit = 0;
            this.Side = L.Side;
        }

        public void Attack(Monster L)
        {
            if (this.State == Etat.Attack && L.Hitbox.Intersects(this.AttackHitbox) && L.Invincibility == 0)
            {
                L.Damage(Owner.Atk);
            }
        }
        public void Attack(Breakable L)
        {
            if (this.State == Etat.Attack && L.Hitbox.Intersects(this.AttackHitbox) && this.NumHit != L.HitTaken)
            {
                L.Damage(Owner.Atk);
                L.HitTaken = this.NumHit;
                if (!this.HitItems.Contains(L))
                    this.HitItems.Add(L);
            }
        }

        public void PassingAttack()
        {
            if (this.Attacking != 0)
            {
                this.State = Etat.Attack;
                Attacking++;
                if (this.Attacking == 31)
                    this.Attacking = 0;
            }
            else
            {
                this.State = Etat.Alive;
                this.NumHit = 0;
                foreach (Breakable b in HitItems)
                {
                    b.HitTaken = 0;
                }
                HitItems.Clear();
            }
        }

        public void Siding()
        {
            this.AttackHitbox = new Rectangle((int)Position.X + 16 + 32 * (Side - 1), AttackHitbox.Y, AttackHitbox.Width, AttackHitbox.Height);
        }

        public void Draw()
        {
            sb.Begin();
            sb.Draw(sprites[0], new Rectangle(this.Hitbox.X - (int)((Math.Cos((double)((float)this.Attacking / 30 * (float)Math.PI)) * 16)) + 16 * (Side + 1), this.Hitbox.Y + Side * (int)((Math.Sin((double)((float)this.Attacking / 30 * (float)Math.PI)) * 16)), this.Hitbox.Width, this.Hitbox.Height), new Rectangle(0, 0, 32, 64), Color.White, (float)this.Attacking / 30 * (float)Math.PI * -Side, Vector2.Zero, SpriteEffects.None, 0);
            sb.End();
        }
    }
}

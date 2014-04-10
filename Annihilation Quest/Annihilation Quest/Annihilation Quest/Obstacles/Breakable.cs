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
    class Breakable : Obstacle
    {
        public int HP { get; set; }
        public Etat State { get; set; }
        public int HitTaken { get; set; }

        public Breakable(Vector2 size, Vector2 position, SpriteBatch sb, ContentManager c, int hp)
            : base(size, position, sb)
        {
            this.HP = hp;
            sprites.Add(c.Load<Texture2D>("Box1"));
            HitTaken = 0;
        }

        public void Break()
        {
            if (this.HP == 0)
                this.State = Etat.Dead;
        }

        public void Damage(int atk)
        {
            this.HP -= atk;
        }
    }
}

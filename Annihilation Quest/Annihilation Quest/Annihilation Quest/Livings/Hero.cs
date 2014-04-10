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
    class Hero : Living
    {
        public int Jump { get; set; }
        public int Invincibility { get; set; }

        public Hero(Vector2 size, Vector2 position, SpriteBatch sb, ContentManager c, int hp, int speed, int atk)
            : base(size, position, sb, c, hp, speed, atk)
        {
            sprites.Add(c.Load<Texture2D>("Hero1"));
            this.Jump = 0;
            this.Invincibility = 0;
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

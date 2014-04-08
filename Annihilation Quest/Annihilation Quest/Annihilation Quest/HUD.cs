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
    class HUD
    {
        public SpriteBatch sb;
        public List<Texture2D> sprites = new List<Texture2D>();

        public HUD(SpriteBatch sb, ContentManager c)
        {
            this.sb = sb;
            sprites.Add(c.Load<Texture2D>("Sword1"));
        }

        public void Draw()
        {
            sb.Begin();
            sb.Draw(sprites[0], new Rectangle(0, 0, 128, 32), Color.White);
            sb.End();
        }
    }
}

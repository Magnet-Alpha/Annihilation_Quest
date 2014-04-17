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
    class Slime : Monster
    {
        public Slime(Vector2 position, SpriteBatch sb, ContentManager c)
            : base(new Vector2(64, 64), position, sb, c, 20, 1, 10)
        {
            sprites.Add(c.Load<Texture2D>("Test Monster"));
        }
    }
}

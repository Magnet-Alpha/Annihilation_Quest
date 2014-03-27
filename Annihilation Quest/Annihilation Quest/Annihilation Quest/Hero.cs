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


        public Hero(Vector2 size, Vector2 position, SpriteBatch sb, ContentManager c, int hp)
            : base(size, position, sb, c, hp)
        {
            sprites.Add(c.Load<Texture2D>("Test Hero"));
        }

    }
}

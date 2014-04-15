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
    class IPrinc : IMenu
    {
        ContentManager Content;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public IPrinc(GraphicsDeviceManager graphics, SpriteBatch sb, ContentManager Content)
        {
            this.graphics = graphics;
            this.spriteBatch = sb;
            this.Content = Content;
            this.Initialize();
            this.LoadContent();
        }

        public void Initialize()
        {

        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }

    }
}

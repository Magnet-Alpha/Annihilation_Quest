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
        Game1 game;
        ContentManager Content;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Button> LB;
        Button newgame;
        Button continu;
        Button exit;
        int choice;
        KeyboardState oldks;
        bool lol;

        public IPrinc(Game1 game, GraphicsDeviceManager graphics, SpriteBatch sb, ContentManager Content)
        {
            this.game = game;
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
            this.newgame = new Button(Content.Load<SpriteFont>("Font1"), "New Game", new Vector2(100, 200), new Vector2(200, 50), spriteBatch);
            this.continu = new Button(Content.Load<SpriteFont>("Font1"), "Continue", new Vector2(100, 300), new Vector2(200, 50), spriteBatch);
            this.exit = new Button(Content.Load<SpriteFont>("Font1"), "Exit", new Vector2(100, 400), new Vector2(200, 50), spriteBatch);
            this.choice = 0;
            LB = new List<Button>();
            LB.Add(newgame);
            LB.Add(continu);
            LB.Add(exit);
            oldks = Keyboard.GetState();
            lol = false;
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldks.IsKeyUp(Keys.Down))
                choice = (choice + 1) % 3;
            else if (ks.IsKeyDown(Keys.Up) && oldks.IsKeyUp(Keys.Up))
                choice = (choice + 2) % 3;
            int i = 0;
            while (i < LB.Count)
            {
                if (i == choice)
                    LB[i].Color = Color.Yellow;
                else
                    LB[i].Color = Color.Black;
                i++;
            }
            if (ks.IsKeyDown(Keys.Enter) && oldks.IsKeyUp(Keys.Enter))
            {
                if (LB[choice] == newgame)
                    game.menu = new IGame(game, graphics, spriteBatch, Content);
                if (LB[choice] == continu)
                    lol = true;
                if (LB[choice] == exit)
                    game.Exit();
            }
            if (ks.IsKeyDown(Keys.Escape) && oldks.IsKeyUp(Keys.Escape))
            {
                if (LB[choice] == exit)
                    game.Exit();
                else
                    choice = 2;
            }
            oldks = ks;

        }

        public void Draw(GameTime gameTime)
        {
            newgame.Draw();
            continu.Draw();
            exit.Draw();
            if (lol)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(Content.Load<SpriteFont>("Font1"), "Lol", new Vector2(500, 300), Color.Black);
                spriteBatch.End();
            }
        }

    }
}

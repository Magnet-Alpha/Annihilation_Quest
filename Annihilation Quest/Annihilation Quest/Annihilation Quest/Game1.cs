using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Annihilation_Quest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hero L;
        Obstacle ground;
        Obstacle wallL;
        Obstacle wallR;
        KeyboardState oldks;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            L = new Hero(new Vector2(64, 64), new Vector2(100, 0), spriteBatch, Content, 10, 5);
            ground = new Obstacle(new Vector2(800, 100), new Vector2(0, 400), spriteBatch);
            wallL = new Obstacle(new Vector2(10, 480), new Vector2(0, 0), spriteBatch);
            wallR = new Obstacle(new Vector2(10, 480), new Vector2(790, 0), spriteBatch);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            int bonus = 1;
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
                L.Moving = new Vector2(1, L.Moving.Y);
            else if (ks.IsKeyDown(Keys.Left))
                L.Moving = new Vector2(-1, L.Moving.Y);
            else
                L.Moving = new Vector2(0, L.Moving.Y);
            if (ks.IsKeyDown(Keys.Up) && oldks.IsKeyUp(Keys.Up))
                L.Moving = new Vector2(L.Moving.X, -8);
            if (ks.IsKeyDown(Keys.Space))
                bonus += 1;

            L.SpeedBonus(bonus);
            L.Gravity(gameTime);
            ground.Contact(L);
            wallL.Contact(L);
            wallR.Contact(L);
            L.Move();
            oldks = ks;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            L.Draw();

            base.Draw(gameTime);
        }
    }
}

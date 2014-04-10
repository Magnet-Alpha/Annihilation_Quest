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
        Weapon M;
        Monster N;
        Ground ground;
        Wall wallL;
        Wall wallR;
        Wall wallU;
        HUD hud;
        Breakable Box;
        KeyboardState oldks;
        List<Obstacle> O = new List<Obstacle>();
        int ancbonus = 1;

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
            L = new Hero(new Vector2(64, 128), new Vector2(360, 272), spriteBatch, Content, 10, 5, 5);
            M = new Weapon(new Vector2(32, 64), new Vector2(L.Position.X + 16, L.Position.Y + 64), spriteBatch, Content, L);
            N = new Monster(new Vector2(64, 128), new Vector2(800, 272), spriteBatch, Content, 10, 5, 5);
            ground = new Ground(new Vector2(4000, 100), new Vector2(-2000, 400), spriteBatch, Content);
            wallL = new Wall(new Vector2(20, 1480), new Vector2(-2000, -1000), spriteBatch, Content);
            wallR = new Wall(new Vector2(20, 1480), new Vector2(2000, -1000), spriteBatch, Content);
            wallU = new Wall(new Vector2(800, 20), new Vector2(0, 0), spriteBatch, Content);
            Box = new Breakable(new Vector2(64, 64), new Vector2(10, 272 + 64), spriteBatch, Content, 20);
            O.Add(ground);
            O.Add(wallL);
            O.Add(wallR);
            O.Add(Box);
            hud = new HUD(spriteBatch, Content);
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
            if (ks.IsKeyDown(Keys.Right) && M.Attacking == 0)
            {
                L.Moving = new Vector2(1, L.Moving.Y);
                L.Side = 1;
            }
            else if (ks.IsKeyDown(Keys.Left) && M.Attacking == 0)
            {
                L.Moving = new Vector2(-1, L.Moving.Y);
                L.Side = -1;
            }
            else
                L.Moving = new Vector2(0, L.Moving.Y);
            if (ks.IsKeyDown(Keys.Up) && oldks.IsKeyUp(Keys.Up) && L.Jump < 2)
            {
                L.Jump++;
                L.Moving = new Vector2(L.Moving.X, -8);
            }
            if (ks.IsKeyDown(Keys.C) && L.Jump == 0)
                bonus += 1;
            else if (L.Jump > 0)
                bonus = ancbonus;
            if (ks.IsKeyDown(Keys.Z) && oldks.IsKeyUp(Keys.Z))
            {
                M.Attacking = 1;
                M.NumHit++;
            }

            ancbonus = bonus;
            L.SpeedBonus(bonus);
            L.Gravity(gameTime);
            M.PassingAttack();
            Vector2 P = new Vector2();
            foreach (Obstacle o in O)
            {
                P += -o.Contact(L);
            }
            N.Contact(L);
            P += -L.Move();
            M.Attack(N);
            M.Attack(Box);
            M.Side = L.Side;
            M.Siding();
            foreach (Obstacle o in O)
            {
                o.Scrolling(P);
            }
            if (Box.HP <= 0)
            {
                O.Remove(Box);
            }
            N.Scrolling(P);
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

            foreach (Obstacle o in O)
            {
                o.Draw();
            }
            L.Draw();
            M.Draw();
            N.Draw();
            hud.Draw();

            base.Draw(gameTime);
        }
    }
}

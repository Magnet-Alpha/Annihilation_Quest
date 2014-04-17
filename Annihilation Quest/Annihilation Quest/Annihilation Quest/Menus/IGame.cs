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
    class IGame : IMenu
    {
        Game1 game;
        ContentManager Content;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hero L;
        Weapon M;
        Slime N;
        Ground ground;
        Wall wallL;
        Wall wallR;
        Wall wallU;
        HUD hud;
        Breakable Box;
        KeyboardState oldks;
        List<Obstacle> O = new List<Obstacle>();
        int ancbonus = 1;
        bool pause;

        public IGame(Game1 game, GraphicsDeviceManager graphics, SpriteBatch sb, ContentManager Content)
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
            L = new Hero(new Vector2(64, 128), new Vector2(360, 272), spriteBatch, Content, 10, 5, 5);
            M = new Weapon(new Vector2(32, 64), new Vector2(L.Position.X + 16, L.Position.Y + 64), spriteBatch, Content, L);
            N = new Slime(new Vector2(800, 272 + 64), spriteBatch, Content);
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
            oldks = Keyboard.GetState();
            pause = false;
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            if (pause)
                Pause();
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
            if (ks.IsKeyDown(Keys.Escape) && oldks.IsKeyUp(Keys.Escape))
                game.menu = new IPrinc(game, graphics, spriteBatch, Content, this);

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
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Obstacle o in O)
            {
                o.Draw();
            }
            L.Draw();
            M.Draw();
            N.Draw();
            L.DrawHUD();
        }

        public void Pause()
        {
        }
    }
}

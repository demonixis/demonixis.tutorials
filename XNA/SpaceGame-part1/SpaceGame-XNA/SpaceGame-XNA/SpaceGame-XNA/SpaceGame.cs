using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace SpaceGame_XNA
{
    public class SpaceGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D ship;
        Vector2 shipPosition;
        int moveSpeed;

        Texture2D backgroundSpace;

        public SpaceGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;

            Window.Title = "Tutoriel XNA 01 : Space Game";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Fond de l'écran
            backgroundSpace = Content.Load<Texture2D>("background-space");

            // Texture du vaisseau
            ship = Content.Load<Texture2D>("ship");

            // Position initiale du vaisseau
            shipPosition = new Vector2(
                (graphics.PreferredBackBufferWidth / 2) - ship.Width / 2,
                graphics.PreferredBackBufferHeight - ship.Height * 2);

            base.LoadContent();
        }

        // Libération des ressources
        protected override void UnloadContent()
        {
            ship.Dispose();
            backgroundSpace.Dispose();

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // On quitte le jeu
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // Gestion de l'accélération du vaisseau
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                moveSpeed = 5;
            else
                moveSpeed = 2;

            // Déplacement du vaisseau
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                shipPosition.Y -= moveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                shipPosition.Y += moveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                shipPosition.X -= moveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                shipPosition.X += moveSpeed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Efface l'écran
            graphics.GraphicsDevice.Clear(Color.AliceBlue);

            // Début du mode dessin
            spriteBatch.Begin();

            // On affichage le fond à la position 0, 0
            spriteBatch.Draw(backgroundSpace, Vector2.Zero, Color.White);

            // On affiche le vaisseau à la position définie dans Update()
            spriteBatch.Draw(ship, shipPosition, Color.White);

            // Fin du mode dessin
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}


using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace MonoGameTutorial
{
    public class SpaceGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Variables relatives au vaisseau
        Texture2D ship;
        Vector2 shipPosition;
        int moveSpeed;

        // Variables relatives au laser
        Texture2D laser;
        Vector2 laserPosition;
        int laserSpeed;
		bool shooted;

        // Fond du jeu
        Texture2D backgroundSpace;

        public SpaceGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;

            Window.Title = "Tutoriel XNA 02 : Space Game";
        }

        protected override void Initialize()
        {
            moveSpeed = 2; // Vitesse du vaisseau
			shooted = false; // La laser n'est pas tiré
            laserSpeed = 4; // Vitesse du laser

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

            laser = Content.Load<Texture2D>("laser");
             
            base.LoadContent();
        }

        private void shoot()
        {
            if (!shooted)
            {
                // La position du laser est définie par :
                // - la position en X du vaisseau + la moitier de sa taille
                // - moins la moitier de la taille du laser
                laserPosition = new Vector2(
                    (shipPosition.X + (ship.Width / 2)) - laser.Width / 2, 
                    shipPosition.Y);
				shooted = true; // Le laser est tiré !
            }
        }

        // Libération des ressources
        protected override void UnloadContent()
        {
            ship.Dispose();
            backgroundSpace.Dispose();
            laser.Dispose();

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // On quitte le jeu
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // Si le laser n'est plus visible et qu'il a été tiré
            // On ne le met plus à jour
            if (shooted && laserPosition.Y + laser.Height <= 0)
                shooted = false; // On peut maintenant retirer un autre laser


            // Si le laser a été tiré on le fait monter
            if (shooted)
                laserPosition.Y -= laserSpeed;

            // Gestion de l'accélération du vaisseau
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                moveSpeed = 5;
            else
                moveSpeed = 2;

            // Déplacement du vaisseau et gestion des collisions avec les bords
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && shipPosition.Y > 0)
                shipPosition.Y -= moveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && shipPosition.Y + ship.Height < graphics.PreferredBackBufferHeight)
                shipPosition.Y += moveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && shipPosition.X > 0)
                shipPosition.X -= moveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && shipPosition.X + ship.Width < graphics.PreferredBackBufferWidth)
                shipPosition.X += moveSpeed;

            // Tire le laser
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                shoot();

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

            // Si le laser est tiré on le dessine
            if (shooted)
                spriteBatch.Draw(laser, laserPosition, Color.White);

            // Fin du mode dessin
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}


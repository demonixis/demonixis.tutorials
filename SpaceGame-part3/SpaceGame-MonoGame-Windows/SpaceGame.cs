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

        // Vaisseau
		Sprite ship;

        // Laser
        Sprite laser;

        // Fond du jeu
        Texture2D backgroundSpace;

        public SpaceGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;

            Window.Title = "Tutoriel XNA 03 : Space Game";
        }

        protected override void Initialize()
        {
			ship = new Sprite(this);
			ship.Speed = new Vector2(2, 2);
			laser = new Sprite(this);
			laser.Speed = new Vector2(4, 4);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Fond de l'écran
            backgroundSpace = Content.Load<Texture2D>("background-space");

            // Texture du vaisseau
			ship.LoadContent("ship");

            // Position initiale du vaisseau
            ship.Position = new Vector2(
                (graphics.PreferredBackBufferWidth / 2) - ship.Width / 2,
                graphics.PreferredBackBufferHeight - ship.Height * 2);
			
			laser.LoadContent("laser");
             
            base.LoadContent();
        }

        private void shoot()
        {
            if (!laser.Active)
            {
                // La position du laser est définie par :
                // - la position en X du vaisseau + la moitier de sa taille
                // - moins la moitier de la taille du laser
                laser.Position = new Vector2(
                    (ship.Position.X + (ship.Width / 2)) - laser.Width / 2, 
                    ship.Position.Y);
				laser.Active = true; // Le laser est tiré !
            }
        }

        // Libération des ressources
        protected override void UnloadContent()
        {
			backgroundSpace.Dispose();
            ship.UnloadContent();
            laser.UnloadContent();
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // On quitte le jeu
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // Si le laser n'est plus visible et qu'il a été tiré
            // On ne le met plus à jour
            if (laser.Active && laser.Position.Y + laser.Height <= 0)
                laser.Active = false; // On peut maintenant retirer un autre laser


            // Si le laser a été tiré on le fait monter
            if (laser.Active)
                laser.Position = new Vector2(laser.Position.X, laser.Position.Y - laser.Speed.Y);

            // Gestion de l'accélération du vaisseau
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                ship.Speed = new Vector2(5, 5);
            else
                ship.Speed = new Vector2(2, 2);

            // Déplacement du vaisseau et gestion des collisions avec les bords
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && ship.Position.Y > 0)
                ship.Position = new Vector2(ship.Position.X, ship.Position.Y - ship.Speed.Y);

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && ship.Position.Y + ship.Height < graphics.PreferredBackBufferHeight)
                ship.Position = new Vector2(ship.Position.X, ship.Position.Y + ship.Speed.Y); 

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && ship.Position.X > 0)
                ship.Position = new Vector2(ship.Position.X - ship.Speed.X, ship.Position.Y);

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && ship.Position.X + ship.Width < graphics.PreferredBackBufferWidth)
                ship.Position = new Vector2(ship.Position.X + ship.Speed.X, ship.Position.Y);

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
            ship.Draw(spriteBatch);

            // Si le laser est tiré on le dessine
            laser.Draw(spriteBatch);

            // Fin du mode dessin
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}


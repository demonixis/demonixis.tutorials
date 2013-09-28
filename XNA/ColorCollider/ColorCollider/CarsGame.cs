using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ColorCollider
{
    public class CarsGame : Game
    {
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		KeyboardState keyboard;

        // Objets pour la voiture
        Texture2D car;
        Vector2 carOrigin;
        Vector2 carPosition;
        Vector2 carNextPosition;
        float carSpeed;
        float carRotation;

		Texture2D circuit;
        Color[] colorCircuitArray;
		Color collideColor;

        public CarsGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
			Window.Title = "Tutoriel XNA/MonoGame - Demonixis.Net : Détection de collision par pixel";
        }

        /// <summary>
        /// Récupère la couleur à la position donnée
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        /// <returns>La couleur à cette position</returns>
        private Color GetColorAt(int x, int y)
        {
            Color color = Color.White;

            // La position doit être valide
            // On passe d'un tableau 1D à 2D avec la formule x + y * texture.Width
            if (x >= 0 && x < circuit.Width && y >= 0 && y < circuit.Height)
                color = colorCircuitArray[x + y * circuit.Width];

            return color;
        }

        /// <summary>
        /// Test si la voiture peut utiliser cette position
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        /// <returns>true si la voiture peut avancer sinon false</returns>
        private bool CanMove(int x, int y)
        {
			return GetColorAt(x, y) != Color.White;
        }

        protected override void Initialize()
        {
            base.Initialize();
            // On place l'origine de la voiture au centre
			carOrigin = new Vector2(car.Width / 2, car.Height / 4);
            // On place la voiture devant la ligne d'arrivée
            carPosition = new Vector2(500, 550);
            carNextPosition = Vector2.Zero;
            // On l'incline correctement
            carRotation = (float)(-Math.PI / 2);
            carSpeed = 0.15f;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            // On charge la texture du circuit et de la voiture
			circuit = Content.Load<Texture2D>("circuit");
            car = Content.Load<Texture2D>("car");

            // Création du tableau de couleur du circuit
            colorCircuitArray = new Color[circuit.Width * circuit.Height];
            circuit.GetData<Color>(colorCircuitArray);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
                Exit();

            // Prochaine position à testerm
            carNextPosition = carPosition;

            // On avance ou on recule par rapport à la rotation de la voiture
            if (keyboard.IsKeyDown(Keys.Up))
            {
                carNextPosition += new Vector2(
                    (float)(Math.Sin(-carRotation)),
                    (float)(Math.Cos(carRotation))) * -carSpeed * gameTime.ElapsedGameTime.Milliseconds;
            }
            else if (keyboard.IsKeyDown(Keys.Down))
            {
                carNextPosition += new Vector2(
                    (float)(Math.Sin(-carRotation)),
                    (float)(Math.Cos(carRotation))) * carSpeed * gameTime.ElapsedGameTime.Milliseconds;
            }

            // Rotation de la voiture
            if (keyboard.IsKeyDown(Keys.Left))
                carRotation -= 0.1f;    
            else if (keyboard.IsKeyDown(Keys.Right))
                carRotation += 0.1f;

            // Si la prochaine position est bien sur la route 
            // et pas dans le vert on utilise ces coordoonées
            if (CanMove((int)carNextPosition.X, (int)carNextPosition.Y))
                carPosition = carNextPosition; 
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(circuit, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.Draw(car, carPosition, null, Color.White, carRotation, carOrigin, Vector2.One, SpriteEffects.None, 1.0f); 
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public static void Main(string[] args)
        {
            using (CarsGame game = new CarsGame())
            {
                game.Run();
            }
        }
    }
}

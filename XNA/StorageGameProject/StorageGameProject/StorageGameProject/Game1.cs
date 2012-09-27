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

namespace StorageGameProject
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StorageManager storageManager;
        GameConfiguration gameConfiguration;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            storageManager = new StorageManager();
            gameConfiguration = storageManager.LoadGameConfiguration();

            graphics.PreferredBackBufferWidth = gameConfiguration.Width;
            graphics.PreferredBackBufferHeight = gameConfiguration.Height;

            if (gameConfiguration.IsFullScreen)
                graphics.ToggleFullScreen();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
                Exit();

            // Sauvegarde des paramètres
            if (state.IsKeyDown(Keys.S))
            {
                gameConfiguration = new GameConfiguration(640, 480, true, 0.5f, 0.4f);
                storageManager.SaveGameConfiguration(gameConfiguration);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            base.Draw(gameTime);
        }
    }
}

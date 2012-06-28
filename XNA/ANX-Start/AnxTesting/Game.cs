using System;
using ANX;
using ANX.Framework;
using ANX.Framework.Content;
using ANX.Framework.Graphics;
using ANX.Framework.Input;

namespace AnxTesting
{
	public class AGame : Game
	{
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        SpriteFont font;
        
        public AGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            Content.RootDirectory = "Content";
            Window.Title = "ANX Framework : Testing";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("background");
            font = Content.Load<SpriteFont>("font");
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.DrawString(font, "ANX Framework", new Vector2(25, 25), Color.Aquamarine, 0.0f, Vector2.Zero, new Vector2(2.0f), SpriteEffects.None, 1.0f);
            spriteBatch.DrawString(font, "DirectX 11 Rendering", new Vector2(310, 400), Color.LightSteelBlue, 0.0f, Vector2.Zero, new Vector2(2.0f), SpriteEffects.None, 1.0f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
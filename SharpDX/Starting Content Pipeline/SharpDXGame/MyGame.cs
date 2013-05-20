using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;
using SharpDX.Toolkit.Input;

namespace SharpDXGame
{
    public class MyGame : Game
    {
        protected GraphicsDeviceManager graphics;
        protected KeyboardManager keyboardManager;
        protected SpriteBatch spriteBatch;

        private SpriteFont spriteFont;
        private Texture2D image;

        public MyGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            keyboardManager = new KeyboardManager(this);
            graphics.PreferredBackBufferWidth = 320;
            graphics.PreferredBackBufferHeight = 240;
        }

        protected override void Initialize()
        {
            Window.Title = "MySharpDXGame : Chargement de ressource";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("Arial16");
            image = Content.Load<Texture2D>("background");
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (keyboardManager.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(image, Vector2.Zero, Color.White);
            spriteBatch.DrawString(spriteFont, "Utilisation d'un SpriteFont", new Vector2(40, 170), Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

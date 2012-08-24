using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameXAML
{
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        private GameTimer gameTimer;
        private SharedGraphicsDeviceManager manager;
        private ContentManager content;
        private bool pageLoaded;
        private SpriteBatch spriteBatch;

        private Texture2D texture2D;
        private Vector2 position;
        private Vector2 origin;
        private float rotation;
        private float alpha;

        public GamePage()
        {
            this.pageLoaded = false;
            this.Loaded += GamePage_Loaded;
            this.Unloaded += GamePage_Unloaded;
            this.InitializeComponent();
        }

        #region Evenements de la page

        private void GamePage_Unloaded(object sender, RoutedEventArgs e)
        {
            UnloadContent();
        }

        private void GamePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!pageLoaded)
            {
                manager = SharedGraphicsDeviceManager.Current;
                manager.PreferredBackBufferWidth = (int)this.ActualWidth;
                manager.PreferredBackBufferHeight = (int)this.ActualHeight;
                manager.SwapChainPanel = this;
                manager.ApplyChanges();

                gameTimer = new GameTimer();
                gameTimer.UpdateInterval = TimeSpan.FromTicks(166666);
                gameTimer.Update += Update;
                gameTimer.Draw += Draw;

                this.SizeChanged += GamePage_SizeChanged;

                // Le contenu est chargé une fois
                LoadContent();

                pageLoaded = true;
            }

            // L'initialisation doit se faire à chaque rechargement
            Initialize();
        }

        private void GamePage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizePage((int)e.NewSize.Width, (int)e.NewSize.Height);
        }

        #endregion

        private void ResizePage(int width, int height)
        {
            manager.PreferredBackBufferWidth = width;
            manager.PreferredBackBufferHeight = height;
            manager.ApplyChanges();

            // Mise à jour de la position du rectangle
            position = new Vector2(
                (int)(this.ActualWidth / 2 - texture2D.Width / 2),
                (int)(this.ActualHeight / 2 - texture2D.Height / 2));
        }

        #region XNA GameState pattern

        private void LoadContent()
        {
            spriteBatch = new SpriteBatch(manager.GraphicsDevice);
            content = ((App)App.Current).Content;
        }

        private void Initialize()
        {
            // 1 - Il faut démarrer le timer
            gameTimer.Start();

            // 2 - Initialisation des objets
            texture2D = CreateTexture(Color.PapayaWhip, 350, 250);
            rotation = 0.0f;

            origin = new Vector2(texture2D.Width / 2, texture2D.Height / 2);

            position = new Vector2(
                (int)(this.ActualWidth / 2),
                (int)(this.ActualHeight / 2));

            alpha = 1.0f;
        }

        private void UnloadContent()
        {
            gameTimer.Stop();
        }

        private void Update(object sender, GameTimerEventArgs e)
        {
            rotation += 0.05f;
            alpha -= 0.005f;

            if (alpha <= 0.1f)
                alpha = 1.0f;
        }

        private void Draw(object sender, GameTimerEventArgs e)
        {
            SharedGraphicsDeviceManager.Current.GraphicsDevice.Clear(Color.DarkCyan);
            spriteBatch.Begin();
            spriteBatch.Draw(texture2D, position, null, Color.White * alpha, rotation, origin, Vector2.One, SpriteEffects.None, 1.0f);
            spriteBatch.End();
        }

        #endregion

        public Color [] CreateColor(Color textureColor, int width, int height)
        {
            Color [] color = new Color [width * height];
            for (int i = 0; i < color.Length; i++)
                color [i] = textureColor;
            return color;
        }

        public Texture2D CreateTexture(Color color, int width, int height)
        {
            Texture2D texture2D = new Texture2D(manager.GraphicsDevice, width, height);
            texture2D.SetData(CreateColor(color, width, height));

            return texture2D;
        }

        #region Evenements XAML

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainPage = ((App)App.Current).RootFrame;
            
            Window.Current.Content = mainPage;
            Window.Current.Activate();
        }

        #endregion
    }
}

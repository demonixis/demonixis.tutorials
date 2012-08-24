using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
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
    sealed partial class App : Application
    {
        public ContentManager Content { get; set; }
        public GameServiceContainer Services { get; set; }
        public GamePage GamePage { get; set; }
        public Frame RootFrame { get; set; }

        public App()
        {
            this.InitializeComponent();
            this.InitializeXNA();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Initialisation de XNA et du SharedGraphicsManager
        /// </summary>
        private void InitializeXNA()
        {
            Services = new GameServiceContainer();
            Services.AddService(typeof(IGraphicsDeviceService), new SharedGraphicsDeviceManager());

            Content = new ContentManager(Services);
            Content.RootDirectory = "Content";
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                // On termine l'application
            }

            RootFrame = new Frame();
            if (!RootFrame.Navigate(typeof(MainPage)))
            {
                throw new Exception("Impossible de créer la page initiale");
            }

            // Initialisation de la page de jeu qui contient le code XNA
            GamePage = new GamePage();

            Window.Current.Content = RootFrame;
            Window.Current.Activate();
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // Lorsque l'utilisateur passe à une autre application
            // Mettre le jeu en pause et sauvegarder les données

            deferral.Complete();
        }
    }
}

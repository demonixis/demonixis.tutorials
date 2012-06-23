#region Using Statements
using System;
#endregion

namespace SpaceShipGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<SpaceGame>();
            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}

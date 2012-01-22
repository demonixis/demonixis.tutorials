using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameTutorial
{
    static class Program
    {
        private static SpaceGame game;

        [STAThread]
        static void Main()
        {
            game = new SpaceGame();
            game.Run();
        }
    }
}
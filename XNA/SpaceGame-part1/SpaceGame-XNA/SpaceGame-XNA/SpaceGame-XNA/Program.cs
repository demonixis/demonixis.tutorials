using System;

namespace SpaceGame_XNA
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// Point d’entrée principal pour l’application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpaceGame game = new SpaceGame())
            {
                game.Run();
            }
        }
    }
#endif
}


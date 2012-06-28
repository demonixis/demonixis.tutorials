/*
 * Crée par SharpDevelop.
 * Utilisateur: CYannick
 * Date: 28/06/2012
 * Heure: 12:57
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace AnxTesting
{
	class Program
	{
		public static void Main(string[] args)
		{
			using (AGame game = new AGame())
			{
				game.Run();
			}
		}
	}
}
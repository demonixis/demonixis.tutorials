package
{
	import flash.display.DisplayObject;
	import flash.display.Graphics;
	import flash.display.Shape;
	import flash.display.Sprite;
	
	[SWF(width="320", height="240")]
	
	public class ShapeExemple extends Sprite
	{
		private var couleurFond:uint = 0xff0000; // Rouge
		private var couleurBordure:uint = 0x000000; // Noir
		
		public function ShapeExemple()
		{
			// Dessin d'un Rectangle
			var forme:Shape = new Shape();
			forme.graphics.beginFill(couleurFond);
			forme.graphics.lineStyle(1, couleurBordure);
			// x = 30, y = 30, largeur = 60, hauteur = 40
			forme.graphics.drawRect(30, 30, 60, 40);
			forme.graphics.endFill();
			// Ajout sur la scène
			addChild(forme);
		}
	}
}

package
{
	import flash.display.DisplayObject;
	import flash.display.Graphics;
	import flash.display.Shape;
	import flash.display.GradientType;
	import flash.display.Sprite;
	import flash.geom.Matrix;
	
	[SWF(width="320", height="240")]
	
	public class ShapeExemple2 extends Sprite
	{
		private var couleurFond:uint = 0xff0000; // Rouge
		private var couleurBordure:uint = 0x000000; // Noir
		
		public function ShapeExemple2()
		{
			// taille de la zone de dessin
			var largeurStage:Number = stage.stageWidth;
			var hauteurStage:Number = stage.stageHeight;
			
			var rectangle1:Shape = creerRectangle(10, hauteurStage - 90, 120, 80, 0x00FF00);
			this.addChild(rectangle1);
			
			var rectangle2:Shape = creerRectangle(largeurStage - 130, hauteurStage - 90, 120, 80, 0x000FF0);
			this.addChild(rectangle2);
			
			var cercle:Shape;
			var couleurs:Array = new Array(0xFF38DD, 0x75FF60, 0xFF6C0A, 0x38FF59, 0xFF3851, 0xFF6C0A);
			for (var i = 0; i < 6; i++)
			{
				cercle = creerCercle(
					(i * 5) * (i * 2),				// position X
					(hauteurStage / 2) - (5 * i),	// position Y
					(5 * i),						// rayon
					couleurs[i]);					// Couleur
					
				this.addChild(cercle);
			}
		}
		
		private function creerRectangle(posX:int, posY:int, longueur:int, largeur:int, couleur:uint):Shape
		{
			var rectangle:Shape = new Shape();
			
			rectangle.graphics.beginFill(couleur);
			rectangle.graphics.drawRect(posX, posY, longueur, largeur);
			rectangle.graphics.endFill();
			
			return rectangle;
		}
		
		
		private function creerCercle(posX:int, posY:int, rayon:int, couleur:uint):Shape
		{
			var cercle:Shape = new Shape();
			cercle.graphics.beginFill(couleur);
			cercle.graphics.lineStyle(2, 0x000000);
			cercle.graphics.drawCircle(posX, posY, rayon);
			cercle.graphics.endFill();
			
			return cercle;
		}
	}
}

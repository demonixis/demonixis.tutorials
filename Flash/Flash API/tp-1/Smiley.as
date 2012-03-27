package  
{
	import flash.display.Sprite;
	import flash.display.Bitmap;
	/**
	 * ...
	 * @author ...
	 */
	public class Smiley extends Sprite 
	{
		[Embed("../assets/smiley.png")] public var SpriteImage:Class;
		
		public function Smiley(posX:int, posY:int) 
		{
			var image:Bitmap = new SpriteImage();
			var spriteScale:Number = Math.random() * 2;
			// Lissage de l'image
			image.smoothing = true;
			// Position
			this.x = posX;
			this.y = posY;
			// Echelle
			this.scaleX = spriteScale;
			this.scaleY = spriteScale;
			// Création du sprite final
			this.addChild(image);
		}	
	}
}

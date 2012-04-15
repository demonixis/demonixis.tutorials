package  
{
	import org.flixel.FlxPoint;
	import org.flixel.FlxSprite;
	import org.flixel.FlxG;
	
	public class Player extends FlxSprite 
	{
		[Embed("../assets/spritesheet-mario.png")]
		private const SpriteSheetMario:Class;
		
		public function Player() 
		{
			super(0, 0);
			
			
			loadGraphic(SpriteSheetMario, true, false, 50, 69);
			
			// Création de ses animations 
			// 1 - Nom de l'animation
			// 2 - partie de l'image à prendre pour cette animation
			// 3 - Vitesse de transition entre chaque image
			// 4 - Répétition à l'arrêt
			addAnimation("down", [0, 1, 2, 3], 10, false);
			addAnimation("left", [4, 5, 6, 7], 10, false);
			addAnimation("right", [8, 9, 10, 11], 10, false);
			addAnimation("up", [12, 13, 14, 15], 10, false);
			
			// Position au centre de l'écran
			this.x = (FlxG.width / 2) - (this.width / 2);
			this.y = (FlxG.height / 2) - (this.height / 2);
		}
		
		override public function update():void
		{
			super.update();
			
			// Déplacement du personnage
			// Mise à jour de l'animation à jouer
			if (FlxG.keys.UP)
			{
				this.y--;
				play("up");
			}
			
			if (FlxG.keys.DOWN)
			{
				this.y++;
				play("down");
			}
			
			if (FlxG.keys.LEFT)
			{
				this.x--;
				play("left");
			}
			
			if (FlxG.keys.RIGHT)
			{
				this.x++;
				play("right");
			}
		}
	}
}
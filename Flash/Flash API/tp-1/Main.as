package
{
	import adobe.utils.CustomActions;
	import flash.display.DisplayObject;
	import flash.events.MouseEvent;
	import flash.display.Sprite;
	import flash.display.Bitmap;
	import flash.events.Event;
	import flash.utils.*;
	import flash.ui.Mouse;
	import flash.media.Sound;
	
	[SWF(width="640", height="480", backgroundColor="#000000", frameRate="60")]
	
	public class Main extends Sprite
	{
		[Embed("../assets/background.png")] public var backgroundImage:Class;
		[Embed("../assets/viseur.png")] public var viseurImage:Class;
		[Embed("../assets/gunshot2.mp3")] public var sonMp3:Class;
		
		private var background:Bitmap;
		private var viseur:Bitmap;
		private var sonFusil:Sound;

		private var spriteGroup:Sprite;
		
		private var spawnTime:int = 5;
		private var previousTime:Number = 0;
		private var timeCount:Number = 0;
		
		public function Main()
		{
			Mouse.hide(); 
			
			background = new backgroundImage();
			addChild(background);
			
			spriteGroup = new Sprite();
			spriteGroup.addEventListener(MouseEvent.CLICK, spriteGroupClickHandler);
			addChild(spriteGroup);
			
			viseur = new viseurImage();
			viseur.x = stage.stageWidth / 2 - viseur.width / 2;
			viseur.y = stage.stageHeight / 2 - viseur.height / 2;
			addChild(viseur);
			
			sonFusil = new sonMp3();

			addEventListener(Event.ENTER_FRAME, onEnterFrame);
			stage.addEventListener(MouseEvent.CLICK, onMouseClickOnStage);
		}
		
		private function onMouseClickOnStage(evt:MouseEvent):void
		{
			sonFusil.play();
			trace(evt.target);	// Smiley
			trace(evt.currentTarget);	// Stage
		}
		
		private function spawnSmiley():void
		{
			var randX:Number = Math.random() * stage.stageWidth;
			var randY:Number = Math.random() * stage.stageHeight;
			var enemy:Smiley = new Smiley(randX, randY);
			enemy.addEventListener(Event.REMOVED_FROM_STAGE, onEnemyRemovedFromStage);
			spriteGroup.addChild(enemy);
		}
		
		public function spriteGroupClickHandler(evt:MouseEvent):void
		{
			var enemy:DisplayObject = spriteGroup.removeChildAt(spriteGroup.getChildIndex(DisplayObject(evt.target)));
			enemy = null;
		}
		
		public function onEnemyRemovedFromStage(evt:Event):void
		{
			var s:Smiley = Smiley(evt.target);
			s.removeEventListener(Event.REMOVED_FROM_STAGE, onEnemyRemovedFromStage);
			s = null;
		}
			
		public function onEnterFrame(evt:Event):void
		{
			var elapsedTime:Number = getTimer() / 1000;
			timeCount += elapsedTime - previousTime;
			previousTime = elapsedTime;

			if (timeCount > 2)
			{
				spawnSmiley();
				timeCount = 0;
			}
			viseur.x = mouseX - viseur.width / 2;
			viseur.y = mouseY - viseur.height / 2;
		}
	}
}

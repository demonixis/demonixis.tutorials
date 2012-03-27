package
{
	import flash.display.Sprite;
	import flash.events.MouseEvent;
	import flash.text.TextField;
	
	[SWF(width=320, height=240, backgroundColor="#ffffff")]
	
	public class EventSouris extends Sprite
	{
		private var debugText:TextField;
		
		public function EventSouris()
		{
			debugText = new TextField();
			debugText.x = 20;
			debugText.y = 20;
			debugText.width = 200;
			debugText.height = 150;
			debugText.text = "En attente d'un clic ou d'un deplacement";
			this.addChild(debugText);
			
			this.stage.addEventListener(MouseEvent.MOUSE_DOWN, onMouseDown);
			this.stage.addEventListener(MouseEvent.MOUSE_UP, onMouseUp);
			this.stage.addEventListener(MouseEvent.MOUSE_MOVE, onMouseMove);
		}
		
		private function onMouseDown(evt:MouseEvent):void
		{
			debugText.text = "Vous cliquez";
		}
		
		private function onMouseUp(evt:MouseEvent):void
		{
			debugText.text = "Vous avez fini de cliquer";
		}
		
		private function onMouseMove(evt:MouseEvent):void
		{
			debugText.text = "X: " + this.mouseX + "\nY: " + this.mouseY;
		}
	}
}

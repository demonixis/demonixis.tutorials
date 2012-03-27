package
{
	import flash.display.Sprite;
	import flash.text.TextField;
	
	[SWF(width="320", height="240", backgroundColor="#ffffff", frameRate="60")]
	
	public class BaseExemple extends Sprite
	{
		private var textHelloWorld:TextField;
		
		public function BaseExemple()
		{
			textHelloWorld = new TextField();
			textHelloWorld.text = "Hello World !!";
			textHelloWorld.x = 120;
			textHelloWorld.y = 120;
			addChild(textHelloWorld);
		}
	}
}

package
{
	import flash.display.Sprite;
	import flash.text.TextField;
	
	[SWF(width="640", height="480", backgroundColor="#FFFFFF")]
	
	public class Main extends Sprite
	{
		private var helloText:TextField;
		
		public function Main()
		{
			helloText = new TextField();
			helloText.text = "Hello Flash";
			addChild(helloText);
		}
	}
}

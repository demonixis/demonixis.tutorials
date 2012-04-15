package  
{
	import org.flixel.FlxState;
	
	public class PlayState extends FlxState 
	{
		private var _player:Player;
		
		public function PlayState() 
		{
			
		}
		
		override public function create():void
		{
			_player = new Player();
			add(_player);
		}
	}
}
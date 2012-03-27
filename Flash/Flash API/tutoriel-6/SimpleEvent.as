package  
{
	import flash.display.DisplayObject;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.text.engine.JustificationStyle;
	import flash.text.TextField;
	
	[SWF(width="320", height="240", background="#000000")]
	
	public class SimpleEvent extends Sprite 
	{
		private var monTexte:TextField;
		private var etatSprite:Boolean;
		
		public function SimpleEvent() 
		{
			etatSprite = false;
			
			// Création d'un champ texte perso
			monTexte = new TextField();
			monTexte.text = "Texte de debug";
			monTexte.x = 10;
			monTexte.y = 10;
			monTexte.width = 250;
			monTexte.height = 150;
			monTexte.addEventListener(Event.ADDED_TO_STAGE, onObjectAddedToStage);
			addChild(monTexte);
			
			// Création d'un sprite perso dans le constructeur, il n'est référencé nul par ailleurs
			// Seul le stage connais cet objet, sortie du constructeur, je ne peux plus y accéder
			var monSprite:Sprite = new Sprite();
			monSprite.graphics.beginFill(0x781111);
			monSprite.graphics.drawRect(100, 100, 65, 65);
			monSprite.graphics.endFill();
			monSprite.addEventListener(Event.ADDED_TO_STAGE, onObjectAddedToStage);
			addChild(monSprite); 
		}
		
		private function onObjectAddedToStage(evt:Event):void
		{
			monTexte.text = "Un objet a été ajouté au stage !";
			monTexte.appendText("\n\nC'est l'objet : " + evt.target.toString() + " qui a déclenché l'événement");
			
			// Si c'est un sprite qui déclanche l'événement
			// Le mot clé is permet de tester l'appartenance
			if (evt.target is Sprite)
			{
				// On récupère une instance de monSprite via un cast sur evt.target
				var s:Sprite = Sprite(evt.target);
				// On lui attache un événement de type Click
				s.addEventListener(MouseEvent.CLICK, onMonSpriteDoubleClicked);
			}
		}
		
		// Lors d'un double clique sur le sprite et suivant l'état de la variable
		// etatSprite on affiche un motif différent
		private function onMonSpriteDoubleClicked(mvt:MouseEvent):void
		{
			// Suppression de l'ancien motif
			var s:Sprite = Sprite(mvt.target);
			s.graphics.clear();
			
			if (etatSprite) // Si vrai on dessine un carré
			{
				
				s.graphics.beginFill(0x781111);
				s.graphics.drawRect(100, 100, 65, 65);
				etatSprite = false;
			}
			else			// Si faux on dessine un cercle
			{
				s.graphics.beginFill(0x00F00F);
				s.graphics.drawCircle(150, 150, 50);
				etatSprite = true;
			}
			
			s.graphics.endFill();
		}
	}
}

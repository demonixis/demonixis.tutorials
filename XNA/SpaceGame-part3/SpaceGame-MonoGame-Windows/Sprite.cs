using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace MonoGameTutorial
{
	public class Sprite
	{
        // Référence vers la classe du jeu
		private Game e_game;
		
		protected Vector2 _position;
		protected Texture2D _texture;
		protected Vector2 _speed;
		protected bool _active;
		
		public Vector2 Position
		{
			get { return _position; }
			set { _position = value; }
		}
		
		public Texture2D Texture
		{
			get { return _texture; }
			set { _texture = value; }
		}
		
		public Vector2 Speed 
		{
			get { return _speed; }
			set { _speed = value; }
		}
		
		public int Width
		{
			get { return _texture.Width; }
		}
		
		public int Height
		{
			get { return _texture.Height; }	
		}
		
		public bool Active
		{
			get { return _active; }
			set { _active = value; }
		}
		
		public Game Game 
		{
			get { return e_game; }
		}
		
		public ContentManager Content 
		{
			get { return e_game.Content; }
		}
		
		public Sprite (Game game)
		{
			e_game = game;
			_position = Vector2.Zero;
			_speed = Vector2.One;
            _active = true;
		}
		
		public Sprite (Game game, Vector2 position) 
			: this(game)
		{
			_position = position;
		}
		
		public virtual void Initialize()
		{
			_active = true;
		}
		
		public virtual void LoadContent(string textureName)
		{
			_texture = Content.Load<Texture2D>(textureName);
		}
		
		public virtual void UnloadContent()
		{
			if (_texture != null)
				_texture.Dispose();
		}
		
		public virtual void Update(GameTime gameTime)
		{
			
		}
		
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			if (_active)
				spriteBatch.Draw (_texture, _position, Color.White);	
		}
	}
}


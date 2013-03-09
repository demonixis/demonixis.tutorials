#pragma once

ref class Game1 :
public Microsoft::Xna::Framework::Game
{
private:
	Microsoft::Xna::Framework::GraphicsDeviceManager ^graphics;
	Microsoft::Xna::Framework::Graphics::SpriteBatch ^spriteBatch;

protected:
	// Initialisation de la logique
	virtual void Initialize() new = Microsoft::Xna::Framework::Game::Initialize;

	// Chargement des ressources
	virtual void LoadContent() new = Microsoft::Xna::Framework::Game::LoadContent;

	// Libération des ressources
	virtual void UnloadContent() new = Microsoft::Xna::Framework::Game::UnloadContent;

	// Mise à jour de la logique
	virtual void Update(Microsoft::Xna::Framework::GameTime ^gameTime) new = Microsoft::Xna::Framework::Game::Update;

	// Affichage à l'écran
	virtual void Draw(Microsoft::Xna::Framework::GameTime ^gameTime) new = Microsoft::Xna::Framework::Game::Draw;

public:
	Game1(void);
	virtual ~Game1(void);
};


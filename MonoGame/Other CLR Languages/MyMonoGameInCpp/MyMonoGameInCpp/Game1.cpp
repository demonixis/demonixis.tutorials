#include "Game1.h"

using namespace Microsoft::Xna::Framework;
using namespace Microsoft::Xna::Framework::Graphics;
using namespace Microsoft::Xna::Framework::Input;

Game1::Game1(void) : Game()
{
	graphics = gcnew GraphicsDeviceManager(this);
	graphics->PreferredBackBufferWidth = 800;
	graphics->PreferredBackBufferHeight = 600;
	Window->Title = "MonoGame C++/Cli";
	Content->RootDirectory = "Content";
}

Game1::~Game1(void)
{
}

void Game1::Initialize()
{
	Game::Initialize();
}

void Game1::LoadContent()
{
	Game::LoadContent();
	spriteBatch = gcnew SpriteBatch(GraphicsDevice);
}

void Game1::UnloadContent()
{
	Game::UnloadContent();
}

void Game1::Update(GameTime ^gameTime)
{
	Game::Update(gameTime);
}

void Game1::Draw(GameTime ^gameTime)
{
	GraphicsDevice->Clear(Color::CornflowerBlue);
	Game::Draw(gameTime);
}



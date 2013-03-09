Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Game1
    Inherits Game

    Private graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch

    Public Sub New()
        graphics = New GraphicsDeviceManager(Me)
        graphics.PreferredBackBufferWidth = 800
        graphics.PreferredBackBufferHeight = 600
        Window.Title = "MonoGame with Visual Basic .Net"
        Content.RootDirectory = "Content"
    End Sub

    Protected Overrides Sub Initialize()
        MyBase.Initialize()
    End Sub

    Protected Overrides Sub LoadContent()
        MyBase.LoadContent()
    End Sub

    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)

        If Keyboard.GetState().IsKeyDown(Keys.Escape) Or GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Back) Then
            Me.Exit()
        End If
    End Sub

    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.CornflowerBlue)
        MyBase.Draw(gameTime)
    End Sub
End Class


Module MyMonoGameInVBNet
    Sub Main(ByVal args() As String)
        Using game As Game1 = New Game1()
            game.Run()
        End Using
    End Sub
End Module
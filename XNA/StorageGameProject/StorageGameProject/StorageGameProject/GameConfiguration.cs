using System;

namespace StorageGameProject
{
    [Serializable]
    public class GameConfiguration
    {
        public int Width;
        public int Height;
        public bool IsFullScreen;
        public float SoundVolume;
        public float MusicVolume;

        public GameConfiguration()
        {
            Width = 1280;
            Height = 720;
            IsFullScreen = false;
            SoundVolume = 0.7f;
            MusicVolume = 0.9f;
        }

        public GameConfiguration(int width, int height, bool fullscreen, float soundVolume, float musicVolume)
        {
            Width = width;
            Height = height;
            IsFullScreen = fullscreen;
            SoundVolume = soundVolume;
            MusicVolume = musicVolume;
        }
    }
}

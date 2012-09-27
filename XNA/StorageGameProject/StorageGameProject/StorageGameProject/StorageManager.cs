using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;

namespace StorageGameProject
{
    public class StorageManager
    {
        private const string ConfigurationFileName = "game.config";
        private StorageDevice _storageDevice;

        public StorageManager()
        {
            IAsyncResult result =  StorageDevice.BeginShowSelector(PlayerIndex.One, null, null);
            _storageDevice = StorageDevice.EndShowSelector(result);
        }

        public GameConfiguration LoadGameConfiguration()
        {
            StorageContainer container = GetContainer("config");

            // Pas de sauvegarde
            if (!container.FileExists(ConfigurationFileName))
                return new GameConfiguration();

            // La sauvegarde existe
            Stream stream = container.OpenFile(ConfigurationFileName, FileMode.Open);

            XmlSerializer serializer = new XmlSerializer(typeof(GameConfiguration));

            GameConfiguration config = (GameConfiguration)serializer.Deserialize(stream);

            stream.Close();

            // Ne pas oublier de fermer le flux ET le container
            container.Dispose();

            return config;
        }


        public void SaveGameConfiguration(GameConfiguration gameConfig)
        {
            StorageContainer container = GetContainer("Config");

            if (container.FileExists(ConfigurationFileName))
                container.DeleteFile(ConfigurationFileName);

            Stream stream = container.CreateFile(ConfigurationFileName);

            XmlSerializer serializer = new XmlSerializer(typeof(GameConfiguration));
            serializer.Serialize(stream, gameConfig);
            stream.Close();

            container.Dispose();
        }

        private StorageContainer GetContainer(string name)
        {
            IAsyncResult result = _storageDevice.BeginOpenContainer(name, null, null);
            result.AsyncWaitHandle.WaitOne();
            
            StorageContainer container = _storageDevice.EndOpenContainer(result);
            result.AsyncWaitHandle.Close();

            return container;
        }
    }
}

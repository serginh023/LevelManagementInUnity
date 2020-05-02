using System.Collections;
using System.Collections.Generic;

namespace levelmanagement.data
{
    public class SaveData
    {
        public string playerName;
        private readonly string defaultPlayerName = "Player";

        public float masterVolume;
        public float SFXVolume;
        public float musicVolume;

        public string hashValue;

        public SaveData()
        {
            playerName = defaultPlayerName;
            masterVolume = 0f;
            SFXVolume = 0f;
            musicVolume = 0f;
            hashValue = string.Empty;
        }

    }
}
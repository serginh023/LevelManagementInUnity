using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace levelmanagement.data
{
    public class DataManager : MonoBehaviour
    {
        private SaveData _saveData;
        private JSONSaver _jsonSaver;

        public float MasterVolume { get { return _saveData.masterVolume;} set { _saveData.masterVolume = value; } }

        public float SFXVolume { get { return _saveData.SFXVolume; } set { _saveData.SFXVolume = value; } }

        public float MusicVolume { get { return _saveData.musicVolume; } set { _saveData.musicVolume = value; } }

        public string PlayerName { get { return _saveData.playerName; } set { _saveData.playerName = value; } }

        private void Awake()
        {
            _saveData = new SaveData();
            _jsonSaver = new JSONSaver();
        }

        public void Save()
        {
            _jsonSaver.Save(_saveData);
        }

        public void Load()
        {
            _jsonSaver.Load(_saveData);
        }
    }
}
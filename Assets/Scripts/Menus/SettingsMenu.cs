using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using levelmanagement.data;

namespace levelmanagement
{
    public class SettingsMenu : Menu<SettingsMenu>
    {
        [SerializeField]
        private Slider _masterVolumeSlider;

        [SerializeField]
        private Slider _SFXVolumeSlider;

        [SerializeField]
        private Slider _musicVolumeSlider;

        private DataManager _dataManager;

        protected void Awake()
        {
            base.Awake();
            _dataManager = FindObjectOfType<DataManager>();
            
        }

        private void Start()
        {
            LoadData();
        }

        public void OnMasterVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MasterVolume = volume;
            }
        }

        public void OnSFXVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.SFXVolume = volume;
            }
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MusicVolume = volume;
            }
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();

            if(_dataManager!=null)
                _dataManager.Save();
        }

        public void LoadData()
        {
            if(_masterVolumeSlider == null || _SFXVolumeSlider == null || _musicVolumeSlider == null)
            {
                return;
            }
            _dataManager.Load();
            _masterVolumeSlider.value = _dataManager.MasterVolume;
            _SFXVolumeSlider.value = _dataManager.SFXVolume;
            _musicVolumeSlider.value = _dataManager.MusicVolume;
            //_masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
            //_SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            //_musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");



        }
    }
}
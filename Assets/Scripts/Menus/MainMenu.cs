using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;
using levelmanagement.data;
using UnityEngine.UI;

namespace levelmanagement
{
    public class MainMenu : Menu<MainMenu>
    {

        private DataManager _dataManager;
        [SerializeField]
        private InputField _inputFieldPlayerName;

        public void OnPlayPressed()
        {
            //StartCoroutine(OnPlayPressedRoutine());
            LevelSelectorMenu.Open();
        }

        //IEnumerator OnPlayPressedRoutine()
        //{
        //    TransitionFader.PlayTransition(_transitionFaderPrefab);

        //    yield return new WaitForSeconds(_playDelay);

        //    LevelLoader.LoadNextLevel();

        //    GameMenu.Open();
        //}

        public void OnSettingsPressed()
        {
            SettingsMenu.Open();
        }

        public void OnCreditsPressed()
        {
            CreditsMenu.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }

        private void LoadData()
        {
            if (_dataManager != null && _inputFieldPlayerName != null)
            {
                _dataManager.Load();
                _inputFieldPlayerName.text = _dataManager.PlayerName;
            }
        }

        private void Start()
        {
            LoadData();
        }
        private void Awake()
        {
            base.Awake();
            _dataManager = FindObjectOfType<DataManager>();
        }


        public void OnPlayerNameChanged(string name)
        {
            if( _dataManager != null)
            {
                _dataManager.PlayerName = name;
            }
        }

        public void OnPlayerNameEndEdit()
        {
            if(_dataManager != null)
            {
                _dataManager.Save();
            }
        }
    }
}
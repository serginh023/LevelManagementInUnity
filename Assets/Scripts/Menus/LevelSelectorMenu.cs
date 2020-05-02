using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using levelmanagement.missions;

namespace levelmanagement
{
    [RequireComponent(typeof(MissionSelector))]
    public class LevelSelectorMenu : Menu<LevelSelectorMenu>
    {

        #region INSPECTOR
        [SerializeField] protected Text _nameText;
        [SerializeField] protected Text _descriptionText;
        [SerializeField] protected Image _previewImage;
        [SerializeField] protected float _delay = .5f;
        [SerializeField] protected TransitionFader _playTransitionFaderPrefab;

        #endregion

        #region PROPERTIES
        protected MissionSelector _missionSelector;
        protected MissionSpecs _currentMission;
        #endregion

        protected override void Awake()
        {
            base.Awake();
            _missionSelector = GetComponent<MissionSelector>();
        }

        private void OnEnable()
        {
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            _currentMission = _missionSelector.GetCurrentMission();

            if (_currentMission != null)
            {
                _nameText.text = _currentMission.Name;
                _descriptionText.text = _currentMission.Description;
                _previewImage.sprite = _currentMission.Image;
                _previewImage.color = Color.white;
            }
        }


        public void OnNextPressed()
        {
            _missionSelector.IncrementIndex();
            UpdateInfo();
        }

        public void OnPreviousPressed()
        {
            _missionSelector.DecrementIndex();
            UpdateInfo();
        }


        public void OnPlayPressed()
        {
            StartCoroutine(PlayMisssionRoutine(_currentMission?.SceneName));
        }

        private IEnumerator PlayMisssionRoutine(string sceneName)
        {
            TransitionFader.PlayTransition(_playTransitionFaderPrefab);
            LevelLoader.LoadLevel(sceneName);
            yield return new WaitForSeconds(_delay);
            GameMenu.Open();
        }

    }
}
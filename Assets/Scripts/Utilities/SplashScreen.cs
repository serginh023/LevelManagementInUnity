using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace levelmanagement
{
    [RequireComponent(typeof(ScreenFader))]
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField]
        private ScreenFader _screenFader;
        
        [SerializeField]
        private float _delay = 1f;

        private void Awake()
        {
            _screenFader = GetComponent<ScreenFader>();
        }

        private void Start()
        {
            _screenFader.FadeOn();
        }

        public void FadeAndLoad()
        {
            StartCoroutine(FadeAndLoadCoroutine());
        }

        private IEnumerator FadeAndLoadCoroutine()
        {
            yield return new WaitForSeconds(_delay);

            _screenFader.FadeOff();

            yield return new WaitForSeconds(_screenFader.FadeOffDuration);

            LevelLoader.LoadMainMenuLevel();

            Destroy(gameObject);

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace levelmanagement
{

    public class WinMenu : Menu<WinMenu>
    {
        [SerializeField]
        private int mainMenuIndex = 0;
        public void OnNextLevelPressed()
        {
            Time.timeScale = 1f;
            base.OnBackPressed();
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(mainMenuIndex);
            MainMenu.Open();
        }

        public void OnQuitPressed()
        {
            Application.Quit();
        }
    }

}


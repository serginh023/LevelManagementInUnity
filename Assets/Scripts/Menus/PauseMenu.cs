using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace levelmanagement
{

    public class PauseMenu : Menu<PauseMenu>
    {
        public void OnResumePressed()
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
            LevelLoader.LoadMainMenuLevel();
            MainMenu.Open();
        }

        public void OnQuitPressed()
        {
            Application.Quit();
        }
    }

}


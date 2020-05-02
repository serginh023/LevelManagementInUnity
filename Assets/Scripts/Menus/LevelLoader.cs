using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace levelmanagement
{
    public class LevelLoader : MonoBehaviour
    {
        public static int mainMenuIndex = 1;


        public static void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("LOADLEVEL LoadLevel Error: invalid scene specified!");
            }
        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (levelIndex == mainMenuIndex)
                {
                    MainMenu.Open();
                }
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LOADLEVEL LoadLevel Error: invalid scene specified!");
            }
        }

        public static void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }

        public static void LoadNextLevel()
        {
            int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1)
                % SceneManager.sceneCountInBuildSettings;
            nextSceneIndex = Mathf.Clamp(nextSceneIndex, mainMenuIndex, nextSceneIndex);
            LoadLevel(nextSceneIndex);
        }

        public static void LoadMainMenuLevel()
        {
            LoadLevel(mainMenuIndex);
        }
    }
}
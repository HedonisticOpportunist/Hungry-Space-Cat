using UnityEngine;
using UnityEngine.SceneManagement;

/* Based on the below, with minor modifications 
// @Credit: https://blog.insane.engineer/post/unity_button_load_scene/ for the general scene-loading script
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/LevelManager.cs for the idea to move all the code to a single script 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class SceneLoaderManager : MonoBehaviour
{ 
    void FixedUpdate()
    {
        PauseAndReturnToMenu();
    }
        public void LoadUFOGame()
    {
        SceneManager.LoadScene("UFOGame");
    }

    #region LoadMenuScenes

    public void PauseAndReturnToMenu()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;

        if (sceneNumber != 0)
        {
            if (Input.GetKey(KeyCode.Escape))
            { 
                SceneManager.LoadScene("MenuScene");
            }
        }
    }

    public void LoadAdoptACatSite()
    {
        Application.OpenURL("https://hedonisticopportunist.github.io/Cats-in-Neath/");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("GameSettings");
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("Play");
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    #endregion LoadMenuScenes

    #region LoadGame

    public void LoadEasyMode()
    {
        SceneManager.LoadScene("UFOGameEasy");
    }

    public void LoadNextLevel()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;

        if (sceneNumber >= 4 && sceneNumber <= 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (sceneNumber >= 8 && sceneNumber <= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else
        {
            PauseAndReturnToMenu();
        }
    }

    public void ExitGame()
    {
        /* Based on with modifications: 
        // @Credit: https://gamedevbeginner.com/how-to-quit-the-game-in-unity/ 
        // Prepreprocessor directives allow for the running of different code depending on conditions 
        */

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    #endregion LoadGame
}

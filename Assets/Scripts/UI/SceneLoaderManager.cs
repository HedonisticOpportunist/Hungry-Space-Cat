using UnityEngine;
using UnityEngine.SceneManagement;

/* Based on the below, with minor modifications 
// @Credit: https://blog.insane.engineer/post/unity_button_load_scene/ for the general scene-loading script
// @Credit: https://medium.com/geekculture/loading-scenes-in-unity-98e446756497 for reloading a previous scene. 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/LevelManager.cs for the idea to move all the code to a single script 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class SceneLoaderManager : MonoBehaviour
{
    // OTHER GAME SCRIPTS 
    HealthKeeper _healthKeeper;
    ScoreKeeper _scoreKeeper;
    FadeAnimation _fadeAnimation;

    void Awake()
    {
        _healthKeeper = FindObjectOfType<HealthKeeper>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _fadeAnimation = FindObjectOfType<FadeAnimation>();
    }

    #region LoadMenuScenes

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
        AudioListener.pause = false;
        Time.timeScale = 1f;
        _scoreKeeper.ResetScore();
        _healthKeeper.ResetLives();
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
        _fadeAnimation.SetUpFadeAnimation();
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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex >= 4 && currentSceneIndex <= 7)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        else if (currentSceneIndex >= 8 && currentSceneIndex <= 10)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        else
        {
            LoadMenuScene();
        }
    }

    public void ResetGame()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (buildIndex >= 4)
        {
            _scoreKeeper.ResetScore();
            _healthKeeper.ResetLives();
            SceneManager.LoadScene(buildIndex - 1);
        }
    }

    public void LoadUFOGame()
    {
        SceneManager.LoadScene("UFOGame");
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
        _fadeAnimation.SetUpFadeAnimation();
        Application.Quit();
    }

    #endregion LoadGame
}

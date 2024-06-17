using UnityEngine;
using UnityEngine.SceneManagement;

/* Based on the below, with minor modifications:  
// @Credit: https://blog.insane.engineer/post/unity_button_load_scene/ for the general scene-loading script. 
// @Credit: https://medium.com/geekculture/loading-scenes-in-unity-98e446756497 for reloading a previous scene. 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/LevelManager.cs for the idea to move all the code to a single script. 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class SceneLoaderManager : MonoBehaviour
{
    // OTHER GAME SCRIPTS 
    HealthKeeper _healthKeeper;
    ScoreKeeper _scoreKeeper;
    FadeAnimation _fadeAnimation;

    // SCENES
    readonly string[] _easyModeScenes = {
    "UFOGameEasy",
    "HamburgerGameEasy",
    "GhostGameEasy"
  };
    readonly string[] _normalModeScenes = {
    "UFOGame",
    "HamburgerGame",
    "GhostGame",
    "PlanetGame",
    "FollowingSpaceshipGame",
    "AsteroidsGame"
  };
    readonly string[] _menuScenes = {
    "MainMenu",
    "Play",
    "Instructions",
    "GameSettings",
    "GameOver"
  };

    void Awake()
    {
        _healthKeeper = FindObjectOfType<HealthKeeper>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _fadeAnimation = FindObjectOfType<FadeAnimation>();
    }

    #region LoadMenuScenes

    public void LoadAdoptACatSite() => Application.OpenURL("https://hedonisticopportunist.github.io/Cats-in-Neath/");

    public void LoadInstructions() => SceneManager.LoadScene(_menuScenes[2]);

    public void LoadMenuScene()
    {
        PauseMenu.isPaused = false; 
        AudioListener.pause = false;
        Time.timeScale = 1f;
        _scoreKeeper.ResetScore();
        _healthKeeper.ResetLives();
        SceneManager.LoadScene(_menuScenes[0]);
    }

    public void LoadSettingsScene() => SceneManager.LoadScene(_menuScenes[3]);

    public void LoadPlayScene() => SceneManager.LoadScene(_menuScenes[1]);

    public void LoadEndScene()
    {
        PlayerPrefs.SetInt("PreviousScene", SceneManager.GetActiveScene().buildIndex); 
        _fadeAnimation.SetUpFadeAnimation();
        SceneManager.LoadScene(_menuScenes[4]);
    }

    #endregion LoadMenuScenes

    #region LoadGame

    public void LoadEasyMode() => SceneManager.LoadScene(_easyModeScenes[0]);

    public void ResetGame()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (buildIndex >= 4)
        {
            _scoreKeeper.ResetScore();
            _healthKeeper.ResetLives();
            // @Credit: https://www.youtube.com/watch?v=faYY3BNmAeA for using player prefs to load a previous scene. 
            SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousScene"));
        }

    }

    public void LoadNormalMode() => SceneManager.LoadScene(_normalModeScenes[0]);

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

    #region LoadLevels

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex >= 4 && currentSceneIndex <= 9)
        {
            LoadNormalLevels(currentSceneIndex);
        }
        else if (currentSceneIndex >= 10 && currentSceneIndex <= 12)
        {
            LoadEasyLevels(currentSceneIndex);
        }
        else
        {
            LoadMenuScene();
        }

    }

    void LoadNormalLevels(int currentSceneIndex)
    {
        if (currentSceneIndex == 4)
        {
            _fadeAnimation.SetUpFadeAnimation();
            SceneManager.LoadScene(_normalModeScenes[1]);
        }
        else if (currentSceneIndex == 5)
        {
            _fadeAnimation.SetUpFadeAnimation();
            SceneManager.LoadScene(_normalModeScenes[2]);
        }
        else if (currentSceneIndex == 6)
        {
            _fadeAnimation.SetUpFadeAnimation();
            SceneManager.LoadScene(_normalModeScenes[3]);
        }
        else if (currentSceneIndex == 7)
        {
            _fadeAnimation.SetUpFadeAnimation();
            SceneManager.LoadScene(_normalModeScenes[4]);
        }
        else if (currentSceneIndex == 8)
        {
            _fadeAnimation.SetUpFadeAnimation();
            SceneManager.LoadScene(_normalModeScenes[5]);
        }
        else
        {
            LoadEndScene();
        }
    }

    void LoadEasyLevels(int currentSceneIndex)
    {
        if (currentSceneIndex == 10)
        {
            _fadeAnimation.SetUpFadeAnimation();
            SceneManager.LoadScene(_easyModeScenes[1]);
        }
        else if (currentSceneIndex == 11)
        {
            _fadeAnimation.SetUpFadeAnimation();
            SceneManager.LoadScene(_easyModeScenes[2]);
        }
        else
        {
            LoadEndScene();
        }
    }

    #endregion LoadLevels
}
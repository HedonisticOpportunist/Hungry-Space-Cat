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

    // SCENES
    readonly string[] _easyModeScenes = { "UFOGameEasy", "HamburgerGameEasy", "GhostGameEasy" };
    readonly string[] _normalModeScenes = { "UFOGame", "HamburgerGame", "GhostGame", "PlanetScene" };
    readonly string[] _menuScenes = { "MenuScene", "Play", "Instructions", "GameSettings", "EndScene" };

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
        SceneManager.LoadScene(_menuScenes[1]);
    }

    public void LoadMenuScene()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        _scoreKeeper.ResetScore();
        _healthKeeper.ResetLives();
        SceneManager.LoadScene(_menuScenes[0]);
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene(_menuScenes[3]);
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(_menuScenes[1]);
    }

    public void LoadEndScene()
    {
        _fadeAnimation.SetUpFadeAnimation();
        SceneManager.LoadScene(_menuScenes[4]);
    }

    #endregion LoadMenuScenes

    #region LoadGame

    public void LoadEasyMode()
    {
        SceneManager.LoadScene(_easyModeScenes[0]);
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
        SceneManager.LoadScene(_normalModeScenes[0]);
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

    #region LoadLevels

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex >= 4 && currentSceneIndex <= 7)
        {
            LoadNormalLevels(currentSceneIndex);
        }

        else if (currentSceneIndex >= 8 && currentSceneIndex <= 10)
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

        else
        {
            LoadEndScene();
        }
    }

    void LoadEasyLevels(int currentSceneIndex)
    {
        if (currentSceneIndex == 8)
        {
            _fadeAnimation.SetUpFadeAnimation();
            SceneManager.LoadScene(_easyModeScenes[1]);
        }
        else if (currentSceneIndex == 9)
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

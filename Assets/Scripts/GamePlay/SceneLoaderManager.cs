using UnityEngine;
using UnityEngine.SceneManagement;

/* Based on the below, with minor modifications 
// @Credit: https://blog.insane.engineer/post/unity_button_load_scene/ for the general scene loading script
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/LevelManager.cs for the idea to move all the code to a single script 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class SceneLoaderManager : MonoBehaviour
{
    static SceneLoaderManager instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ExitGame()
    {
        /* Based on with modifications: 
        // @Credit: https://gamedevbeginner.com/how-to-quit-the-game-in-unity/ 
        // Prepreprocessor directives allow for running of different code depending on conditions 
        */
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

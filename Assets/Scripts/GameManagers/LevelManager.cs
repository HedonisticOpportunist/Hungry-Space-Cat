using UnityEngine;
using UnityEngine.SceneManagement;

/* Based on the below, with minor modifications 
// @Credit: https://blog.insane.engineer/post/unity_button_load_scene/ for the general scene loading script
// @Credit: https://www.gamedev.tv/courses/1394720/lectures/33934239 for the idea to move all the code to a single script 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
// Note that the video is not accessible unless enrolled to the above 
*/

public class LevelManager : MonoBehaviour
{
    // PUBLIC METHODS 
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        /* Based on, with modifications: 
        // @Credit: https://gamedevbeginner.com/how-to-quit-the-game-in-unity/ 
        // Prepreprocessor directives allow for running of different code depending on conditions 
        */
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

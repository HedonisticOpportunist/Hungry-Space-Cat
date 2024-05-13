using UnityEngine;

/* Based on the below, with minor modifications:
// @Credit: https://www.youtube.com/watch?v=9dYDBomQpBQ
// @Credit: https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/ for pausing the audio. 
*/
public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] GameObject pauseMenu;
    public static bool isPaused;

    void Start() => pauseMenu.SetActive(false);

    void Update() => ActivatePause();

    void ActivatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false;
    }
}
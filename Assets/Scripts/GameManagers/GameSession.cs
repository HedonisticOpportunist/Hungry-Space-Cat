using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int numberOfCatLives = 9;
    [SerializeField] int score = 0; 
    [SerializeField] TextMeshProUGUI catLivesText;
    [SerializeField] TextMeshProUGUI scoreText;

    // PUBLIC METHODS

    public void UpdateGameScore(int pointsScored)
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/35228410
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */
        score += pointsScored;
        scoreText.text = "Score: " + score.ToString();
    }

    public void HandleCatDeath()
    {
       /* Based on the below, with minor modifications 
       // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34966898
       // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
       // Note that the video is not accessible unless enrolled to the above 
       */

       if (numberOfCatLives > 1)
        {
            RemoveCatLives();
        }

       else
        {
            Debug.Log("Game over");
        }

    }

    // PRIVATE METHODS
    void Awake()
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34966898
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/35228410
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */
        catLivesText.text = "Cat Lives: " + numberOfCatLives.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    void ResetGameSession()
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34966898
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */
        FindObjectOfType<SceneLoaderManager>().LoadGame();
        Destroy(gameObject);
    }

    void RemoveCatLives()
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34966898
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
         */
        numberOfCatLives -= 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        catLivesText.text = "Cat Lives: " + numberOfCatLives.ToString();
    }
}

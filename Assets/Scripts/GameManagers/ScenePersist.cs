using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    // PRIVATE METHODS
    void Awake()
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/35228435
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */
        int numberOfScenePersists = FindObjectsOfType<ScenePersist>().Length;

        if (numberOfScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34966901
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */
        if (other.CompareTag("Cat"))
        {
            Destroy(gameObject);
        }
    }
}

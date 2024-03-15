using System;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField] float yPosition;
    [SerializeField] float floatStrength = 0.6f;
    [SerializeField] float speed = 2.4f;
    [SerializeField] int pointsForFishEaten = 10;
    bool wasEaten = false;

    // PRIVATE METHODS

    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        /* Based on the following with modifications
        // @Credit: https://gamedev.stackexchange.com/questions/96878/how-to-animate-objects-with-bobbing-up-and-down-motion-in-unity
         */

        transform.position = new Vector3(transform.position.x,
            yPosition + ((float)Math.Sin(Time.time * speed) * floatStrength),
            transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34966901 for the game object deletion.  
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/35228410 for updating the score when a fish has been eaten. 
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */
        if (other.CompareTag("Cat") && !wasEaten)
        {
            wasEaten = true;
            FindObjectOfType<GameSession>().UpdateGameScore(pointsForFishEaten);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}

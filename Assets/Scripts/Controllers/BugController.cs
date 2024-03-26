using System;
using UnityEngine;

public class BugController : MonoBehaviour
{
    [SerializeField] float yPosition;
    [SerializeField] float floatStrength = 0.6f;
    [SerializeField] float speed = 2.4f;
    [SerializeField] int pointsForBugsEaten = 10;

    // OTHER VARIABLES

    bool wasEaten = false;
    AudioPlayer audioPlayer;

    // PRIVATE METHODS

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        /* Based on the following, with modifications:
        // @Credit: https://gamedev.stackexchange.com/questions/96878/how-to-animate-objects-with-bobbing-up-and-down-motion-in-unity
        */

        transform.position = new Vector3(transform.position.x,
            yPosition + ((float)Math.Sin(Time.time * speed) * floatStrength),
            transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /* Based on the below, with modifications and additions: 
        // @Credit: https://gitlab.com/GameDevTV/unity2d-v3/tilevania/-/blob/master/Assets/Scripts/GameSession.cs for the game object deletion.  
        // @Credit: https://gitlab.com/GameDevTV/unity2d-v3/tilevania/-/blob/master/Assets/Scripts/CoinPickup.cs for updating the score when a fish has been eaten. 
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        */

        if (other.CompareTag("SpaceCat") && !wasEaten)
        {
            wasEaten = true;
            audioPlayer.PlayPickupClip();
            FindObjectOfType<ScoreKeeper>().ModifyScore(pointsForBugsEaten);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (other.CompareTag("Bug"))
        {
            // This avoids the object overlapping with itself while spawning. 
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}

using UnityEngine;

public class WolfController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    new Rigidbody2D rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() => rigidbody.velocity = new Vector2(speed, 0);

    void OnTriggerEnter2D(Collider2D other)
    {
        /* Based on the below, with modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34692227
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */

        if (other.CompareTag("Wall"))
        {
            speed = -speed;
            FlipWolf();
        }
    }

    void FlipWolf()
    {
        /* Based on the below, with modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34692227
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */
        transform.localScale = new Vector2((-Mathf.Sign(rigidbody.velocity.x) / 2.0f), 0.5f);
    }
}

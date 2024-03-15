using UnityEngine;
using UnityEngine.InputSystem;


public class CatController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] Rigidbody2D body;
    [SerializeField] float moveLimiter = 0.7f;
    [SerializeField] float speed = 20.0f;
    [SerializeField] bool isAlive = true; 
    private float horizontal;
    private float vertical;

    // PRIVATE METHODS //
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    void Update()
    {
        /* Based on the below:
        // @Credit: https://www.gamedev.tv/courses/1111834/lectures/27830511
        // Part of the https://www.gamedev.tv/p/complete-c-unity-game-developer-3d-online-course-2020 course
        // Note that the video is not accessible unless enrolled to the course 
        */
        horizontal = movement.ReadValue<Vector2>().x;
        vertical = movement.ReadValue<Vector2>().y;
    }

    private void FixedUpdate()
    {

        /* Based on the below, with modifications and deletions
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34379850 
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */

        if (isAlive)
        {
            MoveCat();
            FlipCat();

        }
        else
        {
            return;
        }
    }
    void MoveCat()
    {
        /* Based on the below, with modifications 
        // @Credit: https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
        */

        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void FlipCat()
    {
        /* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34379850 
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        // Note that the video is not accessible unless enrolled to the above 
        */

        bool catHasHorizontalSpeed = Mathf.Abs(body.velocity.x) > Mathf.Epsilon; //  Math.f.Epsilon is the smallest value a float can have, different from zero.

        if (catHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(body.velocity.x), 1f); // Return value is 1 when f is positive or zero, -1 when f is negative 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wolf"))
        {
            isAlive = false;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

/* Based on the below, with modifications, additions and deletions:
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/tilevania/-/blob/master/Assets/Scripts/PlayerMovement.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class SpaceCatController : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] bool isAlive = true;
    [SerializeField] float moveLimiter = 0.7f;

    // OTHER VARIABLES
    AudioPlayer audioPlayer;
    private float horizontal;
    private float vertical;
    Rigidbody2D body;
    Vector2 minimumBounds;
    Vector2 maximumBounds;

    // PRIVATE METHODS //


    void Start()
    {
        InitBounds();
    }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void FixedUpdate()
    {
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

    void OnMove(InputValue value)
    {
        horizontal = value.Get<Vector2>().x;
        vertical = value.Get<Vector2>().y;
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

        /* Based on the below, with modifications 
        // @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/Player.cs for setting up boundaries. 
        */

        Vector2 newPos = new()
        {
            x = Mathf.Clamp(transform.position.x, minimumBounds.x, maximumBounds.x),
            y = Mathf.Clamp(transform.position.y, minimumBounds.y, maximumBounds.y)
        };

        transform.position = newPos;

    }

    void FlipCat()
    {
        transform.localScale = new Vector2((-Mathf.Sign(body.velocity.x) / 2.1f), 0.4f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            audioPlayer.PlayCatDamageClip();
            CatDeath();
        }

    }

    void CatDeath()
    {
        isAlive = false;
        FindObjectOfType<GameSession>().HandleCatDeath();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minimumBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maximumBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
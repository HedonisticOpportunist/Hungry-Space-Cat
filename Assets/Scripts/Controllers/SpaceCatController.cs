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
    ControllerHelper controllerHelper;
    HealthKeeper healthKeeper;

    // PRIVATE METHODS //

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        controllerHelper = FindObjectOfType<ControllerHelper>();
        healthKeeper = FindObjectOfType<HealthKeeper>();

    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            MoveCat();

            if (controllerHelper != null)
            {
                controllerHelper.FlipSprite(transform, body);
            }

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
        controllerHelper.ClampSpriteMovements(transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            audioPlayer.PlayCatDamageClip();
            healthKeeper.TakeDamage();

            if (healthKeeper.GetLives() <= 0)
            {
                CatDeath();
            }
        }
    }

    void CatDeath()
    {
        isAlive = false;
        //SceneLoaderManager.LoadGameOver();
    }
}
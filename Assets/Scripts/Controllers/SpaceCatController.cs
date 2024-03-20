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
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;


    // OTHER VARIABLES
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;



    // PRIVATE METHODS //

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InitBounds();
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
        rawInput = value.Get<Vector2>();
    }

    void MoveCat()
    {
        Vector2 delta = speed * Time.deltaTime * rawInput;

        /* Based on the below, with modifications:
        // @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/Player.cs for setting up boundaries. 
        */
        Vector2 clampedVector = new()
        {
            x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight),
            y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop)

        };

        transform.position = clampedVector;
    }

    void FlipCat()
    {
        /* Based on the below, with modifications: 
        // @Credit: https://danielkirwan.medium.com/flip-a-2d-sprite-in-unity-a365dc768553
        */
        if (rawInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
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
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

}


using UnityEngine;

public class ControllerHelper : MonoBehaviour
{
    Vector2 minimumBounds;
    Vector2 maximumBounds;
    HealthKeeper healthKeeper;

    void Awake()
    {
        healthKeeper = FindObjectOfType<HealthKeeper>();
    }

    public void FlipSprite(Transform transform, Rigidbody2D body)
    {
        transform.localScale = new Vector2((-Mathf.Sign(body.velocity.x) / 2.0f), 0.4f);
    }

    void Start()
    {
        InitialiseBounds();
    }

    void InitialiseBounds()
    {
        Camera mainCamera = Camera.main;
        minimumBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maximumBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    public void ClampSpriteMovements(Transform transform)
    {
        /* Based on the below, with modifications 
        // @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/Player.cs for setting up boundaries. 
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        */

        Vector2 newPos = new()
        {
            x = Mathf.Clamp(transform.position.x, minimumBounds.x, maximumBounds.x),
            y = Mathf.Clamp(transform.position.y, minimumBounds.y, maximumBounds.y)
        };

        transform.position = newPos;
    }

    public void FollowPlayer(Transform target, Transform transform, float speed, int lives)
    {
        /* Based on the below, with modifications, additions and deletions:
        // @Credit: https://www.youtube.com/watch?v=2SXa10ILJms for the AI follow player movement. 
        */

        if (target != null && lives != 0)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize(); // Keeps the length of the direction to one, thus constant. 
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // This allows for smoother rotation. 
            transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));
        }

        else
        {
            return;
        }
    }
}

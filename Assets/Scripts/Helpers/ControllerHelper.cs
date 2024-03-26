
using UnityEngine;

public class ControllerHelper : MonoBehaviour
{
    [SerializeField] Transform spaceCat;
    Vector2 minimumBounds;
    Vector2 maximumBounds;

    public void FlipSprite(Transform transform, Rigidbody2D body)
    {
        transform.localScale = new Vector2((-Mathf.Sign(body.velocity.x) / 2.0f), 0.4f);
    }
    public void ClampSpriteMovements(Transform transform)
    {
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

    void Start()
    {
        spaceCat = FindObjectOfType<SpaceCatController>().transform;

        InitBounds();


    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minimumBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maximumBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    public void FollowPlayer(Transform transform, float speed, float rotationSpeed, Vector3 minDistance)
    {
        /* Based on the below, with modifications, additions and deletions:
        // @Credit: https://www.youtube.com/watch?v=jlklOd8PEQE for the AI follow player movement. 
        */

        if (spaceCat != null)
        {

            Vector3 direction = transform.position - spaceCat.position;

            if (direction.x > minDistance.x && direction.y > minDistance.y)
            {
                transform.up = Vector3.MoveTowards(transform.up, direction, rotationSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, spaceCat.position, speed * Time.deltaTime);
            }
        }

        else
        {
            return;
        }
    }
}

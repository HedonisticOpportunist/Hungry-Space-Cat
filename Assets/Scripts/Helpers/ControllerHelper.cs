
using UnityEngine;

public class ControllerHelper : MonoBehaviour
{
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
        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minimumBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maximumBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    public void FollowPlayer(Transform target, Transform transform, float speed)
    {
        /* Based on the below, with modifications, additions and deletions:
        // @Credit: https://www.youtube.com/watch?v=2SXa10ILJms for the AI follow player movement. 
        */

        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));
        }

        else
        {
            return;
        }
    }

    public void ChangeSprite(SpriteRenderer spriteRenderer, Sprite newSprite)
    {
        /* Based on the below, with modifications, additions and deletions:
        // @Credit: https://gamedevbeginner.com/how-to-change-a-sprite-from-a-script-in-unity-with-examples/#change_sprite_from_script
        */

        spriteRenderer.sprite = newSprite;
    }
}

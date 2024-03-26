using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerHelper : MonoBehaviour
{
    Vector2 minimumBounds;
    Vector2 maximumBounds;

    // PUBLIC METHODS 

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

    // PRIVATE METHODS

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

   

}

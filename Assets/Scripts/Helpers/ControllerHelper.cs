using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerHelper : MonoBehaviour
{
    Vector2 _minimumBounds;
    Vector2 _maximumBounds;

    void Start() => InitialiseBounds();

    #region Boundaries

    void InitialiseBounds()
    {
        Camera mainCamera = Camera.main;
        _minimumBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maximumBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public void ClampSpriteMovements(Transform transform)
    {
        /* Based on the below, with modifications 
        // @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/Player.cs for setting up boundaries. 
        // Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
        */

        Vector2 newPos = new()
        {
            x = Mathf.Clamp(transform.position.x, _minimumBounds.x, _maximumBounds.x),
            y = Mathf.Clamp(transform.position.y, _minimumBounds.y, _maximumBounds.y)
        };

        transform.position = newPos;
    }

    #endregion Boundaries

    #region Sprite Behaviour

    public void FlipSprite(Transform transform, Rigidbody2D body) => transform.localScale = new Vector2((-Mathf.Sign(body.velocity.x) / 2.0f), 0.4f);

    #endregion Sprite Behaviour

    #region Interactions

    public void FollowPlayer(Transform target, Transform transform, float speed, int lives)
    {
        /* Based on the below, with modifications, additions and deletions:
        // @Credit: https://www.youtube.com/watch?v=2SXa10ILJms for the AI follow player movement. 
        */

        if (target != null && lives != 0)
        {
            Vector2 direction = target.position - transform.position;
            direction.Normalize(); // Keeps the length of the direction to one, thus constant. 
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // This allows for smoother rotation. 
            transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime), Quaternion.Euler(Vector3.forward * angle));
        }
        else
        {
            return;
        }
    }

    public void AvoidOtherAgents(GameObject[] otherObjects, Transform target, float spaceBetween, Rigidbody2D body)
    {
        /* Based on the below, with modifications, additions and deletions:
        // @Credit: https://www.youtube.com/watch?v=5ziHg2kO56s&t=349s 
        */

        foreach (GameObject obj in otherObjects)
        {
            float distance = Vector3.Distance(obj.transform.position, target.transform.position);

            if (distance <= spaceBetween && distance != 0)
            {
                Vector3 direction = obj.transform.position - target.transform.position;
                direction.Normalize();
                Vector3 newDirection = (direction + Vector3.up + Vector3.down).normalized;
                body.velocity = 4.5f * body.velocity.magnitude * newDirection;
            }
        }
    }
    #endregion Interactions

    #region Movement 

    /* Based on the following, with modifications:
    // @Credit: https://gamedev.stackexchange.com/questions/96878/how-to-animate-objects-with-bobbing-up-and-down-motion-in-unity
    */
    public void MoveUpAndDown(Transform transform, float yPosition, float speed, float floatStrength) => transform.position = new Vector3(transform.position.x, yPosition + ((float)Math.Sin(Time.time * speed) * floatStrength), z: transform.position.z);

    #endregion Movement

}
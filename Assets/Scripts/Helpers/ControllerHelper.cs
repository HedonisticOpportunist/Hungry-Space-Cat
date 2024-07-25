using System;
using UnityEngine;
using UnityEngine.AI;

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

    public void FlipSprite(SpriteRenderer spriteRenderer)
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    #endregion Sprite Behaviour

    #region Interactions

    public void MoveAwayFromPlayer(Transform target, Transform transform, float speed, int lives)
    {
        /* Based on the below, with modifications, additions and deletions:
        // @Credit: https://discussions.unity.com/t/gameobject1-move-away-when-gameobject2-gets-close/158522 for moving target away from player if too close. 
        */

        if (target != null && lives != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);

        }
        else
        {
            return;
        }
    }

    public void FollowPlayer(NavMeshAgent agent, Transform target)
    {
        /* Based on the below, with minor modifications:
        // @Credit:https://www.youtube.com/watch?v=HRX0pUSucW4&t=221s 
        */

        if (agent != null)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            return;
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
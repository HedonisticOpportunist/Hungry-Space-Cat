using UnityEngine;

/* Based on the below, with modifications, additions and deletions:
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/tilevania/-/blob/master/Assets/Scripts/EnemyMovement.cs for the flip UFO code. 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class UFOController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    Rigidbody2D body;
    ControllerHelper controllerHelper;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        controllerHelper = FindObjectOfType<ControllerHelper>();
    }
    void Update()
    {
        MoveUFO();
        controllerHelper.DestroyGameObjectsWhenLivesAreLost(this.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            speed = -speed;

            if (controllerHelper != null)
            {
                controllerHelper.FlipSprite(transform,body);
            }

        }
    }
    void MoveUFO() => body.velocity = new Vector2(speed, 0);
}

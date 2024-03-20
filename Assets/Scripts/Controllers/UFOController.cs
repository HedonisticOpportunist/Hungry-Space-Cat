using UnityEngine;

/* Based on the below, with modifications, additions and deletions:
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/tilevania/-/blob/master/Assets/Scripts/EnemyMovement.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
 */

public class UFOController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;

    // OTHER VARIABLES
    Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveUFO();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            speed = -speed;
            FlipUFO();
            
        }
    }
    void MoveUFO() => body.velocity = new Vector2(speed, 0);
    void FlipUFO()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(body.velocity.x)), 1f);
    }
}

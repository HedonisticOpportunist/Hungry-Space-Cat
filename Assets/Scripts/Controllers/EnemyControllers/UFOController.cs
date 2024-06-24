using UnityEngine;

/* Based on the below, with modifications, additions and deletions:
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/tilevania/-/blob/master/Assets/Scripts/EnemyMovement.cs for the flip UFO code. 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class UFOController : MonoBehaviour
{
    [Header("Speed and Movmenet")]
    [SerializeField] float speed = 2.5f;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _body;

    // OTHER GAME SCRIPTS 
    ControllerHelper _controllerHelper;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _controllerHelper = FindObjectOfType<ControllerHelper>();
    }
    void Update() => MoveUFO();

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boundary") && !PauseMenu.isPaused && Timer.timerFinished)
        {
            speed = -speed;

            if (_controllerHelper != null)
            {
                _controllerHelper.FlipSprite(_spriteRenderer);
            }
        }
    }
    void MoveUFO()
    {
        if (_body != null && Timer.timerFinished)
        {
            _body.velocity = new Vector2(speed, 0);
        }
    }
}
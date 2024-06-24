using UnityEngine;

public class SnailController : MonoBehaviour
{
    [Header("Speed and Movmenet")]
    [SerializeField] float speed = 2.5f;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _body;

    // OTHER GAME SCRIPTS 
    ControllerHelper _controllerHelper;
    Timer _timer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _controllerHelper = FindObjectOfType<ControllerHelper>();
    }

    void Update() => MoveSnail();

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
    void MoveSnail()
    {
        if (_body != null && Timer.timerFinished)
        {
            _body.velocity = new Vector2(speed * 0.5f, speed);
        }
    }
}


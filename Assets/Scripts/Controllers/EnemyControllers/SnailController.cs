using UnityEngine;

public class SnailController : MonoBehaviour
{
    [Header("Speed and Movement")]
    [SerializeField] float speed = 2.5f;

    [Header("Points for Shooting Asteroids")]
    [SerializeField] int pointsForShootingSnails = 3;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _body;

    // OTHER GAME SCRIPTS 
    ControllerHelper _controllerHelper;
    Timer _timer;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
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
        if (_body != null && Timer.timerFinished && !PauseMenu.isPaused)
        {
            _body.velocity = new Vector2(speed * 0.5f, speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerWeapon") && !PauseMenu.isPaused && Timer.timerFinished && DealWithPlayerShooting.playerShootingEnabled)
        {
            _scoreKeeper.ModifyScore(pointsForShootingSnails);
            Destroy(gameObject);
        }
    }
}
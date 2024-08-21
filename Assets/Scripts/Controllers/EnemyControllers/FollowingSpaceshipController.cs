using UnityEngine;

public class FollowingSpaceshipController : MonoBehaviour
{

    [Header("Speed and Movement")]
    [SerializeField] float speed = 2.5f;

    [Header("Points for Shooting Asteroids")]
    [SerializeField] int pointsForShootingSpaceship = 5;

    // OTHER GAME SCRIPTS
    Transform _target;
    GameObject _spaceCat;

    ControllerHelper _controllerHelper;
    HealthKeeper _healthKeeper;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _healthKeeper = FindObjectOfType<HealthKeeper>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        _spaceCat = GameObject.FindWithTag("SpaceCat");
        _target = _spaceCat.transform;
    }

    void FixedUpdate()
    {
        if (_target != null && Timer.timerFinished && !PauseMenu.isPaused)
        {
            _controllerHelper.MoveAwayFromPlayer(_target, this.transform, speed, _healthKeeper.GetLives());
        }
        else
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerWeapon") && !PauseMenu.isPaused && Timer.timerFinished && DealWithPlayerShooting.playerShootingEnabled)
        {
            _scoreKeeper.ModifyScore(pointsForShootingSpaceship);
            Destroy(gameObject);
        }
    }
}
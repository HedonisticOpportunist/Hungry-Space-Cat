using UnityEngine;
using UnityEngine.AI;

public class FlyingHamburgerController : MonoBehaviour
{
    [Header("Speed and Movement")]
    Rigidbody2D _body;
    NavMeshAgent _agent;

    [Header("Points for Shooting Flying Hamburgers")]
    [SerializeField] int pointsForShootingFlyingHamburgers = 3;

    // OTHER GAME SCRIPTS
    Transform _target;
    GameObject _spaceCat;

    ControllerHelper _controllerHelper;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _body = GetComponent<Rigidbody2D>();
        _agent = GetComponent<NavMeshAgent>();
        _scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    void Start()
    {
        _spaceCat = GameObject.FindWithTag("SpaceCat");
        _target = _spaceCat.transform;

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void FixedUpdate()
    {
        if (_target != null && Timer.timerFinished && _body != null && !PauseMenu.isPaused)
        {
            _controllerHelper.FollowPlayer(_agent, _target);
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
            _scoreKeeper.ModifyScore(pointsForShootingFlyingHamburgers);
            Destroy(gameObject);
        }
    }
}
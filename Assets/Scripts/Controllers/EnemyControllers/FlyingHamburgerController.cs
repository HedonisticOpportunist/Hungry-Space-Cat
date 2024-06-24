using UnityEngine;

public class FlyingHamburgerController : MonoBehaviour
{
    [Header("Speed and Movement")]
    [SerializeField] float speed = 2.5f;
    GameObject[] _hamburgers;
    Rigidbody2D _body;

    // OTHER GAME SCRIPTS
    Transform _target;
    GameObject _spaceCat;

    ControllerHelper _controllerHelper;
    HealthKeeper _healthKeeper;

    void Awake()
    {
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _healthKeeper = FindObjectOfType<HealthKeeper>();
        _body = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        _spaceCat = GameObject.FindWithTag("SpaceCat");
        _target = _spaceCat.transform;
        _hamburgers = GameObject.FindGameObjectsWithTag("UFO");
    }

    void FixedUpdate()
    {
        if (_target != null && Timer.timerFinished && _body != null)
        {
            _controllerHelper.AvoidOtherAgents(_hamburgers, this.transform, 2.5f, _body);
            _controllerHelper.FollowPlayer(_target, this.transform, speed, _healthKeeper.GetLives(), false);
        }
        else
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO") && !PauseMenu.isPaused && Timer.timerFinished)
        {
            Destroy(other.gameObject);
        }
    }
}
using UnityEngine;

public class FollowingSpaceshipController : MonoBehaviour
{

    [Header("Speed and Movement")]
    [SerializeField] float speed = 2.5f;

    // OTHER GAME SCRIPTS
    Transform _target;
    GameObject _spaceCat;

    ControllerHelper _controllerHelper;
    HealthKeeper _healthKeeper;

    void Awake()
    {
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _healthKeeper = FindObjectOfType<HealthKeeper>();

    }

    void Start()
    {
        _spaceCat = GameObject.FindWithTag("SpaceCat");
        _target = _spaceCat.transform;
    }

    void FixedUpdate()
    {
        if (_target != null)
        {
            _controllerHelper.FollowPlayer(_target, this.transform, speed, _healthKeeper.GetLives(), true);
        }
        else
        {
            return;
        }
    }
}
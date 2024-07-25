using UnityEngine;
using UnityEngine.AI;

public class FlyingHamburgerController : MonoBehaviour
{
    [Header("Speed and Movement")]
    Rigidbody2D _body;
    NavMeshAgent _agent;

    // OTHER GAME SCRIPTS
    Transform _target;
    GameObject _spaceCat;
    ControllerHelper _controllerHelper;
   
    void Awake()
    {
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _body = GetComponent<Rigidbody2D>();
        _agent = GetComponent<NavMeshAgent>();

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
}
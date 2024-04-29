using UnityEngine;

public class FlyingHamburgerController : MonoBehaviour
{
    [Header("Speed and Movement")]
    [SerializeField] float speed = 2.5f;
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
    }

    void FixedUpdate()
    {
        if (_target != null)
        {
            _controllerHelper.FollowPlayer(_target, this.transform, speed, _healthKeeper.GetLives());
        }
        else
        {
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            Rigidbody2D otherBody = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 randomVector = new(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
            this._body.position += randomVector; 
            otherBody.velocity -= randomVector;
        }
    }
}

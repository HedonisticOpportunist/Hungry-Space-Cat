using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [Header("Speed and Movement")]
    [SerializeField] float speed = 2.4f;

    Rigidbody2D _body;
    ControllerHelper _controllerHelper; 


    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _controllerHelper = GetComponent<ControllerHelper>();
    }
    void Update()
    {
        if (_body != null)
        {
            MoveAsteroid();
        }   
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boundary") && !PauseMenu.isPaused)
        {
            speed = -speed;

            if (_controllerHelper != null)
            {
                _controllerHelper.FlipSprite(transform, _body);
            }
        }
    }

    void MoveAsteroid() => _body.velocity = new Vector2(Random.Range(1, speed), Random.Range(1, speed));

}

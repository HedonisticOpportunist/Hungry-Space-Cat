using UnityEngine;

/* Based on the below, with minor modifications, deletions and additions:  
// @Credit: https://github.com/jcollard/SpaceRaiders/blob/jcollard/develop/Space%20Raiders/Assets/Scripts/AsteroidController.cs/. 
*/

public class AsteroidController : MonoBehaviour
{
    [Header("Speed and Rotation")]
    [SerializeField] float speed = 2.4f;
    [SerializeField] float rotationSpeed = 1.5f;

    [Header("Points for Shooting Asteroids")]
    [SerializeField] int pointsForShootingAsteroids = 5;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _body;

    // OTHER GAME SCRIPTS
    ControllerHelper _controllerHelper;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _controllerHelper = GetComponent<ControllerHelper>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        if (_body != null && Timer.timerFinished && !PauseMenu.isPaused)
        {
            RotateAsteroid();
            MoveAsteroid();
        }
    }

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerWeapon") && !PauseMenu.isPaused && Timer.timerFinished && DealWithPlayerShooting.playerShootingEnabled)
        {
            _scoreKeeper.ModifyScore(pointsForShootingAsteroids);
            Destroy(gameObject);
        }
    }

    void RotateAsteroid()
    {
        float zRotation = transform.rotation.eulerAngles.z + (rotationSpeed * Time.deltaTime);
        Vector3 newRotation = new(0, 0, zRotation);
        transform.rotation = Quaternion.Euler(newRotation);
    }

    void MoveAsteroid()
    {
        float newXPos = transform.position.x + (speed * Time.deltaTime);
        float newYPos = transform.position.y + (speed * Time.deltaTime);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
using UnityEngine;

/* Based on the below, with minor modifications, deletions and additions:  
// @Credit: https://github.com/jcollard/SpaceRaiders/blob/jcollard/develop/Space%20Raiders/Assets/Scripts/AsteroidController.cs/. 
*/

public class AsteroidController : MonoBehaviour
{
    [Header("Speed and Rotation")]
    [SerializeField] float speed = 2.4f;
    [SerializeField] float rotationSpeed = 1.5f;

    SpriteRenderer _spriteRenderer; 
    Rigidbody2D _body;

    // OTHER GAME SCRIPTS
    ControllerHelper _controllerHelper; 


    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _controllerHelper = GetComponent<ControllerHelper>();
    }
    void Update()
    {
        if (_body != null)
        {
            RotateAsteroid();
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
                _controllerHelper.FlipSprite(_spriteRenderer);
            }
        }
    }

    private void RotateAsteroid()
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

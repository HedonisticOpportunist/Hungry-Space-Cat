// @Credit: https://github.com/zigurous/unity-pacman-tutorial/blob/main/Assets/Scripts/Pacman.cs
// Any modifications and errors are mine and mine alone 
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

//[RequireComponent(typeof(Movement))]
public class Cat : MonoBehaviour
{
    [SerializeField] InputAction movement;
    //public Movement Movement { get; private set; }

    // PRIVATE METHODS //
   // private void Awake()
   // {
        //Movement = GetComponent<Movement>();
   // }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void Update()
    {
        DetermineMovementBasedOnInput();
        //RotateBasedOnAngle();
    }

    private void DetermineMovementBasedOnInput()
    {
        float horizontalDirection = movement.ReadValue<Vector2>().x;
        float verticalDirection = movement.ReadValue<Vector2>().y;

        //Debug.Log(horizontalDirection);
        //Debug.Log(verticalDirection);

        bool up = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        bool down = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        bool left = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);


        if (up)
        {
            Debug.Log(up);
            //Debug.Log(horizontalDirection);
            Debug.Log("y: " + verticalDirection);
            Debug.Log("UP");
        }
        else if (down)
        {
            Debug.Log(right);
            //Debug.Log(horizontalDirection);
            Debug.Log("y: " + verticalDirection);
            Debug.Log("DOWN");
        }
        else if (left)
        {
            Debug.Log(left);
            //Debug.Log(horizontalDirection);
            Debug.Log("x: " + horizontalDirection);
            Debug.Log("LEFT");
        }
        else if (right)
        {
            Debug.Log(right);
            //Debug.Log(horizontalDirection);
            Debug.Log("x: " + horizontalDirection);
            Debug.Log("RIGHT");
        }
    }

  /*   private void RotateBasedOnAngle()
    {
        float angle = Mathf.Atan2(Movement.Direction.y, Movement.Direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    } */
}

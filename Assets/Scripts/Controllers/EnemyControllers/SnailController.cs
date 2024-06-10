using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : MonoBehaviour
{
    [Header("Speed and Movmenet")]
    [SerializeField] float speed = 2.5f;

    // OTHER GAME SCRIPTS 
    Rigidbody2D _body;
    ControllerHelper _controllerHelper;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _controllerHelper = FindObjectOfType<ControllerHelper>();
    }

    void Update() => MoveSnail();

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boundary") && !PauseMenu.isPaused)
        {
            speed = -speed;

            if (_controllerHelper != null)
            {
                _controllerHelper.FlipSprite(transform, _body, 0.4f);
            }
        }
    }
    void MoveSnail() => _body.velocity = new Vector2(speed * 0.5f, speed);
}


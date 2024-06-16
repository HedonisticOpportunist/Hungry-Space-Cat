using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : MonoBehaviour
{
    [Header("Speed and Movmenet")]
    [SerializeField] float speed = 2.5f;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _body;

    // OTHER GAME SCRIPTS 
    ControllerHelper _controllerHelper;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
                _controllerHelper.FlipSprite(_spriteRenderer);
            }
        }
    }
    void MoveSnail() => _body.velocity = new Vector2(speed * 0.5f, speed);
}


using System.Collections;
using UnityEngine;
public class SpaceCatController : MonoBehaviour
{
    [Header("Boolean Variables")]
    [SerializeField] bool isAlive = true;
    [SerializeField] bool modeEasy = true;

    [Header("Speed and Movement")]
    [SerializeField] float speed = 15.0f;
    [SerializeField] float damageDelay = 1.0f;
    [SerializeField] float thrust = 2.0f;

    readonly float _maxSpeed = 10;
    float _horizontal;
    float _vertical;

    float _damageCountDown = 0;
    int _lives = 9;
    bool _bugsEaten; 
    
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _body;

    // OTHER GAME SCRIPTS 
    AudioPlayer _audioPlayer;
    ControllerHelper _controllerHelper;

    HealthKeeper _healthKeeper;
    SceneLoaderManager _sceneLoaderManager;
    SpawnerHelper _spawnerHelper;

    ScoreKeeper _scoreKeeper;
    UIDisplay _uIDisplay;
    SpriteEffects _spriteEffects; 

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _bugsEaten = false; 

        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _uIDisplay = GameObject.Find("GameCanvas").GetComponent<UIDisplay>();

        _healthKeeper = FindObjectOfType<HealthKeeper>();
        _sceneLoaderManager = FindObjectOfType<SceneLoaderManager>();
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();
        
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _spriteEffects = FindObjectOfType<SpriteEffects>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _lives = _healthKeeper.GetLives();
    }

    void FixedUpdate()
    {

        if (isAlive)
        {
            DealWithNumberOfBugs();

            MoveCat();

            if (_controllerHelper != null)
            {
                _controllerHelper.FlipSprite(_spriteRenderer);
            }

            if (_damageCountDown > 0)
                _damageCountDown -= Time.deltaTime;
        }
        else
        {
            return;
        }
    }

    #region Collisions

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO") && !PauseMenu.isPaused && !_bugsEaten)
        {
            OnPlayerDamage();

            if (_lives == 0)
            {
                CatDeath();

            }
        }

        if (other.CompareTag("Bug") && !_bugsEaten && !PauseMenu.isPaused)
        {
            if (DealWithEffects.spriteEffectsEnabled)
            {
                StartCoroutine(_spriteEffects.DisplayScoreEffect(_spriteRenderer));
            }
        }
    }

    void CatDeath()
    {
        isAlive = false;
        _scoreKeeper.ResetScore();
        _healthKeeper.ResetLives();
        StartCoroutine(DelayLoadEndScene());
    }

    void OnPlayerDamage()
    {
        /* Based on, with modifications and additions: 
        // @Credit: https://forum.unity.com/threads/how-to-implement-time-delay-in-damage-invincibility-frames.1375731
        */

        if (_damageCountDown > 0)
        {
            return;
        }

        _damageCountDown = damageDelay;
        _audioPlayer.PlayCatDamageClip();
        _healthKeeper.TakeDamage();

        if (DealWithEffects.spriteEffectsEnabled)
        {
            StartCoroutine(_spriteEffects.DisplayDeathEffect(_spriteRenderer, damageDelay));
        }
    }

    #endregion Collisions

    #region CatMovement

    void ApplyRelativeForce()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _body.AddRelativeForce((thrust) * Time.deltaTime * Vector2.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _body.AddRelativeForce(thrust * Time.deltaTime * Vector2.right);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _body.AddRelativeForce(thrust * Time.deltaTime * Vector2.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _body.AddRelativeForce(thrust * Time.deltaTime * Vector2.down);
        }
        else
        {
            return;
        }
    }

    void MoveCat()
    {
        /* Based on the below, with modifications and deletions:
        // @Credit: https://forum.unity.com/threads/limit-the-velocity-of-an-object-after-addforce.531229/ for slowing down the force movement. 
        */
        {
            if (modeEasy)
            {
                _body.velocity = new Vector2(_horizontal * speed, _vertical * speed);
            }
            else
            {
                ApplyRelativeForce();
                _body.velocity = Vector3.ClampMagnitude(_body.velocity, _maxSpeed);
            }

            _controllerHelper.ClampSpriteMovements(transform);
        }
    }

    #endregion CatMovement

    #region ReloadScenes

    void DealWithNumberOfBugs()
    {
        int numberOfBugs = _spawnerHelper.GetNumberOfObjectsInScene("Bug");

        if (numberOfBugs == 0 && _healthKeeper.GetLives() != 0)
        {
            _uIDisplay.LoadNextGameText();
            StartCoroutine(DelayReloadScene());
            _bugsEaten = true;
        }
    }

    IEnumerator DelayReloadScene()
    {
        yield
        return new WaitForSeconds(2f);
        _sceneLoaderManager.LoadNextLevel();
    }

    IEnumerator DelayLoadEndScene()
    {
        yield
        return new WaitForSeconds(2f);
        _sceneLoaderManager.LoadEndScene();
    }
    #endregion ReloadScenes
}
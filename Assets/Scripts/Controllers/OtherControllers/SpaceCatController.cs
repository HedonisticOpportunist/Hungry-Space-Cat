using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class SpaceCatController : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] bool isAlive = true;
    [SerializeField] float moveLimiter = 0.7f;

    [SerializeField] GameObject sleepingCat;
    [SerializeField] float damageDelay = 1.0f;

    AudioPlayer _audioPlayer;
    float _horizontal;
    float _vertical;
    float _damageCountDown = 0;

    Rigidbody2D _body;
    ControllerHelper _controllerHelper;
    HealthKeeper _healthKeeper;
    SceneLoaderManager _sceneLoaderManager;

    SpawnerHelper _spawnerHelper;
    ScoreKeeper _scoreKeeper;
    UIDisplay _uIDisplay;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _uIDisplay = FindObjectOfType<UIDisplay>();

        _healthKeeper = FindObjectOfType<HealthKeeper>();
        _sceneLoaderManager = FindObjectOfType<SceneLoaderManager>();
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    void Update()
    {

        if (isAlive)
        {
            DealWithNumberOfBugs();
            MoveCat();

            if (_controllerHelper != null)
            {
                _controllerHelper.FlipSprite(transform, _body);
            }

            if (_damageCountDown > 0)
                _damageCountDown -= Time.deltaTime;
        }

        else
        {
            return;
        }
    }

    void OnMove(InputValue value)
    {
        _horizontal = value.Get<Vector2>().x;
        _vertical = value.Get<Vector2>().y;
    }

    void MoveCat()
    {

        /* Based on the below, with modifications 
        // @Credit: https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
        */

        if (_horizontal != 0 && _vertical != 0)
        {
            _horizontal *= moveLimiter;
            _vertical *= moveLimiter;
        }

        _body.velocity = new Vector2(_horizontal * speed, _vertical * speed);
        _controllerHelper.ClampSpriteMovements(transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            OnPlayerDamage();

            if (_healthKeeper.GetLives() == 0)
            {
                CatDeath();

            }
        }
    }

    void CatDeath()
    {

        isAlive = false;
        _uIDisplay.DisplayGameOverText();
        Instantiate(sleepingCat, new Vector3(0, 0, 0), Quaternion.identity);
        _scoreKeeper.ResetScore();
        _healthKeeper.ResetLives();
        StartCoroutine(DelayMenuSceneLoad());
    }

    void OnPlayerDamage()
    {
        /* Based on, with modifactions and additions: 
        // @Credit: https://forum.unity.com/threads/how-to-implement-time-delay-in-damage-invincibility-frames.1375731
        */
        if (_damageCountDown > 0)
        {
            return;
        }
        
        _damageCountDown = damageDelay;
        _audioPlayer.PlayCatDamageClip();
        _healthKeeper.TakeDamage();
    }

    void DealWithNumberOfBugs()
    {
        int numberOfBugs = _spawnerHelper.GetNumberOfObjectsInScene("Bug");

        if (numberOfBugs == 0 && _healthKeeper.GetLives() != 0)
        {
            _uIDisplay.LoadNextGameText();
            StartCoroutine(DelayReloadScene());
        }
    }

    IEnumerator DelayMenuSceneLoad()
    {
        yield return new WaitForSeconds(2f);
        _sceneLoaderManager.ExitGame();
    }

    IEnumerator DelayReloadScene()
    {
        yield return new WaitForSeconds(2f);
        _sceneLoaderManager.LoadRandomScene();
    }
}


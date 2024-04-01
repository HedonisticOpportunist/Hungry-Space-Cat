using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class SpaceCatController : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] bool isAlive = true;
    [SerializeField] float moveLimiter = 0.7f;
    [SerializeField] GameObject sleepingCat;
    
    AudioPlayer audioPlayer;
    private float horizontal;
    private float vertical;

    Rigidbody2D body;
    ControllerHelper controllerHelper;
    HealthKeeper healthKeeper;
    SceneLoaderManager sceneLoaderManager;

    SpawnerHelper spawnerHelper;
    ScoreKeeper scoreKeeper;
    UIDisplay uIDisplay;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        controllerHelper = FindObjectOfType<ControllerHelper>();
        uIDisplay = FindObjectOfType<UIDisplay>();      

        healthKeeper = FindObjectOfType<HealthKeeper>();
        sceneLoaderManager = FindObjectOfType<SceneLoaderManager>();
        spawnerHelper = FindObjectOfType<SpawnerHelper>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    void Update()
    {

        if (isAlive)
        {
            DealWithNumberOfBugs();
            MoveCat();

            if (controllerHelper != null)
            {
                controllerHelper.FlipSprite(transform, body);
            }
        }
        else
        {
            return;
        }
    }

    void OnMove(InputValue value)
    {
        horizontal = value.Get<Vector2>().x;
        vertical = value.Get<Vector2>().y;
    }

    void MoveCat()
    {

        /* Based on the below, with modifications 
        // @Credit: https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/
        */

        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * speed, vertical * speed);
        controllerHelper.ClampSpriteMovements(transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            audioPlayer.PlayCatDamageClip();
            healthKeeper.TakeDamage();

            if (healthKeeper.GetLives() == 0)
            {
                CatDeath();
                
            }
        }
    }

    void CatDeath()
    {

        isAlive = false;
        uIDisplay.DisplayGameOverText();
        Instantiate(sleepingCat, new Vector3(0, 0, 0), Quaternion.identity);
        scoreKeeper.ResetScore();
        healthKeeper.ResetLives();
        StartCoroutine(DelayMenuSceneLoad());
    }

    IEnumerator DelayMenuSceneLoad()
    {
        yield return new WaitForSeconds(2f);
        sceneLoaderManager.ExitGame();
    }

    IEnumerator DelayReloadScene()
    {
        yield return new WaitForSeconds(2f);
        sceneLoaderManager.LoadRandomScene();
    }

    void DealWithNumberOfBugs()
    {
        int numberOfBugs = spawnerHelper.GetNumberOfObjectsInScene("Bug");

        if (numberOfBugs == 0 && healthKeeper.GetLives() != 0)
        {
            uIDisplay.LoadNextGameText();
            StartCoroutine(DelayReloadScene());
        }
    }
}


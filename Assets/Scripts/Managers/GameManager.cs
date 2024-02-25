// @Credit: https://github.com/zigurous/unity-pacman-tutorial/blob/main/Assets/Scripts/GameManager.cs
// Any modifications and errors are mine and mine alone 

using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    // @Credit: https://bergstrand-niklas.medium.com/setting-up-a-simple-game-manager-in-unity-24b080e9516c 
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject); 
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }

    }
    #endregion

    public Cat cat;
    public Wolf[] wolves;
    public Transform pellets;
    public int Score { get; private set; }
    public int Lives { get; private set; }

    // PUBLIC METHODS //

    public void WolfDevoured(Wolf wolf)
    {
        SetScore(this.Score + wolf.points);
    }

    public void CatDevoured()
    {
        DeactivateCat();
        SetLives(this.Lives - 1);

        if (this.Lives > 0)
        {
            Invoke(nameof(ResetCatAndWolves), 3.0f);
        }
        else
        {
            GameOver();
        }
    }

    // PRIVATE METHODS //

    private void Start() => StartGame();

    private void StartGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void Update()
    {
        if (this.Lives <= 0 && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    private void NewRound()
    {
        ActivatePellets();
        ResetCatAndWolves();

    }

    private void ResetCatAndWolves()
    {
        ActivateWolves();
        ActivateCat();
    }

    private void GameOver()
    {
        DeactivateWolves();
        DeactivateCat();
    }

    private void SetScore(int score) => this.Score = score;

    private void SetLives(int lives) => this.Lives = lives;

    private void ActivatePellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }
    } 
    private void ActivateWolves()
    {
        foreach (Wolf wolf in this.wolves)
        {
            wolf.gameObject.SetActive(true);
        }
    }
    private void ActivateCat()
    {
        cat.gameObject.SetActive(true);
    }
    private void DeactivateCat()
    {
        cat.gameObject.SetActive(false);
    }

    private void DeactivateWolves()
    {
        foreach (Wolf wolf in this.wolves)
        {
            wolf.gameObject.SetActive(false);
        }
    }
}

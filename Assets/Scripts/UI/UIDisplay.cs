using TMPro;
using UnityEngine;
using UnityEngine.UI;

/* Based on the below, with modifications and additions: 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/UIDisplay.cs
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/UIGameOver.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class UIDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper _scoreKeeper;

    [Header("Lives")]
    [SerializeField] Image[] healthSprites;
    HealthKeeper _healthKeeper;
    int _lives;

    [Header("GameOver")]
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI applicationStopText;
    [SerializeField] TextMeshProUGUI newGameText;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _healthKeeper = FindObjectOfType<HealthKeeper>();
    }

    void Start()
    {
        gameOverText.text = "";
        applicationStopText.text = "";
        newGameText.text = "";
        DisplayCatLivesSprites();
    }

    void FixedUpdate()
    {

        scoreText.text = "Score: " + _scoreKeeper.GetScore().ToString("000000000");
        _lives = _healthKeeper.GetLives();
    }

    public void DisplayGameOverText()
    {
        newGameText.text = "";
        gameOverText.text = "Game over!";
        applicationStopText.text = "You will be redirected to the menu in five, four, three ...";
    }

    public void LoadNextGameText()
    {
        newGameText.text = "You will be redirected to the next level in five, four, three ...";
    }

    public void UpdateLives()
    {
        // Based on the below with modifications and deletions: 
        // @Credit: https://medium.com/@austinjy13/unity-ui-creating-a-2d-life-counter-c23edc7f271c for setting sprites 'active' in the Start() method.  

        if (_lives == 8)
        {
            healthSprites[8].enabled = false;
        }

        if (_lives == 7)
        {
            healthSprites[7].enabled = false;
        }

        if (_lives == 6)
        {
            healthSprites[6].enabled = false;
        }

        if (_lives == 5)
        {
            healthSprites[5].enabled = false;
        }

        if (_lives == 4)
        {
            healthSprites[4].enabled = false;
        }

        if ( _lives == 3)
        {
            healthSprites[3].enabled = false;
        }

        if (_lives == 2)
        {
            healthSprites[2].enabled = false;
        }

        if (_lives == 1)
        {
            healthSprites[1].enabled = false;
        }

        if (_lives == 0)
        {
            healthSprites[0].enabled = false;
        }
       
    }

    void DisplayCatLivesSprites()
    {
        // Based on the below with modifications, additions and deletions: 
        // @Credit: https://medium.com/@austinjy13/unity-ui-creating-a-2d-life-counter-c23edc7f271c for setting sprites 'active' in the Start() method. 
        for (int i = 0; i < _healthKeeper.GetLives(); i++)
        {
            healthSprites[i].enabled = true;
        }
    }
}

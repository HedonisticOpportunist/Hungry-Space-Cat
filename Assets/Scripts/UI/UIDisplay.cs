using TMPro;
using UnityEngine;

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

    [Header("Health")]
    [SerializeField] TextMeshProUGUI healthText;
    HealthKeeper _healthKeeper;

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
    }

    void Update()
    {
      healthText.text = "Lives: " + _healthKeeper.GetLives().ToString();
      scoreText.text = "Score: " + _scoreKeeper.GetScore().ToString("000000000");   
    }

    public void DisplayGameOverText()
    {
        newGameText.text = "";
        gameOverText.text = "Game over!";
        applicationStopText.text = "The application will stop in five, four, three ...";
    }

    public void LoadNextGameText()
    {
        newGameText.text = "You will be redirected to the next level in five, four, three ...";
    }
}

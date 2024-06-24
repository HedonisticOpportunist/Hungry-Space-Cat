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

    [Header("Lives")]
    [SerializeField] TextMeshProUGUI livesText;
    HealthKeeper _healthKeeper;

    [Header("New Level")]
    [SerializeField] TextMeshProUGUI loadGameText; 
    [SerializeField] TextMeshProUGUI newGameText;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _healthKeeper = FindObjectOfType<HealthKeeper>();
    }

    void Start()
    {
        newGameText.text = "";
        loadGameText.text = "Wait for the game to load ...";

    }

    void FixedUpdate()
    {
        scoreText.text = "Score: " + _scoreKeeper.GetScore().ToString("000000000");
        livesText.text = _healthKeeper.GetLives().ToString();

        if (Timer.timerFinished)
        {
            loadGameText.text = "";
        }

    }

    public void LoadNextGameText() => newGameText.text = "You will be redirected to the next level in five, four, three ...";
}

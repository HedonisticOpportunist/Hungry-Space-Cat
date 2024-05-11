using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("GameOver")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper _scoreKeeper;
    HealthKeeper _healthKeeper;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _healthKeeper = FindObjectOfType<HealthKeeper>();
    }

    void Start()
    {
        scoreText.text = " ";

        if (_scoreKeeper != null)
        {
            DisplayGameOverVisuals();
        }
    }

    void DisplayGameOverVisuals()
    {

        if (_scoreKeeper != null && _healthKeeper.GetLives() == 0)
        {
            scoreText.text = "You died! You scored: " + _scoreKeeper.GetScore().ToString() + " points.";
        }

        if (_scoreKeeper != null && _healthKeeper.GetLives() > 0)
        {
            scoreText.text = "Congrats! You have scored: " + _scoreKeeper.GetScore().ToString() + " points.";
        }
    }
}
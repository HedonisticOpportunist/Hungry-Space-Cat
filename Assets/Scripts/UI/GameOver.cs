using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        bool gameHasEnded = DetermineIfGameHasEnded();

        if (_scoreKeeper != null && _healthKeeper.GetLives() == 0 && !gameHasEnded)
        {
            scoreText.text = "You died! You scored: " + _scoreKeeper.GetScore().ToString() + " points.";
        }

        if (_scoreKeeper != null && _healthKeeper.GetLives() > 0 && !gameHasEnded)
        {
            scoreText.text = "You scored: " + _scoreKeeper.GetScore().ToString() + " points.";
        }

        else
        {
            scoreText.text = "Congrats! You reached the end, and scored: " + _scoreKeeper.GetScore().ToString() + " points.\n " + "\nPlease consider adopting a cat!";
        }
    }

    bool DetermineIfGameHasEnded()
    {
        bool gameEnded;
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        if (previousSceneIndex == 9 || previousSceneIndex == 12)
        {
           
            gameEnded = true;
        } 
        else
        {
            gameEnded = false;
        }

        return gameEnded;
    }
}
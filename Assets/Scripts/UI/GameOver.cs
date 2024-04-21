using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("GameOver")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = " ";
        DisplayGameOverVisuals();
    }

    void DisplayGameOverVisuals()
    {
        if (_scoreKeeper != null)
        {
            scoreText.text = "You have scored: " + _scoreKeeper.GetScore().ToString();
        }
    }

  

}

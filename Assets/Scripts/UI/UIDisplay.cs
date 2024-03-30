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
    ScoreKeeper scoreKeeper;

    [Header("Health")]
    [SerializeField] TextMeshProUGUI healthText;
    HealthKeeper healthKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthKeeper = FindObjectOfType<HealthKeeper>();
    }

    void Update()
    {
      healthText.text = "Lives: " + healthKeeper.GetLives().ToString();
      scoreText.text = "Score: " + scoreKeeper.GetScore().ToString("000000000");
        
    }
}

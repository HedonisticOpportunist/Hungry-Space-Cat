using UnityEngine;

/* Based on the below, with modifications and additions: 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/ScoreKeeper.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class HealthKeeper : MonoBehaviour
{
    [SerializeField] int lives = 50;
    static HealthKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetLives()
    {
        return lives;
    }

    public void TakeDamage()
    {
        lives -= DeterminePointsBasedOnLevel();

        if (lives == 0)
        {
            return;
        }
    }


    public void ResetLives()
    {
        lives = 0;
    }

    int DeterminePointsBasedOnLevel()
    {
        int pointsForDamage = 5;
        return pointsForDamage;
    }
}

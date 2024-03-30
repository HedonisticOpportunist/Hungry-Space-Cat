using UnityEngine;

/* Based on the below, with modifications and additions: 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/ScoreKeeper.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class HealthKeeper : MonoBehaviour
{
   [SerializeField] int lives;
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
        if (GetLives() != 0)
        {
            lives -= DeterminePointsBasedOnLevel();
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

using UnityEngine;

/* Based on the below, with modifications and additions: 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/ScoreKeeper.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class HealthKeeper : MonoBehaviour
{
   private int _lives = 90;
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
        return _lives;
    }

    public void TakeDamage()
    {
        if (GetLives() != 0)
        {
            _lives -= CalculateDamagePoints();
        }
    }


    public void ResetLives()
    {
        _lives = 90;
    }

    int CalculateDamagePoints()
    {
        int pointsForDamage = 9;
        return pointsForDamage;
    }
}

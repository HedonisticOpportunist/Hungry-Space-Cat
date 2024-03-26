using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;


    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    SceneLoaderManager sceneLoaderManager;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        sceneLoaderManager = FindObjectOfType<SceneLoaderManager>();
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            //sceneLoaderManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
}

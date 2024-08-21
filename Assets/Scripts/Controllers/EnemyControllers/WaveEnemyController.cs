using System.Collections.Generic;
using UnityEngine;

/* Based on the below, with modifications, deletions and additions: 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/Pathfinder.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class WaveEnemyController : MonoBehaviour
{
    [Header("Points for Shooting Asteroids")]
    [SerializeField] int pointsForShootingWaveObjects = 3;

    // OTHER GAME SCRIPTS
    SpawnWaveEnemies _spawnWaveEnemies;
    WavesConfig _waveConfig;
    ScoreKeeper _scoreKeeper;

    // PRIVATE VARIABLES
    List<Transform> _waypoints;
    int _waypointIndex = 0;

    void Awake()
    {
        _spawnWaveEnemies = FindObjectOfType<SpawnWaveEnemies>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        _waveConfig = _spawnWaveEnemies.GetCurrentWave();
        _waypoints = _waveConfig.GetWaypoints();
        transform.position = _waypoints[_waypointIndex].position;
    }

    void Update() => FollowWavePath();

    void FollowWavePath()
    {
        if (_waypointIndex < _waypoints.Count && Timer.timerFinished && !PauseMenu.isPaused)
        {
            Vector3 targetPosition = _waypoints[_waypointIndex].position;
            float delta = _waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if (transform.position == targetPosition)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerWeapon") && !PauseMenu.isPaused && Timer.timerFinished && DealWithPlayerShooting.playerShootingEnabled)
        {
            _scoreKeeper.ModifyScore(pointsForShootingWaveObjects);
            Destroy(gameObject);
        }
    }
}
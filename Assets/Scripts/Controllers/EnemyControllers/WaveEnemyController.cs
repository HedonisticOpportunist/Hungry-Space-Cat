using System.Collections.Generic;
using UnityEngine;

/* Based on the below, with minor modifications 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/Pathfinder.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class WaveEnemyController : MonoBehaviour
{
    // OTHER GAME SCRIPTS
    SpawnWaveEnemies _spawnWaveEnemies;
    WavesConfig _waveConfig;
    List<Transform> _waypoints;
    int _waypointIndex = 0;

    void Awake() => _spawnWaveEnemies = FindObjectOfType<SpawnWaveEnemies>();

    void Start()
    {
        _waveConfig = _spawnWaveEnemies.GetCurrentWave();
        _waypoints = _waveConfig.GetWaypoints();
        transform.position = _waypoints[_waypointIndex].position;
    }

    void Update() => FollowWavePath();

    void FollowWavePath()
    {
        if (_waypointIndex < _waypoints.Count)
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
}
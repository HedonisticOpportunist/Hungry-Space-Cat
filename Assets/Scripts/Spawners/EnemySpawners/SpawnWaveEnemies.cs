using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Based on the below, with minor modifications 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/EnemySpawner.cs. 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class SpawnWaveEnemies : MonoBehaviour
{
    [Header("Waves Config/List of Waves")]
    [SerializeField] List<WavesConfig> waveConfigs;
    WavesConfig _currentWave;

    [Header("Time Between Waves")]
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;

    void Start() => StartCoroutine(SpawnEnemiesIntoScene());

    public WavesConfig GetCurrentWave() => _currentWave;

    IEnumerator SpawnEnemiesIntoScene()
    {
        do
        {
            foreach (WavesConfig wave in waveConfigs)
            {
                _currentWave = wave;
                for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(_currentWave.GetEnemyPrefab(i),
                      _currentWave.GetStartingWaypoint().position,
                      Quaternion.Euler(0, 0, 360), transform);
                    yield
                    return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
                }
                yield
                return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);
    }
}
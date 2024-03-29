using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnGhostDoll : MonoBehaviour
{
    [SerializeField] List<WavesConfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WavesConfig currentWave;

    void Start()
    {
        StartCoroutine(SpawnGhostDolls());
    }

    public WavesConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnGhostDolls()
    {
        do
        {
            foreach (WavesConfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0, 0, 360), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);
    }
}


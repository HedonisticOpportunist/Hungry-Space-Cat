using System.Collections.Generic;
using UnityEngine;

/* Based on the below, with minor modifications 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/WaveConfigSO.cs. 
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/


[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WavesConfig : ScriptableObject
{
    [SerializeField] List<GameObject> ghostDollPrefabs;
    [SerializeField] Transform pathPrefab;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return ghostDollPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return ghostDollPrefabs[index];
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
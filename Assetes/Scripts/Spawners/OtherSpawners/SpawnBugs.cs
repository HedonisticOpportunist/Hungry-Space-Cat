using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    [SerializeField] List<GameObject> bugs;
    SpawnerHelper spawnerHelper;

    void Awake()
    {
        spawnerHelper = FindObjectOfType<SpawnerHelper>();

    }

    void Start()
    {
        spawnerHelper.SpawnObjectsRandomly(bugs);
    }
}

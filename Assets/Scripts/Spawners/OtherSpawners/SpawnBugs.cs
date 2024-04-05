using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    [SerializeField] List<GameObject> bugs;
    SpawnerHelper _spawnerHelper;

    void Awake()
    {
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();

    }

    void Start()
    {
        _spawnerHelper.SpawnObjectsRandomly(bugs);
    }
}

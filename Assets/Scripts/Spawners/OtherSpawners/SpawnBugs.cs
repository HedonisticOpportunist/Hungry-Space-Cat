using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    [Header("List of Bugs")]
    [SerializeField] List<GameObject> bugs;

    [Header("SpaceCat")]
    [SerializeField] GameObject spaceCat; 
    SpawnerHelper _spawnerHelper;

    void Awake()
    {
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();

    }

    void Start()
    {
        _spawnerHelper.SpawnObjectsRandomly(bugs, spaceCat);
    }
}

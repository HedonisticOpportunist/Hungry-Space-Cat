using System.Collections.Generic;
using UnityEngine;

public class SpawnGhostDolls : MonoBehaviour
{
    [SerializeField] List<GameObject> ghostDolls;
    SpawnerHelper spawnerHelper;
    void Awake()
    {
        spawnerHelper = FindObjectOfType<SpawnerHelper>();
    }

    void Start()
    {
        spawnerHelper.SpawnObjectsRandomly(ghostDolls);
    }
}



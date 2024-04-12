using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanets : MonoBehaviour
{
    [SerializeField] List<GameObject> planets;
    SpawnerHelper _spawnerHelper;

    void Awake()
    {
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();

    }

    void Start()
    {
        _spawnerHelper.SpawnObjectsRandomly(planets);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlyingHamburgers : MonoBehaviour
{
    [SerializeField] List<GameObject> flyingHamburgers;
    SpawnerHelper spawnerHelper;

    void Awake()
    {
        spawnerHelper = FindObjectOfType<SpawnerHelper>();
    }

    void Start()
    {
        spawnerHelper.SpawnObjectsRandomly(flyingHamburgers);
    }
}

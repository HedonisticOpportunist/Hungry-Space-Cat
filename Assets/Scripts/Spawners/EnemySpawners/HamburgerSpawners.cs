using System.Collections.Generic;
using UnityEngine;

public class SpawnFlyingHamburgers : MonoBehaviour
{
    [Header("List of Flying Hamburgers")]
    [SerializeField] List<GameObject> flyingHamburgers;
    SpawnerHelper _spawnerHelper;

    void Awake()
    {
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();
    }

    void Start()
    {
        _spawnerHelper.SpawnObjectsRandomly(flyingHamburgers);
    }
}
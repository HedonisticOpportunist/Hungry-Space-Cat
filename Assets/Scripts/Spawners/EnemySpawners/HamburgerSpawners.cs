using System.Collections.Generic;
using UnityEngine;

public class SpawnFlyingHamburgers : MonoBehaviour
{
    [Header("List of Flying Hamburgers")]
    [SerializeField] List<GameObject> flyingHamburgers;

    [Header("SpaceCat")]
    [SerializeField] GameObject spaceCat; 
    SpawnerHelper _spawnerHelper;

    void Awake()
    {
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();
    }

    void Start()
    {
        _spawnerHelper.SpawnObjectsRandomly(flyingHamburgers, spaceCat);
    }
}
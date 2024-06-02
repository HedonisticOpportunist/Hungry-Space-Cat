using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [Header("List of Asteroids")]
    [SerializeField] List<GameObject> asteroids;

    [Header("SpaceCat")]
    [SerializeField] GameObject spaceCat;
    SpawnerHelper _spawnerHelper;

    void Awake() => _spawnerHelper = FindObjectOfType<SpawnerHelper>();

    void Start() => _spawnerHelper.SpawnObjectsRandomly(asteroids, spaceCat);
}
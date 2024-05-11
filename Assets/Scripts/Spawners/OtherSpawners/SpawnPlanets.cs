using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanets : MonoBehaviour
{
    [Header("List of Planets")]
    [SerializeField] List<GameObject> planets;

    [Header("SpaceCat")]
    [SerializeField] GameObject spaceCat;
    SpawnerHelper _spawnerHelper;

    void Awake() => _spawnerHelper = FindObjectOfType<SpawnerHelper>();

    void Start() => _spawnerHelper.SpawnObjectsRandomly(planets, spaceCat);
}
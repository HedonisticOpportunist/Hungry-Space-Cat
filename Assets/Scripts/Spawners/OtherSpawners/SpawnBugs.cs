using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    [Header("SpaceCat")]
    [SerializeField] GameObject spaceCat;
    SpawnerHelper _spawnerHelper;

    void Awake() => _spawnerHelper = FindObjectOfType<SpawnerHelper>();

    void Start() => _spawnerHelper.SpawnObjectsRandomly(spaceCat);
}
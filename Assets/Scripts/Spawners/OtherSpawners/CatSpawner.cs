using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    [Header("Space Cat Game Object")]
    [SerializeField] GameObject spaceCat;
    SpawnerHelper _spawnerHelper;

    private void Awake()
    {
        _spawnerHelper = FindAnyObjectByType<SpawnerHelper>();
    }

    void Start()
    {
        _spawnerHelper.SpawnObjectRandomly(spaceCat);
    }
}

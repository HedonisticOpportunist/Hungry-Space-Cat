using UnityEngine;

public class SpawnUFOs : MonoBehaviour
{
    [Header("UFO Game Object")]
    [SerializeField] GameObject UFO;
    void Start()
    {
        SpawnUFOAtCorners();
    }

    void SpawnUFOAtCorners()
    {
        Vector2[] spawnPositions = { new(-10, 4), new(10, 4), new(10, -4), new(-10, -4) };
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Instantiate(UFO, spawnPositions[i], Quaternion.identity);
        }
    }
}

using UnityEngine;

public class SpawnUFOs : MonoBehaviour
{
    [Header("UFO Game Object")]
    [SerializeField] GameObject UFO;

    void Start() => SpawnUFOAtCorners();

    void SpawnUFOAtCorners()
    {
        Vector2[] edges = { new(-10, 4), new(10, 4), new(10, -4), new(-10, -4) };
        Vector2[] spawnPositions = {edges[0], edges[1], edges[2], edges[3] };

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Instantiate(UFO, spawnPositions[i], Quaternion.identity);
        }
    }
}
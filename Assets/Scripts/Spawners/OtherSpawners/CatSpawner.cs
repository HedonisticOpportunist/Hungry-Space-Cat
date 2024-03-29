using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    [SerializeField] GameObject spaceCat;
    void Start()
    {
        SpawnCatRandomly();
    }

    void SpawnCatRandomly()
    {
        Vector2 position = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        Instantiate(spaceCat, position, Quaternion.identity);
    }
}

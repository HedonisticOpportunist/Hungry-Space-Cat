using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    [SerializeField] List<GameObject> bugs;

    void Start()
    {
        SpawnBugsRandomly();
    }

    void SpawnBugsRandomly()
    {
        for (int i = 0; i < bugs.Count; i++)
        {
            Vector2 position = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Instantiate(bugs[i], position, Quaternion.identity);
        }
    }
}

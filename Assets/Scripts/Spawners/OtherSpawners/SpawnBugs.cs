using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    [Header("List of Bugs")]
    [SerializeField] List<GameObject> bugs;
    SpawnerHelper _spawnerHelper;

    void Awake()
    {
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();

    }

    void Start()
    {
        _spawnerHelper.SpawnObjectsRandomly(bugs);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bug"))
        {
            // This avoids the object overlapping with itself while spawning. 
            other.gameObject.transform.position += new Vector3(200, 200);
        }
    }
}

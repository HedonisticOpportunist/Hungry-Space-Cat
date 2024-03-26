using System.Collections.Generic;
using UnityEngine;

public class SpawnFlyingHamburgers : MonoBehaviour
{
    [SerializeField] List<GameObject> flyingHamburgers;
    SpawnerHelper spawnerHelper;

    void Awake()
    {
        spawnerHelper = FindObjectOfType<SpawnerHelper>();
    }

    void Start()
    {
        spawnerHelper.SpawnObjectsRandomly(flyingHamburgers);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            // This avoids the object overlapping with itself while spawning. 
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}

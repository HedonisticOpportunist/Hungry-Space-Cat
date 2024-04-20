using System.Collections.Generic;
using UnityEngine;

public class SpawnFlyingHamburgers : MonoBehaviour
{
    [SerializeField] List<GameObject> flyingHamburgers;
    SpawnerHelper _spawnerHelper;

    void Awake()
    {
        _spawnerHelper = FindObjectOfType<SpawnerHelper>();
    }

    void Start()
    {
        _spawnerHelper.SpawnObjectsRandomly(flyingHamburgers);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UFO"))
        {
            // This avoids the object overlapping with itself while spawning. 
            other.gameObject.transform.position += new Vector3(200, 200);
        }
    }
}
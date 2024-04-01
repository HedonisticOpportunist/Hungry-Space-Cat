using System.Collections.Generic;
using UnityEngine;

public class SpawnerHelper : MonoBehaviour
{
    public void SpawnObjectsRandomly(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Vector2 position = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));

            if (objects[i] != null)
            {
                Instantiate(objects[i], position, Quaternion.identity);
            }

            else
            {
                return;
            }
        }
    }

    public int GetNumberOfObjectsInScene(string objectTag)
    {
        return GameObject.FindGameObjectsWithTag(objectTag).Length;
    }
}

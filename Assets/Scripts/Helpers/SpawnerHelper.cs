using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerHelper : MonoBehaviour
{
    public void SpawnObjectsRandomly(List<GameObject> objects, GameObject target)
    {

        for (int i = 0; i < objects.Count; i++)
        {
            float buffer = 50f;
            Vector2 minPosition = Camera.main.ScreenToWorldPoint(new Vector2(buffer, buffer));
            Vector2 maxPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - buffer, Screen.height - buffer));
            Vector2 spawnPosition = new(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y));

            if (objects[i] != null && target != null)
            {
                float distance = GetDistanceFromPlayer(objects[i], target);

                if (distance != 0)
                {
                    Instantiate(objects[i], spawnPosition, Quaternion.identity);
                }
            }
            else
            {
                return;
            }
        }
    }

    public int GetNumberOfObjectsInScene(string objectTag) => GameObject.FindGameObjectsWithTag(objectTag).Length;

    public void SpawnObjectRandomly(GameObject gameObject)
    {
        if (gameObject != null)
        {
            float buffer = 50f;
            Vector2 minPosition = Camera.main.ScreenToWorldPoint(new Vector2(buffer, buffer));
            Vector2 maxPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - buffer, Screen.height - buffer));
            Vector2 position = new(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y));
            Instantiate(gameObject, position, Quaternion.identity);
        }
    }

    float GetDistanceFromPlayer(GameObject gameObject, GameObject target) => Vector3.Distance(gameObject.transform.position, target.transform.position);
}
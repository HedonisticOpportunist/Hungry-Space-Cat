using System.Collections.Generic;
using UnityEngine;

/* Based on the below, with minor modifications 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/Pathfinder.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class GhostController : MonoBehaviour
{
    SpawnGhostDoll spawnGhostDoll;
    WavesConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        spawnGhostDoll = FindObjectOfType<SpawnGhostDoll>();
    }

    void Start()
    {
        waveConfig = spawnGhostDoll.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowWavePath();
    }

    void FollowWavePath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

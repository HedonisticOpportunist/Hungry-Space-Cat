// Based on, with modifications: 
// @ https://gamedev.stackexchange.com/questions/96878/how-to-animate-objects-with-bobbing-up-and-down-motion-in-unity
using System;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] float yPosition;
    [SerializeField] float floatStrength = 0.6f;
    [SerializeField] float speed = 2.4f;

    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            yPosition + ((float)Math.Sin(Time.time * speed) * floatStrength),
            transform.position.z);
    }
}

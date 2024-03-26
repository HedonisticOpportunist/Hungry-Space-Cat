using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] float rotationSpeed = 1.5f;

    // OTHER VARIABLES 
    Transform spaceCat;

    // PRIVATE METHODS

    void Awake()
    {
        spaceCat = FindObjectOfType<SpaceCatController>().transform;
    }

    void Update() => FollowPlayer();
    void FollowPlayer()
    {

        if (spaceCat == null)
        {
            return;
        }

        Vector3 direction = transform.position - spaceCat.position;
        transform.up = Vector3.MoveTowards(transform.up, direction, rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, spaceCat.position, speed * Time.deltaTime);
    }
}

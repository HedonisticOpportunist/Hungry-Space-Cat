using UnityEngine;

/* Based on the below, with modifications, additions and deletions:
// @Credit: https://www.youtube.com/watch?v=jlklOd8PEQE for the AI follow player movement. 
*/
public class FlyingHamburgerController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] float rotationSpeed = 1.5f;
    Transform spaceCat;

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

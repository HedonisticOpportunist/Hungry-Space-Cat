using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] float speed = 4.5f;
    [SerializeField] float rotationSpeed = 1.5f;
    [SerializeField] Vector3 minDistance = new Vector3(0.1f, 0.1f, 0f);
    ControllerHelper controllerHelper;

    void Awake()
    {
        controllerHelper = FindObjectOfType<ControllerHelper>();
    }

    void Update() => controllerHelper.FollowPlayer(transform, speed, rotationSpeed, minDistance);

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

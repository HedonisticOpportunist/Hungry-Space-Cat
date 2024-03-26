using UnityEngine;

public class FlyingHamburgerController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] float rotationSpeed = 1.5f;
    [SerializeField] Vector3 minDistance = new Vector3(0.4f, 0.2f, 0f);
    ControllerHelper controllerHelper;


    void Awake()
    {
        controllerHelper = FindObjectOfType<ControllerHelper>();
    }

    void Update() => controllerHelper.FollowPlayer(transform, speed, rotationSpeed, minDistance);
}

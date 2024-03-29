using UnityEngine;

public class FlyingHamburgerController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] Transform spaceCat;
    ControllerHelper controllerHelper;


    void Awake()
    {
        controllerHelper = FindObjectOfType<ControllerHelper>();
       

        if (spaceCat != null)
        {
            spaceCat = FindObjectOfType<SpaceCatController>().transform; 
        }
        else
        {
            return;
        }

    }

    void Update() => controllerHelper.FollowPlayer(spaceCat, this.transform, speed);
}

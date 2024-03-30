using UnityEngine;

public class FlyingHamburgerController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] Transform spaceCat;
    ControllerHelper controllerHelper;
    HealthKeeper healthKeeper;


    void Awake()
    {
        controllerHelper = FindObjectOfType<ControllerHelper>();
        healthKeeper = FindObjectOfType<HealthKeeper>();
       

        if (spaceCat != null)
        {
            spaceCat = FindObjectOfType<SpaceCatController>().transform; 
        }
        else
        {
            return;
        }

    }

    void Update()
    {
        controllerHelper.FollowPlayer(spaceCat, this.transform, speed, healthKeeper.GetLives());
        controllerHelper.DestroyGameObjectsWhenLivesAreLost(this.gameObject);
    }
}

using UnityEngine;

public class FlyingHamburgerController : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] Transform spaceCat;
    ControllerHelper _controllerHelper;
    HealthKeeper _healthKeeper;


    void Awake()
    {
        _controllerHelper = FindObjectOfType<ControllerHelper>();
        _healthKeeper = FindObjectOfType<HealthKeeper>();
       

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
        _controllerHelper.FollowPlayer(spaceCat, this.transform, speed, _healthKeeper.GetLives());
    }
}

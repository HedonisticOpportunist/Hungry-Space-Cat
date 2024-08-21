using UnityEngine;

public class DealWithPlayerShooting : MonoBehaviour
{
    public static bool playerShootingEnabled = true;

    public void DisablePlayerShooting() => playerShootingEnabled = false;
    public void EnabledPlayerShooting() => playerShootingEnabled = true;

}

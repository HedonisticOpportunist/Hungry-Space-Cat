using UnityEngine;

public class Effects : MonoBehaviour
{

    public static bool effectsEnabled = true;

    public void DisableMovingBackgroundEffect() => effectsEnabled = false;
    public void EnableMovingBackgroundEffect() => effectsEnabled = true;
}

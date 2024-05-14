using UnityEngine;

public class Effects : MonoBehaviour
{

    public static bool backgroundEffectEnabled = true;

    public void DisableMovingBackgroundEffect() => backgroundEffectEnabled = false;
}

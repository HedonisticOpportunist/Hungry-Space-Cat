using UnityEngine;

public class DealWithEffects : MonoBehaviour
{
    public static bool backGroundEffectsEnabled = true;
    public static bool spriteEffectsEnabled = true;

    public void DisableMovingBackgroundEffect() => backGroundEffectsEnabled = false;
    public void EnableMovingBackgroundEffect() => backGroundEffectsEnabled = true;
    public void DisableSpriteEffects() => spriteEffectsEnabled = false;
    public void EnableSpriteEffects() => spriteEffectsEnabled = true;
}

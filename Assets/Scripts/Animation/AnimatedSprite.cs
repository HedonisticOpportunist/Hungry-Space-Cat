using UnityEngine;

/* Based on, with modifications and additions:
// @Credit: https://github.com/zigurous/unity-pacman-tutorial/blob/main/Assets/Scripts/AnimatedSprite.cs
*/

public class AnimatedSprite : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] spritesArray;

    [Header("Animation and Duration")]
    [SerializeField] float animationTime = 0.25f;
    [SerializeField] int animationFrame;
    [SerializeField] bool animationShouldLoop = true;

    void RestartAnimation()
    {
        animationFrame = -1;
        MoveAnimationForward();
    }

    void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    void Start() => InvokeRepeating(nameof(MoveAnimationForward), animationTime, animationTime);

    void MoveAnimationForward()
    {
        if (!spriteRenderer.enabled)
        {
            return;
        }
        else
        {
            animationFrame++;
            CheckAnimationFrameConditions();
        }
    }

    void CheckAnimationFrameConditions()
    {
        if (animationFrame >= spritesArray.Length && animationShouldLoop)
        {
            animationFrame = 0;
        }

        if (animationFrame >= 0 && animationFrame < spritesArray.Length)
        {
            spriteRenderer.sprite = spritesArray[animationFrame];
        }
    }
}
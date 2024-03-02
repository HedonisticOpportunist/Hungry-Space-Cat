// With modification @Credit: https://github.com/zigurous/unity-pacman-tutorial/blob/main/Assets/Scripts/AnimatedSprite.cs
// Any errors are mine and mine alone 
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] spritesArray;
    [SerializeField] float animationTime = 0.25f;
    [SerializeField] int animationFrame;
    [SerializeField] bool animationShouldLoop = true;

    // PUBLIC METHODS //

    void RestartAnimation()
    {
        animationFrame = -1;

        MoveAnimationForward();
    }

    // PRIVATE METHODS //
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InvokeRepeating(nameof(MoveAnimationForward), animationTime, animationTime);
    }

    void MoveAnimationForward()
    {
        if (!spriteRenderer.enabled)
        {
            return;
        }

        animationFrame++;
        CheckAnimationFrameConditions();
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



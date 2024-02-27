// @Credit: https://github.com/zigurous/unity-pacman-tutorial/blob/main/Assets/Scripts/AnimatedSprite.cs
// Any modifications and errors are mine and mine alone 
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] spritesArray;
    public float animationTime = 0.25f;
    public int animationFrame { get; private set; }
    public bool animationShouldLoop = true;

    // PUBLIC METHODS //

    public void RestartAnimation()
    {
        this.animationFrame = -1;

        MoveAnimationForward();
    }

    // PRIVATE METHODS //
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(MoveAnimationForward), animationTime, animationTime);
    }

    private void MoveAnimationForward()
    {
        if (!spriteRenderer.enabled)
        {
            return;
        }

        this.animationFrame++;
        CheckAnimationFrameConditions();

      
    }

    private void CheckAnimationFrameConditions()
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



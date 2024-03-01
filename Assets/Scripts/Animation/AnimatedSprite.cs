// @Credit: https://github.com/zigurous/unity-pacman-tutorial/blob/main/Assets/Scripts/AnimatedSprite.cs
// Any modifications and errors are mine and mine alone 
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }
    public Sprite[] spritesArray;
    public float animationTime = 0.25f;
    public int AnimationFrame { get; private set; }
    public bool animationShouldLoop = true;

    // PUBLIC METHODS //

    public void RestartAnimation()
    {
        this.AnimationFrame = -1;

        MoveAnimationForward();
    }

    // PRIVATE METHODS //
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(MoveAnimationForward), animationTime, animationTime);
    }

    private void MoveAnimationForward()
    {
        if (!SpriteRenderer.enabled)
        {
            return;
        }

        this.AnimationFrame++;
        CheckAnimationFrameConditions();
    }

    private void CheckAnimationFrameConditions()
    {
        if (AnimationFrame >= spritesArray.Length && animationShouldLoop)
        {
            AnimationFrame = 0;
        }

        if (AnimationFrame >= 0 && AnimationFrame < spritesArray.Length)
        {
            SpriteRenderer.sprite = spritesArray[AnimationFrame];
        }
    }
}



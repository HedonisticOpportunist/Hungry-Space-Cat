using System.Collections;
using UnityEngine;

/* Based on, with modifications:
// @Credit: https://github.com/zigurous/unity-pacman-tutorial/blob/main/Assets/Scripts/AnimatedSprite.cs
*/

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] spritesArray;
    [SerializeField] Sprite newSprite;
    [SerializeField] float animationTime = 0.25f;
    [SerializeField] int animationFrame;
    [SerializeField] bool animationShouldLoop = true;
    HealthKeeper healthKeepr;

    void RestartAnimation()
    {
        animationFrame = -1;
        MoveAnimationForward();
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthKeepr = FindAnyObjectByType<HealthKeeper>();
    }

    void Start()
    {
        InvokeRepeating(nameof(MoveAnimationForward), animationTime, animationTime);  
    }

    private void Update()
    {
        if (healthKeepr.GetLives() == 0)
        {
            StartCoroutine(DelayChangeOfSprite());
        }
    }

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

    Sprite ChangeSprite(Sprite newSprite)
    {
        /* Based on the below, with modifications, additions and deletions:
        // @Credit: https://gamedevbeginner.com/how-to-change-a-sprite-from-a-script-in-unity-with-examples/#change_sprite_from_script
        */

        animationShouldLoop = false;
        spriteRenderer.sortingOrder = 2;  // Set sorting order to 2, so the sleeping cat sprite is always visible 
        spriteRenderer.sprite = newSprite;
        return spriteRenderer.sprite;
    }

    IEnumerator DelayChangeOfSprite()
    {
        yield return new WaitForSeconds(0.5f);
        ChangeSprite(newSprite);
    }
}



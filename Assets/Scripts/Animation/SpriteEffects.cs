using System.Collections;
using UnityEngine;

public class SpriteEffects : MonoBehaviour
{
    public IEnumerator DisplayDeathEffect(SpriteRenderer spriteRenderer, float damageDelay)
    {
        spriteRenderer.color = Color.magenta;
        yield
        return new WaitForSeconds(damageDelay);
        spriteRenderer.color = Color.white;
    }

    public IEnumerator DisplayScoreEffect(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.color = Color.cyan;
        yield
        return new WaitForSeconds(0.4f);
        spriteRenderer.color = Color.white;
    }
}
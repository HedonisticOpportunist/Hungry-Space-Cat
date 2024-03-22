using UnityEngine;

/* Based on, with minor modifications: 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/SpriteScroller.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/
public class BackgroundSpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    // OTHER VARIABLES
    Vector2 offset;
    Material backgroundMaterial;

    // PRIVATE METHODS
    void Awake()
    {
        backgroundMaterial = GetComponent<SpriteRenderer>().material;

    }
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset += offset;
    }
}

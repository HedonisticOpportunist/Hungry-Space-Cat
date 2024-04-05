using UnityEngine;

/* Based on, with minor modifications: 
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/SpriteScroller.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/
public class BackgroundSpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 _offset;
    Material _backgroundMaterial;

    void Awake()
    {
        _backgroundMaterial = GetComponent<SpriteRenderer>().material;

    }
    void Update()
    {
        _offset = moveSpeed * Time.deltaTime;
        _backgroundMaterial.mainTextureOffset += _offset;
    }
}

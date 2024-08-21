using TMPro;
using UnityEngine;

public class SpeedUIDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI speedUIText;

    void Start()
    {
        speedUIText.text = AdjustSpeed.speed.ToString();
    }

    void FixedUpdate()
    {
        speedUIText.text = AdjustSpeed.speed.ToString();
    }
}
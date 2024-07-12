using UnityEngine;
using TMPro;

/* Based on the below, with minor modifications:
// @Credit: https://www.youtube.com/watch?v=oya8_SlLXb0 
*/
public class AdjustSpeed : MonoBehaviour
{
    [Header("Adjust Speed Value")]
    [SerializeField] TextMeshProUGUI sliderValue = null;
    public static float speed = 10f;

    public void OnSliderChange(float value)
    {
        float changedValue = value;
        sliderValue.text = changedValue.ToString("0");
        speed = value; 

    }
}

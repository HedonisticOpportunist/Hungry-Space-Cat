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

    void Start()
    {
        if (PlayerPrefs.HasKey("speed"))
        {
            PlayerPrefs.SetFloat("speed", speed);
            LoadValue();
        }
        else
        {
            LoadValue();
        }
    }


    public void OnSliderChange(float value)
    {
        float changedValue = value;
        sliderValue.text = changedValue.ToString("0");
        speed = value; 

    }

    void LoadValue()
    {
        speed = PlayerPrefs.GetFloat("speed");
    }

    void SaveValue()
    {
        PlayerPrefs.SetFloat("audioVolume", speed);
    }
}

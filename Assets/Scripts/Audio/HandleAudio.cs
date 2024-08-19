using UnityEngine;
using UnityEngine.UI;

/* Handle volume implementation, based on the below: 
// @Credit:https://www.youtube.com/watch?v=yWCHaTwVblk
*/

public class HandleAudio : MonoBehaviour
{
    [SerializeField] Slider sliderVolume;

    void Start()
    {
        if (PlayerPrefs.HasKey("audioVolume"))
        {
            PlayerPrefs.SetFloat("audioVolume", 0.5f);
            LoadValue();
        }
        else
        {
            LoadValue();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = sliderVolume.value;
        SaveValue();
    }

    void LoadValue()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("audioVolume");
    }

    void SaveValue()
    {
        PlayerPrefs.SetFloat("audioVolume", sliderVolume.value);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class HandleAudio : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; 
    public void MuteSound()
    {
        AudioListener.volume = 0;

    }

    public void PlayAudio()
    {
        AudioListener.volume = 1;
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;
        AudioListener.volume = volume;
    }
}

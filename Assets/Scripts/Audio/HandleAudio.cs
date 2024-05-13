using UnityEngine;
using UnityEngine.UI;

public class HandleAudio : MonoBehaviour
{
    [Header("Volume Slider/Adjust Volume Sound")]
    [SerializeField] Slider volumeSlider;

    public void MuteSound() => AudioListener.volume = 0;

    public void PlayAudio() => AudioListener.volume = 1;
}

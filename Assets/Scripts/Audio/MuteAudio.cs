using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }

    public void MuteSound()
    {
        audioSource.mute = true;
        audioSource.volume = 0;
    }

    public void PlayAudio()
    {
        audioSource.mute = false;
        audioSource.volume = 1;
    }
}

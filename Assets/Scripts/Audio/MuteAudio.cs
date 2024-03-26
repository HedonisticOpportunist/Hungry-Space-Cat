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
    }

    public void PlayAudio()
    {
        audioSource.mute = false;
    }
}

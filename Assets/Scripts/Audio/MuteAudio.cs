using UnityEngine;

public class MuteAudio : MonoBehaviour
{ 
    public void MuteSound()
    {
        AudioListener.volume = 0;

    }

    public void PlayAudio()
    {
        AudioListener.volume = 1;
    }
}

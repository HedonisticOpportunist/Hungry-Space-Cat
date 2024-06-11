using UnityEngine;
public class HandleAudio : MonoBehaviour
{
    public void MuteSound() => AudioListener.volume = 0;

    public void PlayAudio() => AudioListener.volume = 1;
}

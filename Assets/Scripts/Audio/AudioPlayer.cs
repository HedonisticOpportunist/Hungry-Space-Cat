using UnityEngine;
using UnityEngine.SceneManagement;


/* Based on the below, with modifications, additions and deletions:
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/AudioPlayer.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class AudioPlayer : MonoBehaviour
{
    [Header("Pickup")]
    [SerializeField] AudioClip pickupClip;
    [SerializeField][Range(0f, 1f)] float pickupVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip catDamageClip;
    [SerializeField][Range(0f, 1f)] float catDamageVolume = 1f;

    [Header("Background")]
    [SerializeField] AudioSource audioSource;
    int _sceneNumber;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleBackgroundSound();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayPickupClip()
    {
        PlayAudioClip(pickupClip, pickupVolume);
    }

    public void PlayCatDamageClip()
    {
        PlayAudioClip(catDamageClip, catDamageVolume);
    }

    void PlayAudioClip(AudioClip audioClip, float volume)
    {
        if (audioClip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(audioClip, cameraPosition, volume);
        }
    }

    void HandleBackgroundSound()
    {
        _sceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (_sceneNumber < 3)
        {
            audioSource.mute = true;
        }
        if (_sceneNumber >= 3 && _sceneNumber <= 10)
        {
            audioSource.mute = false;
        }
        else
        {
            return;
        }
    }
}

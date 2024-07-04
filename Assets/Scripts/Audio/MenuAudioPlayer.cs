using UnityEngine;
using UnityEngine.SceneManagement;

/* Based on the below, with modifications, additions and deletions:
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/AudioPlayer.cs
// Part of the https://www.gamedev.tv/p/unity-2d-game-dev-course-2021 course
*/

public class MenuAudioPlayer : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] AudioSource audioSource;
    int _sceneNumber;

    static MenuAudioPlayer instance;

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

    void HandleBackgroundSound()
    {
        _sceneNumber = SceneManager.GetActiveScene().buildIndex;

        if (_sceneNumber <= 4)
        {
            Camera.main.GetComponent<AudioListener>().enabled = true;
            audioSource.UnPause();
            audioSource.mute = false;
        }
        if (_sceneNumber >= 4 && _sceneNumber <= 12)
        {
            Camera.main.GetComponent<AudioListener>().enabled = false;
            audioSource.Pause();
            audioSource.mute = true;
        }
        else
        {
            return;
        }
    }
}
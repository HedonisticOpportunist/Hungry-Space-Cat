using UnityEngine;

/* Based on the below, with minor modifications, additions and deletions:
// @Credit: https://forum.unity.com/threads/free-basic-camera-fade-in-script.509423/
// @Credit: https://gitlab.com/GameDevTV/unity2d-v3/laser-defender/-/blob/master/Assets/Scripts/AudioPlayer.cs for refactoring the singleton. 
*/

public class FadeAnimation : MonoBehaviour
{
    [Header("Fade In/Out Time, Colour and Duration Settings")]
    [SerializeField] float fadeTime = 5.0f;
    [SerializeField] Color fadeColor = new(255.0f, 255.0f, 255.0f, 1.0f);
    [SerializeField] float blackScreenDuration;

    // STATES
    bool _isFadingIn = false;
    bool _isFadingOut = false;
    float _currentTime = 0;

    float _alpha = 1.0f;
    Texture2D _texture;
    static public FadeAnimation instance;

    private void Awake() => ManageSingleton();

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

    public class Options
    {
        public float? fadeTime;
        public float? blackScreenDuration;
        public Color fadeColor;
    }

    public void SetUpFadeAnimation()
    {
        // Pause game and audio 
        Time.timeScale = 0f;
        AudioListener.pause = true;

        _texture = new Texture2D(1, 1);
        _texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, _alpha));
        _texture.Apply();
        FadeIn();

        // Resume game and audio 
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    void StartFading(bool isFadingIn, bool isFadingOut, Options options = null)
    {
        _currentTime = 0;

        if (options != null)
        {
            if (options.fadeTime != null)
            {
                fadeTime = (float)options.fadeTime;
            }

            if (options.blackScreenDuration != null)
            {
                blackScreenDuration = (float)options.blackScreenDuration;
            }

            if (options.fadeColor != null)
            {
                fadeColor = options.fadeColor;
            }
        }

        this._isFadingIn = isFadingIn;
        this._isFadingOut = isFadingOut;
    }

    void FadeIn(Options options = null)
    {
        _alpha = 1.0f;
        StartFading(true, false, options);
    }

    public void OnGUI()
    {
        if (_isFadingIn || _isFadingOut)
        {
            ShowBlackScreen();
        }
    }

    void ShowBlackScreen()
    {
        if (_isFadingIn && _alpha <= 0.0f)
        {
            _isFadingIn = false;

            return;
        }

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _texture);

        if (_isFadingIn && blackScreenDuration > 0)
        {
            blackScreenDuration -= Time.deltaTime;

            return;
        }

        if (_isFadingOut && _alpha >= 1.0f)
        {
            return;
        }

        CalculateTexture();
    }

    void CalculateTexture()
    {
        _currentTime += Time.deltaTime;

        if (_isFadingIn)
        {
            _alpha = 1.0f - (_currentTime / fadeTime);
        }
        else
        {
            _alpha = _currentTime / fadeTime;
        }

        _texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, _alpha));
        _texture.Apply();
    }
}
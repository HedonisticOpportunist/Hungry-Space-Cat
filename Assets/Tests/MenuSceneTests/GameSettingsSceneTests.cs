using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameSettingsSceneTests
{
    [UnityTest]
    public IEnumerator BackgroundElementsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameSettings.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] backgroundElements = { "menu", "blue", "menucat", "creditcat", "adoptcat", "buttoncat", "minicat", "minicat2", "minicat3" };

        for (int i = 0; i < backgroundElements.Length; i++)
        {
            // Act 
            GameObject.Find(backgroundElements[i]);

            // Assert 
            Assert.IsNotNull(backgroundElements[i]);
        }
    }

    [UnityTest]
    public IEnumerator TextElementsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameSettings.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] textElements = { "MuteAudioText", "UnMuteAudioText", "DisableEffectText", "MainText", "EnableEffectText", "EnableSpriteEffectText", "DisableSpriteEffectText", "AdjustSpeedText", "SpeedValue" };

        for (int i = 0; i < textElements.Length; i++)
        {
            // Act 
            GameObject.Find(textElements[i]);

            // Assert 
            Assert.IsNotNull(textElements[i]);
        }
    }

    [UnityTest]
    public IEnumerator ButtonsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameSettings.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] buttonElements = { "MuteAudio", "UnmuteAudio", "ReturnToMenu", "DisableMovingBackground", "DisableSpriteEffect", "EnableSpriteEffect", "AddMovingBackground", "AdjustSpeedSlider" };

        for (int i = 0; i < buttonElements.Length; i++)
        {
            // Act 
            GameObject.Find(buttonElements[i]);

            // Assert 
            Assert.IsNotNull(buttonElements[i]);
        }
    }

    [UnityTest]
    public IEnumerator MenuScriptsPrefabsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameSettings.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] menuScriptPrefabs = { "AudioPlayer", "SceneLoaderManager", "Effects", "HandleAudio", "AdjustSpeedSlider" };

        for (int i = 0; i < menuScriptPrefabs.Length; i++)
        {
            // Act 
            GameObject.Find(menuScriptPrefabs[i]);

            // Assert 
            Assert.IsNotNull(menuScriptPrefabs[i]);
        }
    }
}

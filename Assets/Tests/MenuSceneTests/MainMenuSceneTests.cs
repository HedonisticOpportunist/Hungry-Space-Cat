using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MainMenuSceneTests
{
    [UnityTest]
    public IEnumerator ButtonsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/MainMenu.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] buttonNames = { "PlayButton", "InstructionsButton", "ExitGameButton", "SettingsButton", "AdoptACat", "LeaveFeedback" };

        for (int i = 0; i < buttonNames.Length; i++)
        {
            // Act
            GameObject.Find(buttonNames[i]);

            // Assert 
            Assert.IsNotNull(buttonNames[i]);
        }
    }

    [UnityTest]
    public IEnumerator TextElementsLoadProperly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/MainMenu.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] textElements = { "MainTitle", "SecondaryText", "PlayGameText", "SettingsText", "AdoptACatText", "LeaveFeedbackText" };

        for (int i = 0; i < textElements.Length; i++)
        {

            // Act 
            GameObject.Find(textElements[i]);

            // Assert 
            Assert.IsNotNull(textElements[i]);
        }
    }

    [UnityTest]
    public IEnumerator BackgroundElementsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/MainMenu.unity", LoadSceneMode.Single);
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
    public IEnumerator MenuScriptsPrefabsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/MainMenu.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] menuScriptsPrefabs = { "AudioPlayer", "ScoreKeeper", "HealthKeeper", "SceneLoaderManager" };

        for (int i = 0; i < menuScriptsPrefabs.Length; i++)
        {
            // Act 
            GameObject.Find(menuScriptsPrefabs[i]);

            // Assert 
            Assert.IsNotNull(menuScriptsPrefabs[i]);
        }
    }
}
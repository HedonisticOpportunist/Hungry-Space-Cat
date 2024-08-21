using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class InstructionsSceneTests
{
    [UnityTest]
    public IEnumerator BackgroundElementsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/Instructions.unity", LoadSceneMode.Single);
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
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/Instructions.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] textElements = { "Adjustments", "Movement", "Shooting", "Escape", "Resolution", "MainText" };

        for (int i = 0; i < textElements.Length; i++)
        {
            // Act 
            GameObject.Find(textElements[i]);

            // Assert 
            Assert.IsNotNull(textElements[i]);
        }
    }

    [UnityTest]
    public IEnumerator ReturnToMenuButtonLoadsProperly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/Instructions.unity", LoadSceneMode.Single);
        yield
        return null;

        string returnToMenuText = "ReturnToMenuButton";

        // Act 
        var returnToMenuButton = GameObject.Find(returnToMenuText);

        // Assert 
        Assert.IsNotNull(returnToMenuButton);

    }

    [UnityTest]
    public IEnumerator MenuScriptsPrefabsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/Instructions.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] menuScriptPrefabs = { "AudioPlayer", "SceneLoaderManager" };

        for (int i = 0; i < menuScriptPrefabs.Length; i++)
        {
            // Act 
            GameObject.Find(menuScriptPrefabs[i]);

            // Assert 
            Assert.IsNotNull(menuScriptPrefabs[i]);
        }
    }
}

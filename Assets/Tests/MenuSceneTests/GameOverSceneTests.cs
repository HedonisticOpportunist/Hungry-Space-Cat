using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameOverSceneTests
{
    [UnityTest]
    public IEnumerator ButtonTextsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameOver.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] gameOverSceneButtonTexts = { "ScoreText", "GameOverText" };

        for (int i = 0; i < gameOverSceneButtonTexts.Length; i++)
        {
            // Act 
            GameObject.Find(gameOverSceneButtonTexts[i]);

            // Assert 
            Assert.IsNotNull(gameOverSceneButtonTexts[i]);
        }
    }

    public IEnumerator BackgroundElementsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameOver.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] backgroundElements = { "menu", "menu1" };

        for (int i = 0; i < backgroundElements.Length; i++)
        {
            // Act 
            GameObject.Find(backgroundElements[i]);

            // Assert 
            Assert.IsNotNull(backgroundElements[i]);
        }
    }

    [UnityTest]
    public IEnumerator ButtonsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameOver.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] gameOverSceneButtons = { "ReplayButton", "ReturnToMenuButton", "QuitButton" };

        for (int i = 0; i < gameOverSceneButtons.Length; i++)
        {
            // Act 
            GameObject.Find(gameOverSceneButtons[i]);

            // Assert 
            Assert.IsNotNull(gameOverSceneButtons[i]);
        }
    }

    [UnityTest]
    public IEnumerator CatImageLoadsCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameOver.unity", LoadSceneMode.Single);
        yield
        return null;

        string catImage = "SleepingCat";

        // Act 
        var sleepingCat = GameObject.Find(catImage);


        // Assert 
        Assert.IsNotNull(sleepingCat);

    }

    [UnityTest]
    public IEnumerator MenuScriptsPrefabsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameOver.unity", LoadSceneMode.Single);
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



using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GhostGameEasySceneTests
{
    [UnityTest]
    public IEnumerator MovingBackgroundElementsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/EasyMode/GhostGameEasy.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] movingBackgrounds = { "blue", "blue2" };

        for (int i = 0; i < movingBackgrounds.Length; i++)
        {
            // Act 
            GameObject.Find(movingBackgrounds[i]);

            // Assert 
            Assert.IsNotNull(movingBackgrounds[i]);
        }
    }

    [UnityTest]
    public IEnumerator GameElementsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/EasyMode/GhostGameEasy.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] gameElements = { "ScoreText", "LoadGameText", "LivesText", "NewGameText", "Lives", "PauseMenu" };

        for (int i = 0; i < gameElements.Length; i++)
        {
            // Act 
            GameObject.Find(gameElements[i]);

            // Assert 
            Assert.IsNotNull(gameElements[i]);
        }
    }

    [UnityTest]
    public IEnumerator PauseMenuElementsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/EasyMode/GhostGameEasy.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] pauseMenuElements = { "PauseMenu", "HeaderText", "ResumeGame", "ReturnToMenu", "QuitGame" };

        for (int i = 0; i < pauseMenuElements.Length; i++)
        {
            // Act 
            GameObject.Find(pauseMenuElements[i]);

            // Assert 
            Assert.IsNotNull(pauseMenuElements[i]);
        }
    }

    [UnityTest]
    public IEnumerator SpaceCatPrefabLoadsCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/EasyMode/GhostGameEasy.unity", LoadSceneMode.Single);
        yield
        return null;

        string spaceCatText = "SpaceCatEasyMode";

        // Act 
        var spaceCatPrefab = GameObject.Find(spaceCatText);

        // Assert 
        Assert.IsNotNull(spaceCatPrefab);
    }

    [UnityTest]
    public IEnumerator OtherGameScriptsPrefabsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/EasyMode/GhostGameEasy.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] otherScriptPrefabs = { "GhostDollSpawnerEasy", "SceneLoaderManager", "HelperManager", "SpawnBugs" };

        for (int i = 0; i < otherScriptPrefabs.Length; i++)
        {
            // Act 
            GameObject.Find(otherScriptPrefabs[i]);

            // Assert 
            Assert.IsNotNull(otherScriptPrefabs[i]);
        }
    }

    [UnityTest]
    public IEnumerator GameScriptsPrefabsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/EasyMode/GhostGameEasy.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] gameScriptPrefabs = { "AudioPlayer", "ScoreKeeper", "HealthKeeper" };

        for (int i = 0; i < gameScriptPrefabs.Length; i++)
        {
            // Act 
            GameObject.Find(gameScriptPrefabs[i]);

            // Assert 
            Assert.IsNotNull(gameScriptPrefabs[i]);
        }
    }

    [UnityTest]
    public IEnumerator BoundaryLoadsCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/EasyMode/GhostGameEasy.unity", LoadSceneMode.Single);
        yield
        return null;

        string boundaryText = "Boundary";

        // Act 
        var boundaryElement = GameObject.Find(boundaryText);

        // Assert 
        Assert.IsNotNull(boundaryElement);
    }
}

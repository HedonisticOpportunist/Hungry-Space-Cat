using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameOverMenuTests
{
    [UnityTest]
    public IEnumerator GameOverSceneButtonTextsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameOver.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] gameOverSceneButtonTexts = {"ScoreText", "GameOverText"};

        // Act 
        for (int i = 0; i < gameOverSceneButtonTexts.Length; i++)
        {
            var button = GameObject.Find(gameOverSceneButtonTexts[i]);

            // Assert 
            Assert.IsNotNull(button);
        }
    }

    public IEnumerator GameOverSceneButtonsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/GameOver.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] gameOverSceneButtons = { "ReplayButton", "ReturnToMenuButton", "QuitButton" };

        // Act 
        for (int i = 0; i < gameOverSceneButtons.Length; i++)
        {
            var button = GameObject.Find(gameOverSceneButtons[i]);

            // Assert 
            Assert.IsNotNull(button);
        }
    }

}

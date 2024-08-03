using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LoadMainMenuTests
{
    [UnityTest]
    public IEnumerator LoadMainMenuAndItsButtonsLoadCorrectly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/MainMenu.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] buttonNames = {
      "PlayButton",
      "InstructionsButton",
      "ExitGameButton",
      "SettingsButton",
      "AdoptACat",
      "LeaveFeedback"
    };

        // Act 
        for (int i = 0; i < buttonNames.Length; i++)
        {
            var button = GameObject.Find(buttonNames[i]);

            // Assert 
            Assert.IsNotNull(button);
        }
    }

    [UnityTest]
    public IEnumerator LoadMainMenuAndItsTextElementsLoadProperly()
    {
        // Arrange 
        SceneManager.LoadScene("Assets/Scenes/MenuScenes/MainMenu.unity", LoadSceneMode.Single);
        yield
        return null;

        string[] textElements = {
      "MainTitle",
      "SecondaryText",
      "PlayGameText",
      "SettingsText",
      "AdoptACatText",
      "LeaveFeedbackText"
    };

        // Act 
        for (int i = 0; i < textElements.Length; i++)
        {
            var button = GameObject.Find(textElements[i]);

            // Assert 
            Assert.IsNotNull(button);
        }
    }
}
using UnityEngine;

public class ExitScene : MonoBehaviour
{
    public void ExitGame()
    {
        // Based on, with modifications: 
        // @Credit: https://gamedevbeginner.com/how-to-quit-the-game-in-unity/ 
        // Prepreprocessor directives allow for running of different code depending on conditions 
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}

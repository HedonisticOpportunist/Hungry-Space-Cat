using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    public void LoadGame(string sceneName)
    {
        // @Credit: https://blog.insane.engineer/post/unity_button_load_scene/
        SceneManager.LoadScene(sceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    public void LoadGame(string sceneName)
    {
        //* Based on the below, with minor modifications 
        // @Credit: https://www.gamedev.tv/courses/1394720/lectures/34966901@Credit: https://blog.insane.engineer/post/unity_button_load_scene/
        SceneManager.LoadScene(sceneName);
    }
}

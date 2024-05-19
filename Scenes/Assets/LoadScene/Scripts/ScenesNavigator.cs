using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesNavigator : MonoBehaviour
{
    public void StartChosenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

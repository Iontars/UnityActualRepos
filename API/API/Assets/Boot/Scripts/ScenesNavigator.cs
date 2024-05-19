using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesNavigator : MonoBehaviour
{
    public void StartChosenScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}

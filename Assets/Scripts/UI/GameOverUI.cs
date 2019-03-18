using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public void LoadOtherScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

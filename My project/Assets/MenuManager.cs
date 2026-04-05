using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGameState();
        }

        SceneManager.LoadScene("MainScene"); // replace with your scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
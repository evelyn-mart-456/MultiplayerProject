using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoresButton : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("GameScene");
    }
}

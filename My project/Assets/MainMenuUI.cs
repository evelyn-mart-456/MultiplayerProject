using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Called when High Scores button is clicked
    public void LoadHighScores()
    {
        SceneManager.LoadScene("HighScores"); // Make sure the HighScores scene is added to Build Settings
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TMP_InputField nameInput;  // Drag your Input Field here

    private int playerScore;          // Set from GameManager

    void Start()
    {
        if (GameManager.Instance != null)
        {
            // Get the score from GameManager
            playerScore = GameManager.Instance.score;

            if (finalScoreText != null)
            {
                finalScoreText.text = "Final Score: " + playerScore;
            }
        }
    }

    // Called when Submit button is clicked
    public void OnSubmit()
    {
        string playerName = nameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        // ✅ Call the correct method
        DatabaseManager.Instance.SaveHighScore(playerName, playerScore, 0f); // 0f for completionTime if unused

        // Load HighScores scene
        SceneManager.LoadScene("HighScores");
    }

    // Called when Retry button is clicked
    public void OnRetry()
    {
        string playerName = nameInput.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            DatabaseManager.Instance.SaveHighScore(playerName, playerScore, 0f);
        }

        // Reload gameplay scene
        SceneManager.LoadScene("MainScene"); // replace with your actual gameplay scene name
    }
}
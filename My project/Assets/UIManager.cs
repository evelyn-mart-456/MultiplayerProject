using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

  void OnEnable()
{
    if (GameManager.Instance != null)
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
        GameManager.Instance.OnHealthChanged += UpdateHealth;
        GameManager.Instance.OnGameOver += HandleGameOver;

        // 🔹 Initialize the UI with the current values immediately
        UpdateScore(GameManager.Instance.score);
        UpdateHealth(GameManager.Instance.health);
    }
}

    void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= UpdateScore;
            GameManager.Instance.OnHealthChanged -= UpdateHealth;
            GameManager.Instance.OnGameOver -= HandleGameOver;
        }
    }

    void UpdateScore(int newScore)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + newScore;
        Debug.Log($"[UIManager] Score updated: {newScore}");
    }

    void UpdateHealth(int newHealth)
    {
        if (healthText != null)
            healthText.text = "Health: " + newHealth;
        Debug.Log($"[UIManager] Health updated: {newHealth}");
    }

    void HandleGameOver()
    {
        Debug.Log("[UIManager] Game Over event fired!");
        SceneManager.LoadScene("GameOver");
    }
}
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            Subscribe();
        }
        else
        {
            Debug.LogWarning("Waiting for GameManager...");
            Invoke(nameof(TrySubscribe), 0.1f);
        }
    }

    void TrySubscribe()
    {
        if (GameManager.Instance != null)
        {
            Subscribe();
        }
        else
        {
            Invoke(nameof(TrySubscribe), 0.1f);
        }
    }

    void Subscribe()
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
        GameManager.Instance.OnHealthChanged += UpdateHealth;
        GameManager.Instance.OnGameOver += HandleGameOver;

        UpdateScore(GameManager.Instance.score);
        UpdateHealth(GameManager.Instance.health);

        Debug.Log("UI subscribed to GameManager");
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
    }

    void UpdateHealth(int newHealth)
    {
        if (healthText != null)
            healthText.text = "Health: " + newHealth;
    }

    void HandleGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
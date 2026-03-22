using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int health = 100;

    // Delegates
    public delegate void ScoreChanged(int newScore);
    public delegate void HealthChanged(int newHealth);
    public delegate void GameOverDelegate();

    // Events
    public event ScoreChanged OnScoreChanged;
    public event HealthChanged OnHealthChanged;
    public event GameOverDelegate OnGameOver;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
{
    score += amount;

    Debug.Log("Score changed: " + score);

    OnScoreChanged?.Invoke(score);
}

    public void TakeDamage(int amount)
    {
        health -= amount;
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            TriggerGameOver(); // now this exists
        }
    }

    // ✅ Add this method
    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }
public void ResetGameState()
{
    score = 0;
    health = 100;

    // Fire the events internally
    OnScoreChanged?.Invoke(score);
    OnHealthChanged?.Invoke(health);
}

}

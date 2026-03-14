using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        if (GameManager.Instance != null && finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + GameManager.Instance.score;
        }
    }
}

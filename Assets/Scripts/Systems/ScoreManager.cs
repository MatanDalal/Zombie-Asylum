using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    public int CurrentScore => score;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + score;
    }
}
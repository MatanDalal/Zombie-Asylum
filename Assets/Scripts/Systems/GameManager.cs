using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game")]
    [SerializeField] private float gameTime = 60f;

    [Header("Systems")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TargetSpawner targetSpawner;
    [SerializeField] private PlayerLook playerLook;
    [SerializeField] private PlayerShooting playerShooting;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private float timeRemaining;
    private bool isGameActive = false;

    private void Start()
    {
        PrepareStartScreen();
    }

    private void Update()
    {
        if (!isGameActive)
        {
            return;
        }

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;

            UpdateTimerText();
            EndGame();

            return;
        }

        UpdateTimerText();
    }

    private void PrepareStartScreen()
    {
        isGameActive = false;
        timeRemaining = gameTime;

        scoreManager.ResetScore();
        targetSpawner.StopSpawning();

        playerShooting.enabled = false;
        playerLook.SetLookEnabled(false);

        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        UpdateTimerText();
    }

    public void StartGame()
    {
        isGameActive = true;
        timeRemaining = gameTime;

        scoreManager.ResetScore();

        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        playerShooting.enabled = true;
        playerLook.SetLookEnabled(true);

        targetSpawner.StartSpawning();

        UpdateTimerText();
    }

    private void EndGame()
    {
        isGameActive = false;

        targetSpawner.StopSpawning();

        playerShooting.enabled = false;
        playerLook.SetLookEnabled(false);

        finalScoreText.text =
            "FINAL SCORE: " + scoreManager.CurrentScore;

        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        StartGame();
    }

    private void UpdateTimerText()
    {
        timerText.text =
            "TIME: " + Mathf.CeilToInt(timeRemaining);
    }
}
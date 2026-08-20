using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieGameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;

    [SerializeField] private PlayerLook playerLook;
    [SerializeField] private PlayerShooting playerShooting;

    private ZombieHealth[] zombies;
    private int zombiesAlive;
    private bool gameEnded = false;

    private void Start()
    {
        // Prepare UI
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }

        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }

        // Disable player controls before START GAME
        if (playerLook != null)
        {
            playerLook.SetLookEnabled(false);
        }

        if (playerShooting != null)
        {
            playerShooting.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

        // Listen for player death
        if (playerHealth != null)
        {
            playerHealth.OnPlayerDied += GameOver;
        }

        // Find every zombie in the scene automatically
        zombies = FindObjectsByType<ZombieHealth>();

        zombiesAlive = zombies.Length;

        // Listen for each zombie's death
        foreach (ZombieHealth zombie in zombies)
        {
            zombie.OnZombieDied += ZombieDied;
        }

        Debug.Log($"Zombies alive: {zombiesAlive}");
    }

    public void StartGame()
    {
        gameEnded = false;

        if (startPanel != null)
        {
            startPanel.SetActive(false);
        }

        Time.timeScale = 1f;

        if (playerLook != null)
        {
            playerLook.SetLookEnabled(true);
        }

        if (playerShooting != null)
        {
            playerShooting.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ZombieDied()
    {
        if (gameEnded)
        {
            return;
        }

        zombiesAlive--;

        Debug.Log($"Zombies alive: {zombiesAlive}");

        if (zombiesAlive <= 0)
        {
            Victory();
        }
    }

    private void Victory()
    {
        gameEnded = true;

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        if (playerLook != null)
        {
            playerLook.SetLookEnabled(false);
        }

        if (playerShooting != null)
        {
            playerShooting.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    private void GameOver()
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (playerLook != null)
        {
            playerLook.SetLookEnabled(false);
        }

        if (playerShooting != null)
        {
            playerShooting.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnPlayerDied -= GameOver;
        }

        if (zombies != null)
        {
            foreach (ZombieHealth zombie in zombies)
            {
                if (zombie != null)
                {
                    zombie.OnZombieDied -= ZombieDied;
                }
            }
        }
    }
}
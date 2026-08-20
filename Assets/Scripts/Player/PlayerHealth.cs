using System;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private TextMeshProUGUI healthText;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => maxHealth;

    public event Action OnPlayerDied;

    private bool isDead = false;

    private void Awake()
    {
        CurrentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead || damage <= 0)
        {
            return;
        }

        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);

        UpdateHealthUI();

        Debug.Log($"Player Health: {CurrentHealth}/{maxHealth}");

        if (CurrentHealth == 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"HEALTH: {CurrentHealth}";
        }
    }

    private void Die()
    {
        isDead = true;

        Debug.Log("Player died");

        OnPlayerDied?.Invoke();
    }
}
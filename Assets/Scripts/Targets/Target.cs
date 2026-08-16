using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;

    public event Action OnDestroyed;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Target Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDestroyed?.Invoke();

        Destroy(gameObject);
    }
}
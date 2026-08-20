using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private int damage = 20;
    [SerializeField] private float attackDistance = 1.5f;
    [SerializeField] private float attackCooldown = 1f;

    private float nextAttackTime = 0f;

    private void Update()
    {
        if (playerHealth == null)
        {
            return;
        }

        float distance = Vector3.Distance(
            transform.position,
            playerHealth.transform.position);

        if (distance <= attackDistance && Time.time >= nextAttackTime)
        {
            playerHealth.TakeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
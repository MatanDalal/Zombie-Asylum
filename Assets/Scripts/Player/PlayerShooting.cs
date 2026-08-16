using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float shootingRange = 100f;
    [SerializeField] private int damage = 1;

    private void Update()
    {
        if (Mouse.current == null)
        {
            return;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(
            transform.position,
            transform.forward,
            out RaycastHit hit,
            shootingRange))
        {
            Debug.Log("Hit: " + hit.transform.name);

            if (hit.collider.TryGetComponent<Target>(out Target target))
            {
                target.TakeDamage(damage);
            }
        }
    }
}
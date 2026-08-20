using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float shootingRange = 100f;
    [SerializeField] private int damage = 1;

    [Header("Bullet Visual")]
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private GameObject bulletVisualPrefab;
    [SerializeField] private float bulletVisualSpeed = 60f;
    [SerializeField] private float bulletVisualLifetime = 0.2f;

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
        CreateBulletVisual();

        if (Physics.Raycast(
            transform.position,
            transform.forward,
            out RaycastHit hit,
            shootingRange))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // Old arcade target
            Target target = hit.collider.GetComponentInParent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
                return;
            }

            // Zombie
            ZombieHealth zombie =
                hit.collider.GetComponentInParent<ZombieHealth>();

            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }
        }
    }

    private void CreateBulletVisual()
    {
        if (muzzlePoint == null || bulletVisualPrefab == null)
        {
            return;
        }

        GameObject bullet = Instantiate(
            bulletVisualPrefab,
            muzzlePoint.position,
            muzzlePoint.rotation
        );

        StartCoroutine(MoveBulletVisual(bullet));
    }

    private IEnumerator MoveBulletVisual(GameObject bullet)
    {
        float timer = 0f;

        while (timer < bulletVisualLifetime && bullet != null)
        {
            bullet.transform.position +=
                transform.forward * bulletVisualSpeed * Time.deltaTime;

            timer += Time.deltaTime;

            yield return null;
        }

        if (bullet != null)
        {
            Destroy(bullet);
        }
    }
}
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;

    [SerializeField] private float minZ = 3f;
    [SerializeField] private float maxZ = 15f;

    private GameObject currentTarget;
    private bool canSpawn = false;

    public void StartSpawning()
    {
        canSpawn = true;

        if (currentTarget == null)
        {
            SpawnTarget();
        }
    }

    public void StopSpawning()
    {
        canSpawn = false;

        if (currentTarget != null)
        {
            Destroy(currentTarget);
            currentTarget = null;
        }
    }

    private void SpawnTarget()
    {
        if (!canSpawn)
        {
            return;
        }

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 spawnPosition =
            new Vector3(randomX, 0.5f, randomZ);

        currentTarget = Instantiate(
            targetPrefab,
            spawnPosition,
            Quaternion.identity
        );

        Target target = currentTarget.GetComponent<Target>();

        if (target != null)
        {
            target.OnDestroyed += HandleTargetDestroyed;
        }
    }

    private void HandleTargetDestroyed()
    {
        if (!canSpawn)
        {
            return;
        }

        scoreManager.AddPoint();

        currentTarget = null;

        SpawnTarget();
    }
}
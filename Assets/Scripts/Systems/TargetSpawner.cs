using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;

    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;

    [SerializeField] private float minZ = 3f;
    [SerializeField] private float maxZ = 15f;

    private void Start()
    {
        SpawnTarget();
    }

    private void SpawnTarget()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 spawnPosition =
            new Vector3(randomX, 0.5f, randomZ);

        GameObject targetObject = Instantiate(
            targetPrefab,
            spawnPosition,
            Quaternion.identity
        );

        Target target = targetObject.GetComponent<Target>();

        if (target != null)
        {
            target.OnDestroyed += HandleTargetDestroyed;
        }
    }

    private void HandleTargetDestroyed()
    {
        SpawnTarget();
    }
}
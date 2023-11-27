using System.Collections;
using UnityEngine;

public class AdvancedEnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _target;
    [SerializeField] private AdvancedEnemyMovement _enemyTemplate;

    private WaitForSeconds _WaitTimeToSpawn;

    private void Start()
    {
        _WaitTimeToSpawn = new WaitForSeconds(_spawnDelay);

        StartCoroutine(SpawnEnemies());
    }

    private void OnDestroy()
    {
        StopCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return _WaitTimeToSpawn;

            var enemy = Instantiate(_enemyTemplate, transform.position, Quaternion.identity);
            enemy.SetTarget(_target);
        }
    }
}

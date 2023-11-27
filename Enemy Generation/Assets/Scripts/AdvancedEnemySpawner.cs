using System.Collections;
using UnityEngine;

public class AdvancedEnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _target;
    [SerializeField] private AdvancedEnemyMovement _enemyTemplate;

    private GameObject[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new GameObject[transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = transform.GetChild(i).gameObject;
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);

            var enemy = Instantiate(_enemyTemplate, transform.position, Quaternion.identity);
            enemy.SetTarget(_target);
        }
    }
}

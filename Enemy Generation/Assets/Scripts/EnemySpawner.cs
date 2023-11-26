using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _minEnemyRotationAgnle;
    [SerializeField] private float _maxEnemyRotationAgnle;
    [SerializeField] private GameObject _enemyTemplate;

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

            GameObject spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            float enemyRotationAngle = Random.Range(_minEnemyRotationAgnle, _maxEnemyRotationAgnle);

            GameObject enemy = Instantiate(_enemyTemplate, spawnPoint.transform.position, Quaternion.identity);
            enemy.transform.Rotate(new Vector3(0f, enemyRotationAngle, 0f));
        }
    }
}

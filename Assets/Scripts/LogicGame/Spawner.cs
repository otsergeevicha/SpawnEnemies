using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;

    private Coroutine _activationEnemies;
    private float _spawnChangeTime = 2;

    private void Awake()
    {
        _activationEnemies = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForSeconds = new WaitForSeconds(_spawnChangeTime);

        foreach (var spawnPoint in _spawnPoints)
        {
            Instantiate(_enemy, spawnPoint.position, Quaternion.identity);

            yield return waitForSeconds;
        }

        StopCoroutine(_activationEnemies);
    }
}
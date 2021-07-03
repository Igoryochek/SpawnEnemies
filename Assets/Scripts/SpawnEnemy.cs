using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Vector2 _minimalPosition;
    [SerializeField] private Vector2 _maximalPosition;
    [SerializeField] private GameObject[] _enemyTemplates;

    private Coroutine _instantiateEnemy;
    private Vector2 _position;

    private void Start()
    {
        _instantiateEnemy = StartCoroutine(InstantiateEnemy());
    }

    private void Update()
    {
        StopSpawn();
    }

    private IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            int randomEnemyIndex = Random.Range(0, _enemyTemplates.Length);
            _position.x = Random.Range(_minimalPosition.x, _maximalPosition.x);
            _position.y = Random.Range(_minimalPosition.y, _maximalPosition.y);
            Instantiate(_enemyTemplates[randomEnemyIndex], _position, _enemyTemplates[randomEnemyIndex].transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }

    private void StopSpawn()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StopCoroutine(_instantiateEnemy);
        }
    }
}

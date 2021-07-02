using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Vector2 _minimalPosition;
    [SerializeField] private Vector2 _maximalPosition;
    [SerializeField] private GameObject[] _enemieTemplates;

    private bool _isNeedInstantiate=true;
    private float _positionX;
    private float _positionY;
   
    private void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    private void Update()
    {
        StopInstantiate();
    }

    private IEnumerator InstantiateEnemy()
    {
        while (_isNeedInstantiate)
        {
            int randomEnemyIndex = Random.Range(0, _enemieTemplates.Length);
            _positionX = Random.Range(_minimalPosition.x, _maximalPosition.x);
            _positionY = Random.Range(_minimalPosition.y, _maximalPosition.y);
            Vector2 enemyPosition = new Vector2(_positionX, _positionY);
            Instantiate(_enemieTemplates[randomEnemyIndex], enemyPosition, _enemieTemplates[randomEnemyIndex].transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }

    private void StopInstantiate()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            _isNeedInstantiate = false;
        }
    }
}

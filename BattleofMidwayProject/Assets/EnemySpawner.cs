using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Wave
{
    public string _waveName;
    public int _noOfEnemies;
    public GameObject[] _typeOfEnemies;
    public float _spawnInterval;
}


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Wave [] _waves;
    public Transform[] _spawnPoints;

    private Wave _currentWave;
    private int _currentWaveNo;
    private float _nextSpawnTime;
    private bool _hasPrepared;
    private bool _canSpawn;

    private void Start()
    {
        _canSpawn = true;
        _hasPrepared = false;
      
    }

    private void Update()
    {
        _currentWave = _waves[_currentWaveNo];

        if (!_hasPrepared)
        {
            prepareWave();
            _hasPrepared = true;
        }
            
        SpawnWave();

        if(!_canSpawn && _currentWaveNo + 1 != _waves.Length)
        {
            _currentWaveNo++;
            _canSpawn = true;
        }
    }

    void prepareWave()
    {
        GameObject _randomEnemy = _currentWave._typeOfEnemies[Random.Range(0, _currentWave._typeOfEnemies.Length)];
        Transform _randomPoint  = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Debug.Log("preparei");
        SimplePool.Preload(_randomEnemy, 30);
    }

    void SpawnWave()
    {

        if (_canSpawn && _nextSpawnTime < Time.time)
        {
            GameObject _randomEnemy = _currentWave._typeOfEnemies[Random.Range(0, _currentWave._typeOfEnemies.Length)];
            Transform _randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
           SimplePool.Spawn(_randomEnemy, _randomPoint.position, Quaternion.identity);
            Debug.Log("spawn");
            _currentWave._noOfEnemies--;
            _nextSpawnTime = Time.time + _currentWave._spawnInterval;
            if(_currentWave._noOfEnemies == 0)           
                _canSpawn = false;
            

        }
        
    }
}

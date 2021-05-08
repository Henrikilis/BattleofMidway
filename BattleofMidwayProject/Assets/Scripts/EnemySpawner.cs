using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Wave Class
[System.Serializable]
public class Wave
{
    [Header("Wave System")]
    public string _waveName;
    public int _noOfEnemies;
    public GameObject[] _typeOfEnemies;
    public float _spawnInterval;
}


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Wave [] _waves;
    public Animator _animator;
    public Transform[] _spawnPoints;
    public TMP_Text _waveName;

    private Wave _currentWave;
    private int _currentWaveNo;
    private float _nextSpawnTime;
    private bool _hasPrepared;
    private bool _canSpawn;
    private bool _canAnimate;

    

    private void Start()
    {
        _canSpawn = true;
        _hasPrepared = false;
        _canAnimate = false;
      
    }

    private void Update()
    {
        _currentWave = _waves[_currentWaveNo];

        // Preload pool of enemies
        if (!_hasPrepared)
        {
            prepareWave();
            _hasPrepared = true;
        }
        if (_canSpawn && _nextSpawnTime < Time.time)
        {
            SpawnWave();
        }

        GameObject [] _totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Check to next wave
        if(_totalEnemies.Length == 0 && !_canSpawn && _currentWaveNo + 1 != _waves.Length && _canAnimate)
        {
            _waveName.text = _waves[_currentWaveNo + 1]._waveName;
            _animator.SetTrigger("waveComplete");         
            _canAnimate = false;
        }
    }

    void SpawnNextWave()
    {
        _currentWaveNo++;
        _canSpawn = true;
    }

    void prepareWave()
    {
        GameObject _randomEnemy = _currentWave._typeOfEnemies[Random.Range(0, _currentWave._typeOfEnemies.Length)];
        Transform _randomPoint  = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
       
        SimplePool.Preload(_randomEnemy, 30);
    }

    void SpawnWave()
    {      
            GameObject _randomEnemy = _currentWave._typeOfEnemies[Random.Range(0, _currentWave._typeOfEnemies.Length)];
            Transform _randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            SimplePool.Spawn(_randomEnemy, _randomPoint.position, Quaternion.identity);
           // Instantiate(_randomEnemy, _randomPoint.position, Quaternion.identity);
        
            _currentWave._noOfEnemies--;
            _nextSpawnTime = Time.time + _currentWave._spawnInterval;
            //Check to end spawns on current wave
            if(_currentWave._noOfEnemies == 0)           
                _canSpawn = false;
                _canAnimate = true;      
        
    }
}

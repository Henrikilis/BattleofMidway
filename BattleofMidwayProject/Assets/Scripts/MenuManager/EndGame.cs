using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject[] _deSpawn;
    public GameObject[] _spawn;

    public void  endGame()
    {
        for (int i = 0; i < _deSpawn.Length; i++)
        {
            _deSpawn[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < _spawn.Length; i++)
        {
            _spawn[i].gameObject.SetActive(true);
        }
    }
}

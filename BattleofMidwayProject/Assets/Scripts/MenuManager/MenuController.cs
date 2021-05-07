using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject [] _deSpawn;
    public GameObject [] _spawn;

    public static bool _gameIsPaused = false;

    void Start()
    {
        
    }

    public void PlayGame()
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

    public void QuitGame()
    {
        Application.Quit();
    }
   
}

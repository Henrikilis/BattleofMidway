using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    public static bool _gameIsPaused = false;
    public GameObject[] _spawn;

    void Start()
    {
        
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_gameIsPaused)
            {
                ResumeGame();
            } else
            {
                FreezeGame();
            }

        }

    }

    public void FreezeGame()
    {
        for (int i = 0; i < _spawn.Length; i++)
        {
            _spawn[i].gameObject.SetActive(true);
        }

        Time.timeScale = 0;
        _gameIsPaused = true;

    }
    public void ResumeGame()
    {
        for (int i = 0; i < _spawn.Length; i++)
        {
            _spawn[i].gameObject.SetActive(false);
        }
        Time.timeScale = 1;
        _gameIsPaused = false;
    }
    
}

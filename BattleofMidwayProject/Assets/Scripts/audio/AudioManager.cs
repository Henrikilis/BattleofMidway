using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public  AudioClip _explosion;
    public  AudioClip _gameOver;
    public  AudioClip _powerUp;
    public  AudioClip _bossAttack2;

    [SerializeField]
    private AudioSource _as;



    void Start()
    {
        _as = GetComponent<AudioSource>(); 
    }

   public void PlaySound(string clip)
   {
        switch (clip)
        {
            case "explosion":
                _as.volume = 0.1f;
                _as.PlayOneShot(_explosion);
                break;
            case "gameover":
                _as.volume = 1f;
                _as.PlayOneShot(_gameOver);
                break;
            case "powerup":
                _as.volume = 0.5f;
                _as.PlayOneShot(_powerUp);
                break;
            case "bossattack2":
                _as.volume = 0.4f;
                _as.PlayOneShot(_bossAttack2);
                break;
        }
   }
}

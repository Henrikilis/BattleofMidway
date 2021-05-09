using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static int _score;
    [SerializeField]
    public static TMP_Text _scoreText;


    void Start()
    {
        _score = 0;
        _scoreText = GetComponent<TMP_Text>();
        _scoreText.text = _score.ToString();
    }

    public static void updateScore(int value)
    {
        _score += value;
        _scoreText.text = _score.ToString();
    }
   
}

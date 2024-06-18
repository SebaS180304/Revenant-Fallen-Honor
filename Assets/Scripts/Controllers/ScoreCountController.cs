using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class ScoreCountController : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    private int score;

    void Start()
    {
        score = 0;
    }
    void Update()
    {
        UpdateScore();
    }

    public void AddScore(int newScore){
        score += newScore;
    }

    public void UpdateScore(){
        ScoreText.text = "Score: " + score;
    }
}

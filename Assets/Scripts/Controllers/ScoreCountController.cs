using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCountController : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI scoreText;

    private void Start() {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        scoreText.text = score.ToString("0");
    }

    public void AddScore(int addscore){
        score += addscore;
    }
}

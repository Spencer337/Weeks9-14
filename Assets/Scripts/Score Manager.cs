using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    // Increase score by one, and update the displayed score
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}

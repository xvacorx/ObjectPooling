using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public float pointsPerSecond = 1f;
    private float currentScore = 0f;
    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
        UpdateScoreUI();
    }

    void Update()
    {
        currentScore += pointsPerSecond * Time.deltaTime;
        UpdateScoreUI();
        CheckHighScore();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(currentScore).ToString();
    }
    private void CheckHighScore()
    {
        if (Mathf.FloorToInt(currentScore) > highScore)
        {
            highScore = Mathf.FloorToInt(currentScore);
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
    public void ResetScore()
    {
        currentScore = 0f;
        UpdateScoreUI();
    }
}
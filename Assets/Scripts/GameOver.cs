using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{    
    // Text Meshes
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;

    // Start method
    void Start()
    {
        // Retrieve the last score from PlayerPrefs
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        if (pointsText != null)
        {

            pointsText.text = "Score: " + lastScore.ToString();

        }
        // Retrieve the high score from PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Check if the last score is higher than the current high score
        if (lastScore > highScore)
        {
            // Update the high score
            highScore = lastScore;

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        // Display the high score
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
    // PlayAgain method
    public void OnPlayAgainButton()
    {
        Score.scorecount = 0;
        SceneManager.LoadScene(1);
    }

    // Quit method
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

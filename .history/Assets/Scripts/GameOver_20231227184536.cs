using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnPlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }
  
    public void OnQuitButton()
    {
        Application.Quit();
    }
}

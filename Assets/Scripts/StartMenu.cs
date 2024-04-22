using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
  
  public void StartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void Leaderboard()
  {
    PlayerPrefs.SetInt("score", -1);
    SceneManager.LoadScene("Leaderboard");
  }
}

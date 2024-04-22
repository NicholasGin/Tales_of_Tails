using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.name == "Player")
    {
      CompleteLevel();
    }

    
  }
  private void CompleteLevel()
  {
    Debug.Log("finish");
    Time.timeScale = 0;
    //leaderboardUI.gameObject.SetActive(true);
    SceneManager.LoadScene("Leaderboard");
  }
}

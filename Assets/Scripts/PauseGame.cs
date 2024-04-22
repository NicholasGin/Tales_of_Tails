using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
  [SerializeField] GameObject pauseMenu;

  public static bool isPaused = false;

  
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (isPaused)
      {
        Resume();
      }
      else
      {
        Pause();
      }
    }
  }

  public void Resume()
  {
    Debug.Log("Resume game");
    pauseMenu.SetActive(false);
    Time.timeScale = 1;
    isPaused = false;
  }
  private void Pause()
  {
    Debug.Log("pause game");
    pauseMenu.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;
  }

  public void Restart()
  {
    Debug.Log("Restarting");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Resume();
    
  }

  public void OnApplicationQuit()
  {
    Debug.Log("See you soon");
    Application.Quit();
  }

}

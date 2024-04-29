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
    //SceneManager.LoadScene(); load level finish, collectible scene
  }
}

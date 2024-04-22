
using TMPro;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
  private int pineapples = 0;
  public int score = 0;
  public TextMeshProUGUI pineapplesText;
    [SerializeField] AudioSource collectSFX;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Pineapple"))
    {
      collectSFX.Play();
      Destroy(collision.gameObject);
      pineapples++;
      score = pineapples * 25;
      PlayerPrefs.SetInt("score", score);
      pineapplesText.text = "Points " + score;
    }
  }

  public int Score()
  {
    return score;
  }
}

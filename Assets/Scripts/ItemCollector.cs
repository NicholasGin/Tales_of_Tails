
using TMPro;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
    public int score = 0;
    private int numPineapples;
    public TextMeshProUGUI ScoreText;
    [SerializeField] AudioSource collectSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectSFX.Play();
            Destroy(collision.gameObject);
            numPineapples++;
            SetScore(25);
            PlayerPrefs.SetInt("score", score);
            ScoreText.text = "Points " + score;
        }
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSFX.Play();
            Destroy(collision.gameObject);
            SetScore(100);
            PlayerPrefs.SetInt("score", score);
            ScoreText.text = "Points " + score;

        }
    }

    public int GetPineapples()
		{
        return numPineapples;
		}
    public void SetScore(int val)
		{
        score += val;
		}

    public int GetScore()
    {
        return score;
    }
}


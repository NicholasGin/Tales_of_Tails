using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
  private Animator anim;
  private Rigidbody2D rb;
  private BoxCollider2D bc;
  [SerializeField] private AudioSource dieSFX;


  private void Start()
  {
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    bc = GetComponent<BoxCollider2D>();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Trap"))
    {
      RespawnAtCheckpoint();
      Die();
    }
  }

    private void RespawnAtCheckpoint()
		{
        Vector2 respawnPosition = Checkpoint.GetActiveCheckPointPos();
        rb.position = respawnPosition;

    }
    private void Die()
  {
        dieSFX.Play();

        anim.SetTrigger("death");
        //rb.bodyType = RigidbodyType2D.Static;
        bc.gameObject.SetActive(false);

        restartLevel();
  }

  private void restartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
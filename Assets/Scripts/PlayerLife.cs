using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
  private Animator anim;
  private Rigidbody2D rb;
  private BoxCollider2D bc;

  private GameMaster gm;

  [SerializeField] private AudioSource dieSFX;


  private void Start()
  {
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    bc = GetComponent<BoxCollider2D>();

    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    transform.position = gm.lastCheckpointPos;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Trap"))
    {
      Die();
    }
  }

    private void Die()
  {
        dieSFX.Play();

        anim.SetTrigger("death");
        //rb.bodyType = RigidbodyType2D.Static;
        bc.gameObject.SetActive(false); // prob why theres 2 player obj

        restartLevel();
  }

  private void restartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
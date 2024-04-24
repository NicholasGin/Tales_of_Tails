using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
		//public bool isActivated = false;
		private Animator anim;
		[SerializeField] private AudioSource CheckpointSFX;
		private GameMaster gm;


		private void Start()
		{
				anim = GetComponent<Animator>();
				gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
				if (collision.gameObject.CompareTag("Player"))
				{
						gm.lastCheckpointPos = transform.position;
						anim.SetBool("CheckpointFlag", true);

						if (CheckpointSFX != null)
						{
								CheckpointSFX.Play();
						}
				}
		}
}

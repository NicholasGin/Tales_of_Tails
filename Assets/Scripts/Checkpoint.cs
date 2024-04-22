using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
		public bool isActivated = false;
		private Animator anim;
		[SerializeField] private AudioSource CheckpointSFX;


		private void Start()
		{
				anim = GetComponent<Animator>();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
				if (collision.gameObject.CompareTag("Player"))
				{
						ActivateCheckpoint();
						Debug.Log(gameObject.name + collision.gameObject.transform.position);
				}
		}

		private void ActivateCheckpoint()
		{
				GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
				
				foreach (GameObject cp in checkpoints)
				{
						Checkpoint cpScript = cp.GetComponent<Checkpoint>();
						if(cpScript !=null)
						{
								cpScript.isActivated = true;
								anim.SetBool("CheckpointFlag", true);

						} else
						{
								cp.GetComponent<Checkpoint>().Deactivate();
								cpScript.anim.SetBool("CheckpointFlag", false);

						}
				}

				if (CheckpointSFX != null)
				{

						CheckpointSFX.Play();
				}
		}

		private void Deactivate()
		{
				isActivated = false;
				anim.SetBool("CheckpointFlag", false);
		}

		public static Vector2 GetActiveCheckPointPos()
		{
				Vector2 result = new Vector2((float)-24.3, (float)-0.5);
				GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");


				foreach (GameObject cp in checkpoints)
				{
						if (cp.gameObject.GetComponent<Checkpoint>().isActivated)
						{
								result = cp.transform.position;
						}
				}
				
				return result;
		}
}

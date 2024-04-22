using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
		public Rigidbody2D rb;
		public Animator anim;
		public float distance;
		public float resetSpeed = 1f;
		bool isFalling = false;
		bool isOnGround = false;
		private Vector2 originalPos;
		

		private enum BlockState {idle, blink, hitBottom, hitTop, hitLeft, hitRight} 
		void Start()
		{
				rb = GetComponent<Rigidbody2D>();
				anim = GetComponent<Animator>();
				originalPos = transform.position;

				anim.SetInteger("state", 0);
		}

	//TODO: if (tag collides with raycast): blink anim start
	//      if (tag colides with ground): collide anim start
		private void Update()
		{
				Physics2D.queriesStartInColliders = false;
				if (!isFalling)
				{
						RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
						Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
						// player walks under block
						if(hit.transform.tag != null)
						{
								if (hit.transform.tag == "Player")
								{
										anim.SetInteger("state", 1);

										rb.gravityScale = 5;
										isFalling = true;
										isOnGround = true;
								}
						}
						
						
				}

				//if (isOnGround)
				//{
				//		StartCoroutine(ResetBlock());
				//}
		}
		private void OnCollisionEnter2D(Collision2D collision)
		{
				if (collision.gameObject.tag == "Ground")
				{
						anim.SetInteger("state", 1);
						StartCoroutine(ResetBlock());
				}
		}

		IEnumerator ResetBlock()
		{
				yield return new WaitForSeconds(1.5f);
				float elapsedTime = 0f;
				while (elapsedTime <= 0.5f)
				{
						transform.position = Vector2.Lerp(transform.position, originalPos, elapsedTime);
						elapsedTime += Time.deltaTime * resetSpeed;
						yield return null;

				}
				transform.position = originalPos;
				rb.gravityScale = 0f;
				rb.velocity = Vector2.zero;
				isOnGround = false;
				isFalling = false;
				Physics2D.queriesStartInColliders = true;
		}
}

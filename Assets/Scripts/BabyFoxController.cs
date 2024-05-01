using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyFoxController : MonoBehaviour
{
    private Animator anim;
		private float chanceVal = 0.3f;

		private void Start()
		{
				anim = GetComponent<Animator>();
				StartCoroutine(Animate());

		}

		IEnumerator Animate()
		{
				while (true)
				{
						anim.SetTrigger("Sleep");

						if (Random.value < chanceVal)
						{
								anim.SetTrigger("Look");
						}

						yield return new WaitForSeconds(Random.Range(1f, 3f));
				}
		}
	
}

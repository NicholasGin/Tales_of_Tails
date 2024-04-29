using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyFoxController : MonoBehaviour
{
    private Animator anim;
		private float chanceVal;
		private float rng;

		private void Start()
		{
				anim = GetComponent<Animator>();
				chanceVal = 0.5f;
		}

		private void Update()
		{
				StartCoroutine(LookAround());
		}
		//check every second
		// if chance >= 0.5

		IEnumerator LookAround()
		{
				Debug.Log("random yes");
				yield return new WaitForSeconds(10f);
				anim.SetBool("Chance", true);
				//rng = Random.value;
				//if(rng >= chanceVal)
				//{
				//		Debug.Log("random yes");
				//		//start anim
				//		anim.Play("Chance");
				//}
		}
}

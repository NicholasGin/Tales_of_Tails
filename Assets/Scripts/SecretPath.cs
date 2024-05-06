using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPath : MonoBehaviour
{
    public List<GameObject> spikes;

		private void OnTriggerEnter2D(Collider2D collision)
		{
				Debug.Log("Spikes away");
				foreach (GameObject obj in spikes)
				{
						Destroy(obj);
				}
		}

}

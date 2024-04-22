using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
	public GameObject text;
	

	private void Start()
	{
		text.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// if sign collides wth player, text on that sign will display
		if (collision.gameObject.CompareTag("Player"))
		{
			text.SetActive(true);
			Debug.Log("text appear");
		}
			
	}
	

	private void OnTriggerExit2D(Collider2D collision)
	{
		text.SetActive(false);

	}
}

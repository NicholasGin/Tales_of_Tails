using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxBreak : MonoBehaviour
{
    public List<GameObject> cornerSprites;
		public GameObject babyFoxPayment;

		private void Start()
		{
				foreach (GameObject sprite in cornerSprites)
				{
						sprite.SetActive(false);
				}
		}

		public void BreakBox()
		{
				foreach (GameObject sprite in cornerSprites)
				{
						sprite.SetActive(true);
				}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
				//open menu
				OpenPineapplesMenu();
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
				//close menu
		}

		public void OpenPineapplesMenu()
		{
				babyFoxPayment.SetActive(true);
		}
}

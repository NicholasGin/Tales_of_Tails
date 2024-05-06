using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BoxBreak : MonoBehaviour
{
		public List<GameObject> cornerSprites;
		public GameObject babyFoxPayment;
		public ItemCollector itemCollector;
		public Button feedBtn;
		public TMP_Text feedText;
		private int pineapples;
		

		private void Start()
		{
				foreach (GameObject sprite in cornerSprites)
				{
						sprite.SetActive(false);
				}

				babyFoxPayment.gameObject.SetActive(false);
		}

		public void BreakBox()
		{
				foreach (GameObject sprite in cornerSprites)
				{
						sprite.SetActive(true);
				}

				StartCoroutine(DestroyBox());
				
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
				//open menu
				OpenPineapplesMenu();
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
				//close menu
				ClosePineapplesMenu();
		}

		public void OpenPineapplesMenu()
		{
				Color red = new Vector4(0.7849056f, 0.3463522f, 0.3317337f, 1f);
				Color green = new Vector4(0.447f, 0.631f, 0.114f, 1f);

				babyFoxPayment.SetActive(true);
				pineapples = itemCollector.GetPineapples();

				if (pineapples < 5)
				{
						// if <5, change text to say, not enough pinepplaes
						// button shows Not enough pineapples, changes red = #C95955, green = #72a11d
						feedBtn.image.color = red;
						feedText.text = "Need More Food!";
						feedText.fontSize = 28;

				}
				else if (pineapples >= 5)
				{
						// if >5, total -= 5, box disappears
						feedBtn.image.color = green;
						feedText.text = "Feed Fox";
						feedText.fontSize = 29;
				}


		}

		public void ClosePineapplesMenu()
		{
				babyFoxPayment.SetActive(false);
		}

		IEnumerator DestroyBox()
		{
				yield return new WaitForSeconds(1);
				foreach (GameObject sprite in cornerSprites)
				{
						Destroy(sprite);
				}

				Destroy(this.gameObject);
		}
		
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;


public class InputWindow : MonoBehaviour
{
  private HighscoreTable hsTable;
  private InputField nameInput;
  private ItemCollector itemCollector;
  private Canvas leaderboardUI;
  public Canvas inputCanvas;
  public Canvas hsCanvas;
  private string nameIn;
  private int score;
  GameObject player;  

  public void Start()
  {
    hsTable = FindAnyObjectByType<HighscoreTable>();
    inputCanvas = GameObject.Find("addNameCanvas").GetComponent<Canvas>();
    hsCanvas = GameObject.Find("highscoreCanvas").GetComponent<Canvas>();
    nameInput = GameObject.Find("InputField (Legacy)").GetComponent<InputField>();
    player = GameObject.Find("Player");
    leaderboardUI = GameObject.Find("LeaderboardUI").GetComponent<Canvas>();

    itemCollector = player.GetComponent<ItemCollector>();

    leaderboardUI.gameObject.SetActive(true);
   

    //hsCanvas.gameObject.SetActive(true);
    //inputCanvas.gameObject.SetActive(true);

  }
  //public void ReadInput(string input)
  //{
  //  nameInput = input;
  //  Debug.Log(input);
  //}


  public void OnOkClick()
  {
    nameIn = nameInput.text.ToUpper();
    
    score = PlayerPrefs.GetInt("score");
    SubmitBtn(nameIn, score);

  }
  public void OnCancelClick()
  {
    inputCanvas.gameObject.SetActive(false);
  }

  private void SubmitBtn(string name, int score)
  {
   
    Debug.Log(name + score);
    hsTable.AddHighscore(score, name);
    inputCanvas.gameObject.SetActive(false);
        
  }

}

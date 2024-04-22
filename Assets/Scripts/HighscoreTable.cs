using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
  private Transform entryContainer;
  private Transform entryTemplate;
  private List<HighscoreEntry> hsList;
  public List<Transform> hsTransformList;
  public Canvas inputCanvas;


  private void Awake()
  {
    entryContainer = transform.Find("highscoreContainer");
    entryTemplate = entryContainer.Find("highscoreEntryTemplate");
    entryTemplate.gameObject.SetActive(false);
    hsTransformList = new List<Transform>();
    inputCanvas = GameObject.Find("addNameCanvas").GetComponent<Canvas>();

    if (PlayerPrefs.GetInt("score") == -1)
    {
      inputCanvas.enabled = false;
    }

    loadTable();
    

    
  }
  private void AddHsEntryTransform(HighscoreEntry hsEntry, Transform container, List<Transform> transformList)
  {
    float templateHeight = 30f;
    Transform entryTransform = Instantiate(entryTemplate, container);
    RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
    entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
    entryTransform.gameObject.SetActive(true);


    int rank = transformList.Count + 1;
    string rankString;

    switch (rank)
    {
      default:
        rankString = rank + "th"; break;
      case 1: rankString = "1st"; break;
      case 2: rankString = "2nd"; break;
      case 3: rankString = "3rd"; break;

    }

    entryTransform.Find("rankText").GetComponent<Text>().text = rankString;

    string name = hsEntry.name;
    entryTransform.Find("nameText").GetComponent<Text>().text = name;

    int score = hsEntry.score;
    entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

    entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

    if (rank == 1)
    {
      entryTransform.Find("nameText").GetComponent<Text>().color = Color.yellow;
      entryTransform.Find("rankText").GetComponent<Text>().color = Color.yellow;
      entryTransform.Find("scoreText").GetComponent<Text>().color = Color.yellow;
    }


    transformList.Add(entryTransform);
  }
  public void AddHighscore(int score, string name)
  {
    // create highscore entry
    HighscoreEntry hsEntry = new HighscoreEntry { score = score, name = name };

    // load saved highscores
    string jsonString = PlayerPrefs.GetString("highscoreTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    if (highscores == null)
    {
      highscores = new Highscores()
      {
        highscoreEntryList = new List<HighscoreEntry>()
      };
    }

    // add new entry
    highscores.highscoreEntryList.Add(hsEntry);

    // save
    string json = JsonUtility.ToJson(highscores);
    PlayerPrefs.SetString("highscoreTable", json);
    PlayerPrefs.Save();

    loadTable();

    //hsList = highscores.highscoreEntryList;
  }
  private class Highscores
  {
    public List<HighscoreEntry> highscoreEntryList;
  }
  [Serializable]
  private class HighscoreEntry : IComparable<HighscoreEntry>
  {
    public int score;
    public string name;

    public int CompareTo(HighscoreEntry obj)
    {
      return obj.score.CompareTo(score);
    }
  }

  private void loadTable()
  {
    string jsonString = PlayerPrefs.GetString("highscoreTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    hsList = highscores != null ? highscores.highscoreEntryList : new List<HighscoreEntry>();

    // sort
    hsList.Sort();
    if (highscores.highscoreEntryList.Count > 10)
    {
      for (int j = highscores.highscoreEntryList.Count; j > 10; j--)
      {
        highscores.highscoreEntryList.RemoveAt(10);
      }
    }

    foreach(Transform t in hsTransformList)
    {
      Destroy(t.gameObject);
    } 
    hsTransformList = new List<Transform>();

    foreach (HighscoreEntry entry in hsList)
    {
      AddHsEntryTransform(entry, entryContainer, hsTransformList);
    }
  }
}

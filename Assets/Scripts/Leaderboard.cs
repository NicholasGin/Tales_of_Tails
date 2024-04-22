using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard: MonoBehaviour
{
  private Transform entryCon;
  private Transform entryTemp;
  private List<Transform> leaderboardEntryTransformList;

  public static string recentName;
  public static int recentScore;
  public static bool newScore;

  private void Awake()
  {
    entryCon = transform.Find("EntryContainer");
    entryTemp = entryCon.Find("EntryTemplate");
    entryTemp.gameObject.SetActive(false);

    if (newScore)
    {
      AddScoreEntry(recentName, recentScore);
      newScore = false;
    }

    string jsonString = PlayerPrefs.GetString("leaderboardTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    // sort
    for (int i = 0; i < highscores.leaderboardEntryList.Count; i++)
    {
      for (int j = i + 1; j < highscores.leaderboardEntryList.Count; j++)
      {
        if (highscores.leaderboardEntryList[j].score > highscores.leaderboardEntryList[i].score)
        {
          LeaderboardEntry temp = highscores.leaderboardEntryList[i];
          highscores.leaderboardEntryList[i] = highscores.leaderboardEntryList[j];
          highscores.leaderboardEntryList[j] = temp;
        }
      }
    }

    leaderboardEntryTransformList = new List<Transform>();
    foreach (LeaderboardEntry leaderboardEntry in highscores.leaderboardEntryList)
    {
      CreateLeaderboardEntryTransform(leaderboardEntry, entryCon, leaderboardEntryTransformList);
    }
  }

  private void CreateLeaderboardEntryTransform(LeaderboardEntry leaderboardEntry, Transform con, List<Transform> transformList)
  {

    float templateHeight = 20f;
    Transform entryTransform = Instantiate(entryTemp, con);
    RectTransform entryReactTransform = entryTransform.GetComponent<RectTransform>();
    entryReactTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count * 2);
    entryTransform.gameObject.SetActive(true);

    int rank = transformList.Count + 1;
    string rankString;
    switch (rank)
    {
      default:
        rankString = rank + "TH"; break;

      case 1: rankString = "1ST"; break;
      case 2: rankString = "2ND"; break;
      case 3: rankString = "3RD"; break;
    }

    entryTransform.Find("Rank").GetComponent<Text>().text = rankString;
    int score = leaderboardEntry.score;
    string name = leaderboardEntry.name;
    entryTransform.Find("Name").GetComponent<Text>().text = name;
    entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();
    transformList.Add(entryTransform);
  }

  private void AddScoreEntry(string name, int score)
  {
    //create
    LeaderboardEntry leaderboardEntry = new LeaderboardEntry { name = name, score = score };

    // load
    string jsonString = PlayerPrefs.GetString("leaderboardTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    if (highscores == null)
    {
      highscores = new Highscores()
      {
        leaderboardEntryList = new List<LeaderboardEntry>()
      };
    }

    // add new entry
    highscores.leaderboardEntryList.Add(leaderboardEntry);

    // save
    string json = JsonUtility.ToJson(highscores);
    PlayerPrefs.SetString("leaderboardTable", json);
    PlayerPrefs.Save();
  }

  private class Highscores
  {
    public List<LeaderboardEntry> leaderboardEntryList;
  }

  [System.Serializable]
  private class LeaderboardEntry
  {
    public string name;
    public int score;
  }

  
}

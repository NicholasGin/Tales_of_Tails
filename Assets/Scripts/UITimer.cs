using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
  public TextMeshProUGUI TimerText;
  public bool playing;
  private float Timer;

  void Update()
    {
      if (playing)
      {
      Timer += Time.deltaTime;
      int min = Mathf.FloorToInt(Timer / 60f);
      int sec = Mathf.FloorToInt(Timer % 60f);
      int ms = Mathf.FloorToInt((Timer * 100f) % 100f);
      TimerText.text = min.ToString("00") + ":" + sec.ToString("00");
      }
    }
}

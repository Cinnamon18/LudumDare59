using UnityEngine;
using TMPro;
using Utilities;

public class GameWinScreen : MonoBehaviour {
  public TMP_Text timeText;

  void Start() {
    var timeElapsedSec = (Time.time - ScoreTracker.StartTime) ?? 0;
    timeText.text = $"{(int)timeElapsedSec / 60}m {(timeElapsedSec % 60).KiloMegaFormat()}s";
  }
}

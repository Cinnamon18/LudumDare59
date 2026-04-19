using UnityEngine;
using TMPro;

public class GameWinScreen : MonoBehaviour {
	public TMP_Text timeText;

	void Start() {
		timeText.text = $"{(int)(ScoreTracker.StartTime ?? 0) / 60}m {(ScoreTracker.StartTime ?? 0) % 60}s";
	}
}

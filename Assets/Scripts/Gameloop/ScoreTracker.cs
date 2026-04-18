using UnityEngine;

public class ScoreTracker : MonoBehaviour {
	public static float? StartTime = null;
	void Start() {
		if(StartTime != null) {
			return;
		}

		StartTime = Time.time;
	}
}
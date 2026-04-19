using UnityEngine;

public class ScoreTracker : MonoBehaviour {
	public static float? StartTime = null;
	void Start() {
		if(StartTime != null) {
			Debug.Log("Score tracker already initiated");
			return;
		}

		StartTime = Time.time;
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killable : MonoBehaviour {
	const string DeathSceneName = "DeathScene";
	
	void OnCollisionEnter2D(Collision2D other) {
		if(((1 << other.gameObject.layer) & LayerMask.GetMask("Hazard")) != 0) {
			Debug.Log("Death draws near.");
	
			DeathScreen.SceneToReturnTo = SceneManager.GetActiveScene().name;
			var sceneTransitioner = FindObjectsByType<SceneTransitioner>(FindObjectsSortMode.None)[0];
			sceneTransitioner.TransitionSceneTo(DeathSceneName);
		}
	}
}
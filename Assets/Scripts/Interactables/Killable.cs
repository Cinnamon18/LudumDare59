using UnityEngine;

public class Killable : MonoBehaviour {
	const string DeathSceneName = "DeathScene";
	
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log($"Collided with {other.gameObject.layer}");
		Debug.Log($"mask {LayerMask.GetMask("Hazard")}");
		if(((1 << other.gameObject.layer) & LayerMask.GetMask("Hazard")) != 0) {
			Debug.Log("Death draws near.");	
			var sceneTransitioner = FindObjectsByType<SceneTransitioner>(FindObjectsSortMode.None)[0];
			sceneTransitioner.TransitionSceneTo(DeathSceneName);
		}
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			var sceneTransitioner = FindObjectsByType<SceneTransitioner>(FindObjectsSortMode.None)[0];
			sceneTransitioner.TransitionSceneTo(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}

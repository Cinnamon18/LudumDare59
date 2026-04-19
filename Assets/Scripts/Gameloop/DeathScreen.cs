using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {
	public static string SceneToReturnTo { get; set; } = "SampleScene";
	void Start() {
		StartCoroutine(GoToSavedScene());
	}

	IEnumerator GoToSavedScene() {
		//Just to show off the effect 😇
		yield return new WaitForSeconds(1.5f);
		var sceneTransitioner = FindObjectsByType<SceneTransitioner>(FindObjectsSortMode.None)[0];
		sceneTransitioner.TransitionSceneTo(SceneToReturnTo);
	}
}
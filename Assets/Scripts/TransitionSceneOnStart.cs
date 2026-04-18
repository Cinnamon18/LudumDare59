using UnityEngine;

public class TransitionSceneOnStart : MonoBehaviour {
	[SerializeField] private string targetScene = "";

	void Start() {
		var sceneTransitioner = GetComponent<SceneTransitioner>();
		sceneTransitioner.TransitionSceneTo(targetScene);
	}
}
using UnityEngine;

public class GameManager : MonoBehaviour {


	public void GameWin() {
		var sceneTransitioner = GetComponent<SceneTransitioner>();
		sceneTransitioner.TransitionSceneTo("VictoryScreen");
	}
}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour {
	private AsyncOperation loadingOp = null;

	void Awake() {
	}

	public void TransitionSceneTo(string targetScene) {
		if(loadingOp != null) {
			return;
		}
		loadingOp = SceneManager.LoadSceneAsync(targetScene);
		loadingOp.allowSceneActivation = false;

		StartCoroutine(WaitForNextSceneLoaded());
	}

	private IEnumerator WaitForNextSceneLoaded() {
		//Just to show off the effect 😇
		yield return new WaitForSeconds(1);

		// 0.9 is considered loaded for some reason 😅 adjust in kind.
		while (loadingOp.progress < 0.89) {
			yield return null;
		}

		// transiton out
		// yield return sceneTransAnimator.StopTransitionAnimation();

		loadingOp.allowSceneActivation = true;
		loadingOp = null;
	}
}

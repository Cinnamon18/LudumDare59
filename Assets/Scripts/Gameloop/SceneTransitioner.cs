using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour {
  private AsyncOperation loadingOp = null;

  void Awake() {
  }

  // Unity C# 15 support when
  public void TransitionSceneTo(int targetSceneIdx) {
    if (loadingOp != null) {
      return;
    }
    loadingOp = SceneManager.LoadSceneAsync(targetSceneIdx);
    loadingOp.allowSceneActivation = false;

    StartCoroutine(WaitForNextSceneLoaded());
  }

  public void TransitionSceneTo(string targetScene) {
    if (loadingOp != null) {
      return;
    }
    loadingOp = SceneManager.LoadSceneAsync(targetScene);
    loadingOp.allowSceneActivation = false;

    StartCoroutine(WaitForNextSceneLoaded());
  }

  private IEnumerator WaitForNextSceneLoaded() {

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

using UnityEngine;
using UnityEngine.SceneManagement;

public class SoftlockButton : MonoBehaviour {
  public void OnClick() {
    Debug.Log("Clicked");
    DeathScreen.SceneToReturnTo = SceneManager.GetActiveScene().name;
    var sceneTransitioner = FindObjectsByType<SceneTransitioner>(FindObjectsSortMode.None)[0];
    sceneTransitioner.TransitionSceneTo(Killable.DeathSceneName);
  }
}

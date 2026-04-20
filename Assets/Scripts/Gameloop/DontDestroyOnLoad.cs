using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
  void Awake() {
    if (FindObjectsByType<TemporaryTextDisplay>(FindObjectsSortMode.None).Length > 1) {
      Destroy(this);
    }
    DontDestroyOnLoad(this.gameObject);
  }
}

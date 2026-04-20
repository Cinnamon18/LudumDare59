using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
  void Awake() {
    if (FindObjectsByType<DontDestroyOnLoad>(FindObjectsSortMode.None).Length > 1) {
      Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
  }
}

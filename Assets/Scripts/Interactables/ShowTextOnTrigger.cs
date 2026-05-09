using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShowTextOnTrigger : MonoBehaviour {
	[SerializeField] private TemporaryTextDisplay tempTextDisplay;
	[SerializeField] private string textToDisplay;
	[SerializeField] private bool once = false;
	private bool didOnce = false;

	void Reset() {
		tempTextDisplay = FindObjectsByType<TemporaryTextDisplay>(FindObjectsSortMode.None)[0];
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			if (once && didOnce) return;
			didOnce = true;
			tempTextDisplay.DisplayText(textToDisplay);
		}
	}

	
#if UNITY_EDITOR
  private void OnDrawGizmos() {
    Handles.color = new Color(1, 0, 0, 0.25f);
    Handles.DrawSolidDisc(transform.position, transform.forward, 0.5f);
  }
#endif

}

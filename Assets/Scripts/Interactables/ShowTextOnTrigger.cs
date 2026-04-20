using UnityEngine;


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
}

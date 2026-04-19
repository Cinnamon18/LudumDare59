using UnityEngine;


public class ShowTextOnTrigger : MonoBehaviour {
	[SerializeField] private TemporaryTextDisplay tempTextDisplay;
	[SerializeField] private string textToDisplay;

	void Reset() {
		tempTextDisplay = FindObjectsByType<TemporaryTextDisplay>(FindObjectsSortMode.None)[0];
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			tempTextDisplay.DisplayText(textToDisplay);
		}
	}
}
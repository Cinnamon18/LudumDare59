using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using Utilities;

public class TemporaryTextDisplay : MonoBehaviour {
	[SerializeField] private Image fullscreenWhite;
	[SerializeField] private TMP_Text textDisplay;

	private Coroutine displayTextCoroutine;

	public void DisplayText(string text, float durationSec = 2f) {
		if(displayTextCoroutine != null) {
			StopCoroutine(displayTextCoroutine);
		}
		displayTextCoroutine = StartCoroutine(DisplayTextCoroutine(text, durationSec));
	}

	IEnumerator DisplayTextCoroutine(string text, float durationSec) {
		textDisplay.text = text;
		yield return Util.ParallelizeCoroutines(
			StartCoroutine(Util.Lerp(durationSec / 2f, (progress) => {
				fullscreenWhite.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), Mathf.Sqrt(progress));
			})),
			StartCoroutine(Util.Lerp(durationSec, (progress) => {
				textDisplay.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), Mathf.Sqrt(progress));
			}))
		);
		textDisplay.text = "";
	}
}
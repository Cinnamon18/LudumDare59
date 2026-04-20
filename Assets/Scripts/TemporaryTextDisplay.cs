using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using Utilities;

public class TemporaryTextDisplay : MonoBehaviour {
  [SerializeField] private Image fullscreenWhite;
  [SerializeField] private TMP_Text textDisplay;

  private Coroutine metaCoroutine, flashbangCoroutine, displayTextCoroutine;

  public void DisplayText(string text, float durationSec = 2f) {
    if (metaCoroutine != null) {
      StopCoroutine(metaCoroutine);
    }
    if (flashbangCoroutine != null) {
      StopCoroutine(flashbangCoroutine);
    }
    if (displayTextCoroutine != null) {
      StopCoroutine(displayTextCoroutine);
    }
    metaCoroutine = StartCoroutine(DisplayTextCoroutine(text, durationSec));
  }

  IEnumerator DisplayTextCoroutine(string text, float durationSec) {
    textDisplay.text = text;
    flashbangCoroutine = StartCoroutine(Util.Lerp(durationSec / 2f, (progress) => {
      fullscreenWhite.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), Mathf.Sqrt(progress));
    }));
    displayTextCoroutine = StartCoroutine(Util.Lerp(durationSec, (progress) => {
      textDisplay.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), Mathf.Sqrt(progress));
    }));
    yield return Util.ParallelizeCoroutines(flashbangCoroutine, displayTextCoroutine);
    textDisplay.text = "";
  }
}

using UnityEngine;
using Utilities;
using System.Collections;

public class Pulse : MonoBehaviour {
	public float PulseToScale = 2f;
	public float Duration = 2f;

	void Start() {
		StartCoroutine(SizePulse());
	}

	private IEnumerator SizePulse(){
		while(true) {
			yield return Util.Lerp(Duration / 2f, (progress) => {
				this.transform.localScale = Vector3.one + Vector3.one * ((PulseToScale - 1) * Mathf.Sqrt(progress));
			});
			yield return Util.Lerp(Duration / 2f, (progress) => {
				this.transform.localScale = Vector3.one + Vector3.one * ((PulseToScale - 1) * Mathf.Sqrt(1 - progress));
			});
		}
	}
}

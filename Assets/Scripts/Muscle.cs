using System;
using UnityEngine;

public abstract class Muscle : MonoBehaviour {
	public string signal;
	public float cooldownTime;
	private float lastActivation;
	public void Activate(float strength) {
		var diff = Time.time - lastActivation;
		if (diff < cooldownTime) {
			return;
		}
		Debug.Log($"Activating {name} from signal {signal} with strength {strength}");
		OnActivate(strength);
		lastActivation = Time.time;
	}
	public abstract void OnActivate(float strength);
}

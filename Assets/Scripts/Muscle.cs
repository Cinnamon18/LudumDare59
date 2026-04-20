using System;
using UnityEngine;

public abstract class Muscle : MonoBehaviour {
  public float cooldownTime;
  private float lastActivation;
  public void Activate(float strength) {
    var diff = Time.time - lastActivation;
    if (diff < cooldownTime) {
      return;
    }
    OnActivate(strength);
    lastActivation = Time.time;
  }
  public abstract void OnActivate(float strength);
}

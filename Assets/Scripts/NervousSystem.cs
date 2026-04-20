using System;
using System.Collections.Generic;
using UnityEngine;

public class NervousSystem : MonoBehaviour {
  private readonly Dictionary<string, Action<float>> NerveSignal = new();

  public void Register(string name, Action<float> f) {
    if (NerveSignal.ContainsKey(name)) {
      NerveSignal[name] += f;
    } else {
      NerveSignal[name] = f;
    }
  }

  public void Activate(string name, float value) {
    Debug.Log($"Activating {name} with at {value}");
    NerveSignal.GetValueOrDefault(name)?.Invoke(value);
  }
}

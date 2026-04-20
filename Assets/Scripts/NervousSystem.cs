using System;
using System.Collections.Generic;
using UnityEngine;

public class NervousSystem : MonoBehaviour {
  private readonly Dictionary<string, Action<float>> NerveSignal = new();

  public void Register(string signal, Action<float> f) {
    if (NerveSignal.ContainsKey(signal)) {
      NerveSignal[signal] += f;
    } else {
      NerveSignal[signal] = f;
    }
  }

  public void Activate(string signal, float strength) {
    NerveSignal.GetValueOrDefault(signal)?.Invoke(strength);
  }
}

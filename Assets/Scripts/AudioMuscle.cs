using System.Collections;
using UnityEngine;

public class AudioMuscle : Muscle {
  [SerializeField] private AudioSource audioSource;
  public override void OnActivate(float strength) {
    if (strength < 0) return;

    audioSource.volume = strength;
    audioSource.Play();
  }
}

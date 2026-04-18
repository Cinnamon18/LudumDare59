using System.Collections.Generic;
using UnityEngine;

public class ControllableCreature : MonoBehaviour
{
  [SerializeField] private NervousSystem nervousSystem;
  [SerializeField] private List<Muscle> muscles;

  void Start()
  {
    foreach (var muscle in muscles)
    {
      nervousSystem.Register(muscle.name, muscle.Activate);
    }
  }
}

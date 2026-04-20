using UnityEngine;

public class ContractMuscle : Muscle {
  [SerializeField] private SliderJoint2D sliderJoint2D;
  public float strengthMultiplier = 1f;
  public override void OnActivate(float strength) {
    if (strength < 0) return;
    var motor = new JointMotor2D() { motorSpeed = -strength * strengthMultiplier, maxMotorTorque = 1000 };
    sliderJoint2D.useMotor = true;
    sliderJoint2D.motor = motor;
  }
}

using System.Collections;
using UnityEngine;

public class HingeMotorMuscle : Muscle {
  [SerializeField] new HingeJoint2D hingeJoint;
  public float speed;
  public float holdTime;
  public override void OnActivate(float strength) {
    if (strength < 0) return;
    hingeJoint.useMotor = true;
		var motor = hingeJoint.motor;
    motor.motorSpeed += speed * strength;
		hingeJoint.motor = motor;
    StartCoroutine(DelayedDisableMotor());
  }

  IEnumerator DelayedDisableMotor() {
    yield return new WaitForSeconds(holdTime);
		hingeJoint.motor = new() {
      motorSpeed = 0,
			maxMotorTorque = 1000,
    };
    hingeJoint.useMotor = false;
  }
}

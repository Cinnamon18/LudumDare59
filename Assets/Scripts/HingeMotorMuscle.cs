using System.Collections;
using UnityEngine;

public class HingeMotorMuscle : Muscle
{
  [SerializeField] new HingeJoint2D hingeJoint;
  public float speed;
  public float holdTime;
  public override void OnActivate(float strength)
  {
    Debug.Log($"Muscle: {name} got strength: {strength}");
    if (strength < 0) return;
    hingeJoint.useMotor = true;
    hingeJoint.motor = new()
    {
      motorSpeed = speed * strength,
      maxMotorTorque = 1000
    };
    StartCoroutine(DelayedDisableMotor());
  }

  IEnumerator DelayedDisableMotor()
  {
    yield return new WaitForSeconds(holdTime);
    hingeJoint.useMotor = false;
  }
}
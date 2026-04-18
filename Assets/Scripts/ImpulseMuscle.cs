using UnityEngine;

public class ImpulseMuscle : Muscle
{
  [SerializeField] private new Rigidbody2D rigidbody2D;
  public float scale;
  public override void Activate(float strength)
  {
    rigidbody2D.AddForce(scale * strength * Vector2.up, ForceMode2D.Impulse);
  }
}
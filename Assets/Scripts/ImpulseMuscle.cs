using UnityEngine;

public class ImpulseMuscle : Muscle {
  [SerializeField] private new Rigidbody2D rigidbody2D;
  public Vector2 direction;
  public override void OnActivate(float strength) {
    var worldDirection = rigidbody2D.transform.TransformDirection(direction);
    rigidbody2D.AddForce(strength * worldDirection, ForceMode2D.Impulse);
  }
}

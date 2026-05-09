using UnityEngine;

public class InitialVelocity : MonoBehaviour
{
	[SerializeField] private Vector2 velocity;
	[SerializeField] private Rigidbody2D rigidbody2D;

    void Start()
    {
		rigidbody2D.linearVelocity = velocity;
    }
}

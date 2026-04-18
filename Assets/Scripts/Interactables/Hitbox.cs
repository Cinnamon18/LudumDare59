using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Hitbox : MonoBehaviour {
	[SerializeField] private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer.enabled = false;
	}
}
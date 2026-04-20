using UnityEngine;

public class MaterialParamMuscle : Muscle {
	public SpriteRenderer spriteRenderer;
	public float value;
	public bool setTime = false;
	public string param;
	public override void OnActivate(float strength) {
		if (strength < 0) return;
    spriteRenderer.material.SetFloat($"_{param}", setTime ? Time.time : value);
  }
}

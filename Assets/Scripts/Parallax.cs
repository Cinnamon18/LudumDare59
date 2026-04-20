using UnityEngine;
using System.Collections.Generic;

public class Parallax : MonoBehaviour {
  [SerializeField] private Transform playerTrans;
  [SerializeField] private List<GameObject> backgrounds;
  [Tooltip("For every x pixels the player moves, the background moves 1 pixel.")]
  [SerializeField] private List<float> parallaxAmount;

  private float prevPlayerXPosition = 0;

  void Reset() {
    playerTrans = GameObject.FindGameObjectsWithTag("Player")[0].transform;
  }

  void Awake() {
    prevPlayerXPosition = playerTrans.position.x;
  }

  void LateUpdate() {
    var xDelta = playerTrans.position.x - prevPlayerXPosition;
    for (int i = 0; i < backgrounds.Count; i++) {
      backgrounds[i].transform.position += Vector3.right * xDelta * (1f / parallaxAmount[i]);
    }

    prevPlayerXPosition = playerTrans.position.x;
  }
}


#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class BrainNerve : MonoBehaviour
{
  public float radius;
  public string signal;

#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    float worldRadius = radius * transform.lossyScale.x;
    Handles.color = new Color(0f, 1f, 1f, 0.25f);
    Handles.DrawSolidDisc(transform.position, transform.forward, worldRadius);
    Handles.color = new Color(0f, 1f, 1f, 0.8f);
    Handles.DrawWireDisc(transform.position, transform.forward, worldRadius);
  }
#endif
}
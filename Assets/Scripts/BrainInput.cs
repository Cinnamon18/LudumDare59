using UnityEngine;
using UnityEngine.EventSystems;

public class BrainInput : MonoBehaviour, IPointerClickHandler
{
  public void OnPointerClick(PointerEventData pointerEvent)
  {
    Debug.Log($"Clicked at: {pointerEvent.position}");
  }
}

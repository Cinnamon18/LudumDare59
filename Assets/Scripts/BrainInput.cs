using UnityEngine;
using UnityEngine.EventSystems;

public class BrainInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler, IPointerExitHandler
{

  [SerializeField] private NervousSystem nervousSystem;
  private bool pressed = false;

  public void OnPointerMove(PointerEventData eventData)
  {
    if (!pressed) return;

    for (int i = 0; i < transform.childCount; i += 1)
    {
      var child = transform.GetChild(i);
      if (child.TryGetComponent<BrainNerve>(out var nerve))
      {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            child.transform as RectTransform,
            eventData.position,
            null,
            out Vector2 relative))
        {
          var strength = 1f - relative.magnitude / nerve.radius;
          nervousSystem.Activate(nerve.signal, strength);
        }
      }
    }
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    pressed = true;
    Debug.Log("Click? arooni");
    OnPointerMove(eventData);
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    pressed = false;
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    pressed = false;
  }
}

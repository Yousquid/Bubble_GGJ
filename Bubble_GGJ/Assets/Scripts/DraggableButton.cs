using UnityEngine;
using UnityEngine.EventSystems;  // This is necessary for the event system

public class DraggableButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas parentCanvas;

    // You can optionally add this if you want to constrain the dragging within a certain area
    // public RectTransform dragArea;

    void Start()
    {
        // Get the RectTransform of the button
        rectTransform = GetComponent<RectTransform>();

        // Get the parent canvas (to handle scaling)
        parentCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Optional: Do something when dragging begins (e.g., highlight the button)
        Debug.Log("Drag Started");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Get the position of the pointer and update the button's position
        Vector2 localPointerPosition = eventData.position;

        // Convert screen position to local position in the canvas
        Vector2 worldPosition = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, localPointerPosition, parentCanvas.worldCamera, out worldPosition);

        // Update the button's position
        rectTransform.localPosition = worldPosition;

        // Optional: Restrict the drag within a specific area
        // if (dragArea != null)
        // {
        //     rectTransform.localPosition = new Vector2(
        //         Mathf.Clamp(rectTransform.localPosition.x, dragArea.rect.xMin, dragArea.rect.xMax),
        //         Mathf.Clamp(rectTransform.localPosition.y, dragArea.rect.yMin, dragArea.rect.yMax)
        //     );
        // }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Optional: Do something when dragging ends (e.g., reset appearance)
        Debug.Log("Drag Ended");
    }
}
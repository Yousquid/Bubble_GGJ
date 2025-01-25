using UnityEngine;
using UnityEngine.EventSystems;  // This is necessary for the event system

public class DraggableButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas parentCanvas;
    public RectTransform[] otherButtons; // List of other buttons to check overlap against
    public string objectName;
    public bool isBeingDragged;
    private bool wasOverlapping = false;
    // You can optionally add this if you want to constrain the dragging within a certain area
    // public RectTransform dragArea;

    void Start()
    {
        // Get the RectTransform of the button
        rectTransform = GetComponent<RectTransform>();

        // Get the parent canvas (to handle scaling)
        parentCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (wasOverlapping && !StopOverlapping())
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }

        wasOverlapping = StopOverlapping();

        SceneSwitch();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Optional: Do something when dragging begins (e.g., highlight the button)
        
        isBeingDragged = true;
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
        

        isBeingDragged = false;

        foreach (var otherButton in otherButtons)
        {
            if (IsOverlapping(rectTransform, otherButton))
            {
                GameObject thisButtonGameobject = this.transform.GetChild(0).gameObject;
                DialogueTrigger thisButtonTrigger = thisButtonGameobject.GetComponent<DialogueTrigger>();
                thisButtonTrigger.TriggeDialogue();

                if (this.objectName == "extra_work")
                {
                    FindObjectOfType<DialogueManager>().isSwitchScene = true;
                }
            }
        }
    }

    public void SceneSwitch()
    {
        if (StopOverlapping())
        {
            
        }
    }

    private bool StopOverlapping()
    {
        foreach (var otherButton in otherButtons)
        {
            bool isOverlapping = IsOverlapping(rectTransform, otherButton);
            return isOverlapping;
        }
        return false;
    }
    private bool IsOverlapping(RectTransform rect1, RectTransform rect2)
    {
        // Get the world corners of both RectTransforms
        Vector3[] corners1 = new Vector3[4];
        Vector3[] corners2 = new Vector3[4];
        rect1.GetWorldCorners(corners1);
        rect2.GetWorldCorners(corners2);

        // Create Rects using the bottom-left corner and size
        Rect rectA = new Rect(corners1[0].x, corners1[0].y, corners1[2].x - corners1[0].x, corners1[2].y - corners1[0].y);
        Rect rectB = new Rect(corners2[0].x, corners2[0].y, corners2[2].x - corners2[0].x, corners2[2].y - corners2[0].y);

        // Check if the Rects overlap
        return rectA.Overlaps(rectB);
    }
}
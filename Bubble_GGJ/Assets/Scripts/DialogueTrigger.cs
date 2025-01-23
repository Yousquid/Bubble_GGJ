using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{
    public Paragraph paragraph;
    public TextMeshProUGUI textMeshPro;

    public void TriggeDialogue()
    { 
        FindObjectOfType<DialogueManager>().PlayDialogue(paragraph, textMeshPro);
    }

    private void Update()
    {
        buttonClickDetection();
    }

    void buttonClickDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                TriggeDialogue();
            }
        }
      
    }
}

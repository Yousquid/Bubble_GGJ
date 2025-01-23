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
        if (Input.GetKeyDown(KeyCode.S))
        { 
            TriggeDialogue();
        }
    }
}

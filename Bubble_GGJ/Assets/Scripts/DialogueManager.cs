using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> paragraphs;
    public TextMeshProUGUI dialogueText;

    void Start()
    {
        paragraphs = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DisplayNextParagraph();
        }
    }

    public void PlayDialogue(Paragraph paragraph , TextMeshProUGUI textMesh)
    { 
        paragraphs.Clear();

        dialogueText = textMesh;

        foreach (string para in paragraph.paragraphs)
        {
            paragraphs.Enqueue(para);
        }

        DisplayNextParagraph();
        
    }

    public void DisplayNextParagraph()
    {
        if (paragraphs.Count == 0)
        {
            EndDialogue();
            return;
        }

        string shownParagraph = paragraphs.Dequeue();
        dialogueText.text = shownParagraph;

    }

    public void EndDialogue()
    { 
        
    }
}

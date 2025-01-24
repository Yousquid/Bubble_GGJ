using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> paragraphs;
    public TextMeshProUGUI dialogueText;
    public int progress;
    public bool isTalkingBar;
    public bool isObjectIllustration;
    public GameObject talkingBox;
    public GameObject objectIllustrationBox;
    public TextMeshProUGUI talkingBoxText;
    public TextMeshProUGUI objectIllustrationBoxText;

    void Start()
    {
        paragraphs = new Queue<string>();
        progress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DisplayNextParagraph();
        }

        HideTextBox();

        print("progress: " + progress);
        print("para.count: " + paragraphs.Count);
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
        progress += 1;
        dialogueText.text = shownParagraph;

    }

  /*  public void EndTextBar(Paragraph paragraph, GameObject textbar)
    {
        if (progress == paragraph.paragraphs.Length)
        {
            textbar.SetActive(false);
        }
    } */

    public void EndDialogue()
    {
        if (isTalkingBar)
        {
            talkingBox.SetActive(false);
            talkingBoxText.text = "";
            isTalkingBar = false;
        }
        if (isObjectIllustration)
        {
            objectIllustrationBox.SetActive(false);
            objectIllustrationBoxText.text = "";
            isObjectIllustration = false;
        }
    }

    public void HideTextBox()
    {
        if (!isTalkingBar)
        {
            talkingBox.SetActive(false);
            talkingBoxText.text = "";
        }
        if (!isObjectIllustration)
        {
            objectIllustrationBox.SetActive(false);
            objectIllustrationBoxText.text = "";
        }
    }
}

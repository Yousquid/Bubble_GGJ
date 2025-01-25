using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Paragraph paragraph;
    public TextMeshProUGUI textMeshPro;
    public int progress;
    public GameObject thisObject;

    public void TriggeDialogue()
    {
        if (this.GetComponent<DraggableButton>() != null)
        {
            DraggableButton buttonScript = this.GetComponent<DraggableButton>();

            if (!buttonScript.isBeingDragged)
            {
                FindObjectOfType<DialogueManager>().PlayDialogue(paragraph, textMeshPro);
            }
        }
        else if (this.GetComponent<DraggableButton>() == null)
        {
            FindObjectOfType<DialogueManager>().PlayDialogue(paragraph, textMeshPro);
        }
        
        
    }

    private void Start()
    {
        thisObject = this.gameObject;

    }

    private void Update()
    {
        progress = FindObjectOfType<DialogueManager>().progress;

        Scene currentScene = SceneManager.GetActiveScene();

        if (progress == 0 && currentScene.name != "Start_Menu")
        {
            TriggeDialogue();
            FindObjectOfType<DialogueManager>().isTalkingBar = true;
            FindObjectOfType<DialogueManager>().isObjectIllustration = false;
        }

        //FindObjectOfType<DialogueManager>().EndTextBar(paragraph,thisObject);

    }

   



}

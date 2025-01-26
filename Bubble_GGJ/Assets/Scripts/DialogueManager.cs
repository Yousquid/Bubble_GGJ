using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public List<GameObject> objects;
    public bool isSwitchScene = false;
    public GameObject sceneSwitchComic;
    public int sceneNumber;
    public bool hasShown = false;
    public int prssedTime = 0;
    public bool isKeyBoardDown = false;

    void Start()
    {
        if (sceneNumber != 0)
        {
            isTalkingBar = true;
        }
        else isTalkingBar = false;

        paragraphs = new Queue<string>();
        progress = 0;

        if (sceneNumber != 0)
        {
            //talkingBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DisplayNextParagraph();
        }

        HideTextBox();

        SceneOneChange();

        SwitchScene();

        KeyBoardDetection();

       // print("progress: " + progress);
      //  print("para.count: " + paragraphs.Count);

    }

    public void KeyBoardDetection()
    {
        if (Input.anyKeyDown)
        {
            isKeyBoardDown = true;
        }
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(key))
            {
                isKeyBoardDown = false;
                break; // Stop after detecting the first key release
            }
        }
    }

    public void PlayDialogue(Paragraph paragraph , TextMeshProUGUI textMesh)
    {
        Cursor.lockState = CursorLockMode.Locked;

        isTalkingBar = true;

        talkingBox.SetActive(true);

        RectTransform rectTransform = talkingBox.GetComponent<RectTransform>();
        RectTransform rectTransformText = talkingBoxText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(0, -411.08f, 0);
        rectTransformText.anchoredPosition = new Vector3(0, -411.08f, 0);

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
        Cursor.lockState = CursorLockMode.None;

        RectTransform rectTransform = talkingBox.GetComponent<RectTransform>();
        RectTransform rectTransformText = talkingBoxText.GetComponent<RectTransform>();
        if (isTalkingBar && progress != 0 && !isSwitchScene)
        {
            rectTransform.anchoredPosition = new Vector3(0, -1000, 0);
            rectTransformText.anchoredPosition = new Vector3(0, -1000, 0);
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
        if (isTalkingBar && isSwitchScene)
        {
            rectTransform.anchoredPosition = new Vector3(0, -1000, 0);
            rectTransformText.anchoredPosition = new Vector3(0, -1000, 0);
            talkingBox.SetActive(false);
            talkingBoxText.text = "";
            isTalkingBar = false;
            sceneSwitchComic.SetActive(true);

            if (prssedTime >= 2)
            {
                SceneManager.LoadScene(sceneNumber + 1);
            }
        }
    }

    public void HideTextBox()
    {
        if (!isTalkingBar)
        {
            //talkingBox.transform.position += new Vector3(0, 400, 0);
            talkingBox.SetActive(false);
            talkingBoxText.text = "";
        }
        
    }

    public void SceneOneChange()
    {
        if (progress == 7 && sceneNumber == 1)
        {
            foreach (GameObject gameobject in objects)
            {
                gameobject.gameObject.SetActive(true);
            }
        }
        if (progress == 1 && sceneNumber == 2)
        {
            foreach (GameObject gameobject in objects)
            {
                gameobject.gameObject.SetActive(true);
            }
        }
        if (progress == 1 && sceneNumber == 3)
        {
            foreach (GameObject gameobject in objects)
            {
                gameobject.gameObject.SetActive(true);
            }
        }
        if (progress == 1 && sceneNumber == 4)
        {
            foreach (GameObject gameobject in objects)
            {
                gameobject.gameObject.SetActive(true);
            }
        }
        if (progress == 1 && sceneNumber == 5)
        {
            foreach (GameObject gameobject in objects)
            {
                gameobject.gameObject.SetActive(true);
            }
        }
        if (progress == 1 && sceneNumber == 6)
        {
            foreach (GameObject gameobject in objects)
            {
                gameobject.gameObject.SetActive(true);
            }
        }
        if (progress == 1 && sceneNumber == 7)
        {
            foreach (GameObject gameobject in objects)
            {
                gameobject.gameObject.SetActive(true);
            }
        }
        if (progress == 1 && sceneNumber == 8)
        {
            foreach (GameObject gameobject in objects)
            {
                gameobject.gameObject.SetActive(true);
            }
        }
       
    }

    public void SwitchScene()
    {
        if (isSwitchScene && sceneSwitchComic.activeSelf)
        {
            if (!hasShown)
            {
                prssedTime = 0;
                hasShown = true;
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow) && !isKeyBoardDown)
            {
                prssedTime += 1;
               
            }

            if (prssedTime == 2)
            {
                DialogueTrigger sceneWordsd = sceneSwitchComic.GetComponent<DialogueTrigger>();
                sceneWordsd.TriggeDialogue();
                hasShown = true;

            }


        }
    }
}

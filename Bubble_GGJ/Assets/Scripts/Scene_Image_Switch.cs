using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scene_Image_Switch : MonoBehaviour
{
    public Sprite comic_1;
    public Sprite comic_2;
    public Sprite comic_3;
    public Sprite comic_two_1;
    public Sprite comic_two_2;
    public Sprite comic_two_3;
    public Sprite comic_two_4;
    public Sprite comic_two_5;
    public Sprite comic_three_1;
    public Sprite comic_three_2;
    public Sprite comic_three_3;
    public Image image;
    public int image_Number;
    public int scene_Number;

    void Start()
    {
        image = this.GetComponent<Image>();
        image_Number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SceneImageChange();
    }

    public void SceneImageChange()
    {
        if (Input.GetMouseButtonDown(0))
        {
            image_Number += 1;
        }

        if (scene_Number != 4 && scene_Number < 4)
        {
            if (image_Number == 0)
            {
                image.sprite = comic_1;
            }
            if (image_Number == 1)
            {
                image.sprite = comic_2;
            }
            if (image_Number == 2)
            {
                image.sprite = comic_3;
            }
        }

        if (scene_Number == 4)
        {
            if (image_Number == 0)
            {
                image.sprite = comic_two_1;
            }
            if (image_Number == 1)
            {
                image.sprite = comic_two_2;
            }
            if (image_Number == 2)
            {
                image.sprite = comic_two_3;
            }
            if (image_Number == 3)
            {
                image.sprite = comic_two_4;
            }
            if (image_Number == 4)
            {
                image.sprite = comic_two_5;
            }
        }

        if (scene_Number != 4 && scene_Number > 4)
        {
            if (image_Number == 0)
            {
                image.sprite = comic_three_1;
            }
            if (image_Number == 1)
            {
                image.sprite = comic_three_2;
            }
            if (image_Number == 2)
            {
                image.sprite = comic_three_3;
            }
        }





    }

    public bool IsImageFinished()
    {
        if (scene_Number != 4)
        {
            if (image_Number == 3)
            {
                return true;
            }
            else return false;
        }
        else if (scene_Number == 4)
        {
            if (image_Number == 5)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }
}

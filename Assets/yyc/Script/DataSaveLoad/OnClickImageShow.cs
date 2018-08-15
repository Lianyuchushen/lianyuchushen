using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickImageShow : MonoBehaviour {

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClickImage_Show);
    }

    public void OnClickImage_Show()
    {
        OnClickImage_Show_ChangeData();
        OnClickImage_Show_ChangeUI();
    }

    public void OnClickImage_Show_ChangeData()
    {
        
        if (SaveLoadData.currentImage_Selected_Template != null)
        {
            SaveLoadData.currentImage_Selected_Template.AddComponent<ImageInfo_Template>().imageNumber = gameObject.GetComponent<ImageInfo_Show>().imageNumber;
            SaveLoadData.currentImage_Selected_Template.AddComponent<ImageInfo_Template>().imageName = gameObject.GetComponent<ImageInfo_Show>().imageName;
            SaveLoadData.currentImage_Selected_Template.AddComponent<ImageInfo_Template>().imagePath = gameObject.GetComponent<ImageInfo_Show>().imagePath;
        }
        
    }

    public void OnClickImage_Show_ChangeUI()
    {
        if (SaveLoadData.currentImage_Selected_Template != null)
        {
            SaveLoadData.currentImage_Selected_Show = gameObject;
            SaveLoadData.currentImage_Selected_Template.GetComponent<Image>().sprite = SaveLoadData.currentImage_Selected_Show.GetComponent<Image>().sprite;
        }
    }
}

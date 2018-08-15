using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OnClickImageTemplate : MonoBehaviour {
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClickImage_Template);
    }

    public void OnClickImage_Template()
    {
        OnClickImage_Template_ChangeData();
        OnClickImage_Template_ChangeUI();
    }

    public void OnClickImage_Template_ChangeData()
    {

    }

    public void OnClickImage_Template_ChangeUI()
    {
        SaveLoadData.currentImage_Selected_Template = gameObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// image info on the show list
public class ImageInfo_Show : MonoBehaviour {

    public GameObject parent;

    public int imageNumber;
    public string imageName;
    public string imagePath;

    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        imageNumber = Int32.Parse(parent.transform.GetChild(0).GetComponent<Text>().text);
        imageName = parent.transform.GetChild(1).GetComponent<Text>().text;
        imagePath = string.Format("{0}/{1}/{2}", Application.persistentDataPath, "Custom Image", imageName);
    }

}

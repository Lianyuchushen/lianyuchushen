using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//挂在bookbag上，点击时显示界面
public class Bookbag : MonoBehaviour {

    //点开的界面
    public GameObject bookbag_panel;
    //原来界面上的按钮
    public GameObject ui_button;

    //脚本
    MusicController musicControlScript;

    void Start () {
        musicControlScript = GameObject.Find("Music").GetComponent<MusicController>();
    }

	void Update () {
		
	}

    //点击事件
    void OnTap(TapGesture gesture)
    {
        musicControlScript.playSound1(9);
        bookbag_panel.SetActive(true);
        ui_button.SetActive(false);
    }
}

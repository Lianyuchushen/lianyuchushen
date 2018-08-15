using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MainPageUI：点击按钮进入关卡
//挂在每个按钮上
public class LevelSelect : MonoBehaviour {

    MusicController musicControlScript;
    MainPage mainPageScript;
    Data dataScript;

    void Start () {

        //获取音效控制脚本
        musicControlScript = GameObject.Find("Music").GetComponent<MusicController>();
        //获取主界面脚本
        mainPageScript = GameObject.Find("Main Camera").GetComponent<MainPage>();
        //获取Data脚本
        dataScript = GameObject.Find("Data").GetComponent<Data>();
    }
	
	void Update () {
		
	}

    //点击事件
    void OnTap (TapGesture gesture) {

        //播放声音
        musicControlScript.playSound1(3);
        //进入进度载入
        mainPageScript.boolLoading = true;

        //点击游戏1
        if (gesture.Selection.name == "game1")
        {
            //传入选择哪个场景
            dataScript.level = 1;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏2
        if (gesture.Selection.name == "game2")
        {
            dataScript.level = 2;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏3
        if (gesture.Selection.name == "game3")
        {
            dataScript.level = 3;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏4
        if (gesture.Selection.name == "game4")
        {
            dataScript.level = 4;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏5
        if (gesture.Selection.name == "game5")
        {
            dataScript.level = 5;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏6
        if (gesture.Selection.name == "game6")
        {
            dataScript.level = 6;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏7
        if (gesture.Selection.name == "game7")
        {
            dataScript.level = 7;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏8
        if (gesture.Selection.name == "game8")
        {
            dataScript.level = 8;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏9
        if (gesture.Selection.name == "game9")
        {
            dataScript.level = 9;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏11
        if (gesture.Selection.name == "game11")
        {
            dataScript.level = 11;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏9
        if (gesture.Selection.name == "game12")
        {
            dataScript.level = 12;
            dataScript.sceneID = "game_a_1";
        }
        //点击游戏9
        if (gesture.Selection.name == "game13")
        {
            dataScript.level = 13;
            dataScript.sceneID = "game_a_1";
        }
    }

}

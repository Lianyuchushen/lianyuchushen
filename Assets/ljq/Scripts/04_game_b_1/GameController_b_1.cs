using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_b_1 : MonoBehaviour {

    MusicController musicControlScript;

    //这是移动正确的toy和book数量，也就是得分
    public int toy_finish;
    public int book_finish;

    public GameObject tutorial_1;
    public GameObject tutorial_2;

    void Start () {

        musicControlScript = GameObject.Find("Music").GetComponent<MusicController>();

        toy_finish = 0;
        book_finish = 0;

        //设置播放哪一首bgm
        musicControlScript.BGM_playing = 5;
        //游戏开始的提示语音
        //musicControlScript.playSpeak(1);
    }
	
	void Update () {

        //控制是否显示教程
        if (book_finish > 0)
        {
            tutorial_1.SetActive(false);
        }
        else
        {
            tutorial_1.SetActive(true);
        }
        if (toy_finish > 0)
        {
            tutorial_2.SetActive(false);
        }
        else
        {
            tutorial_2.SetActive(true);
        }
    }
}

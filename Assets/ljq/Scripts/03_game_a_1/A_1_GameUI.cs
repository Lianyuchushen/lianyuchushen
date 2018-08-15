using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//游戏界面中按钮，文本，对话框的控制
//挂在UI上就行
public class A_1_GameUI : MonoBehaviour {

    //——————————链接脚本——————————

    //音效控制脚本
    MusicController musicControlScript;
    //data脚本
    Data dataScript;
    //GameController脚本
    A_1_GameController game_controller;
    //Timer脚本
    Timer time_script;

    //保存按钮需要改变的图片
    public Sprite[] music_button_sprite;
    public Sprite[] sound_button_sprite;

    //声明需要改变图片的按钮
    public Button music_button;
    public Button sound_button;

    //文本
    //public Text round_text;
    //public Text score_text;
    //public Text level_text;
    public Text time_text;

    //文本显示的相关信息
    int count;
    int round;
    int time;

    void Start () {

        dataScript = GameObject.Find("Data").GetComponent<Data>();
        musicControlScript = GameObject.Find("MusicController").GetComponent<MusicController>();
        game_controller = GameObject.Find("GameController").GetComponent<A_1_GameController>();
        time_script = GameObject.Find("GameController").GetComponent<Timer>();

        //round_text.text = "回合:1";
        //score_text.text = "得分:" + (count / 2);
        time_text.text = "0";

        //switch (dataScript.level)
        //{
        //    case 1:
        //        level_text.text = "相同素材配对-初级";
        //        break;
        //    case 2:
        //        level_text.text = "相同素材配对-中级";
        //        break;
        //    case 4:
        //        level_text.text = "不同素材配对-初级";
        //        break;
        //    case 5:
        //        level_text.text = "不同素材配对-中级";
        //        break;
        //    case 3:
        //        level_text.text = "相同素材配对-高级";
        //        break;
        //    case 6:
        //        level_text.text = "相同素材配对-高级";
        //        break;
        //    case 7:
        //        level_text.text = "理解-初级";
        //        break;
        //    case 8:
        //        level_text.text = "理解-中级";
        //        break;
        //    case 9:
        //        level_text.text = "理解-高级";
        //        break;
        //    case 11:
        //        level_text.text = "表达-初级";
        //        break;
        //    case 12:
        //        level_text.text = "表达-中级";
        //        break;
        //    case 13:
        //        level_text.text = "表达-高级";
        //        break;
        //}
    }
	
	void Update () {

        count = game_controller.count;
        //score_text.text = "得分:" + (count / 2);
        round = game_controller.round;
        //round_text.text = "回合:" + round + "/5";
        time = time_script.timeCount;
        time_text.text = time + "";
    }

    //按钮点击事件
    //reload
    public void reload_click()
    {
        musicControlScript.playSound1(9);
        SceneManager.LoadScene(dataScript.sceneID);
    }
    //forward
    public void forward_click()
    {
        musicControlScript.playSound1(9);
        SceneManager.LoadScene(dataScript.sceneID);
    }
    //menu
    public void menu_click()
    {
        musicControlScript.playSound1(9);
        SceneManager.LoadScene(dataScript.sceneID);
    }
    //back
    public void back_click()
    {
        musicControlScript.playSound1(9);
        SceneManager.LoadScene(0);
    }
    //music
    public void music_click()
    {
        musicControlScript.playSound1(9);

        //如果BGM_Switch为开
        if (musicControlScript.BGM_Switch)
        {
            //关闭BGM_Switch
            musicControlScript.BGM_Switch = false;
            //更新按钮图片为关
            music_button.GetComponent<Image>().sprite = music_button_sprite[0];
        }
        //如果BGM_Switch为关
        else
        {
            //开启BGM_Switch
            musicControlScript.BGM_Switch = true;
            //更新按钮图片为开
            music_button.GetComponent<Image>().sprite = music_button_sprite[1];
        }
    }
    //sound
    public void sound_click()
    {
        //如果Sound_Speak_Switch为开
        if (musicControlScript.Sound_Speak_Switch)
        {
            //关闭Sound_Speak_Switch
            musicControlScript.Sound_Speak_Switch = false;
            //更新按钮图片为关
            sound_button.GetComponent<Image>().sprite = sound_button_sprite[0];

            //播放0，表示当时如果有正在播放的则停止
            musicControlScript.playSound1(0);
            musicControlScript.playSpeak(0);
        }
        //如果Sound_Speak_Switch为关
        else
        {
            //开启Sound_Speak_Switch
            musicControlScript.Sound_Speak_Switch = true;
            //更新按钮图片为开
            sound_button.GetComponent<Image>().sprite = sound_button_sprite[1];
            musicControlScript.playSound1(9);
        }
    }

}

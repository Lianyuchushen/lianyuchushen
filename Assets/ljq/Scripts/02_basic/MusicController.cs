using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//挂在Music上，包含BGM，Sound，Speak三个
//其中Sound有3个，最多可同时播放3个音效
public class MusicController : MonoBehaviour {

    //用这个来判断是否已经有这个控制器
    //因为它不会销毁，只能存在一个
    static MusicController music_instance ;

    //音乐文件编号以文件名为准
    //BGM音乐文件（5）
    public AudioClip[] audioclip_BGM;
    //音效文件（9）
    //1：恭喜过关 2：咻 3：选关 4：选中 5：晕 6:正确 7：警告 8:错误 9:冒泡
    public AudioClip[] audioclip_sound;
    //语音文件（3）
    //1：配对说明 2：过关 3：理解说明 4：表达说明
    public AudioClip[] audioclip_speak;

    //当前播放BGM的编号
    public int BGM_playing;

    //声音开关
    //BGM对象只用BGM_Switch，Sound和Speak对象只用Sound_Speak_Switch
    public bool BGM_Switch;
    public bool Sound_Speak_Switch;

    //BGM，Sound，Speak物体
    public GameObject BGM_Object;
    public GameObject Sound1_Object;
    public GameObject Sound2_Object;
    public GameObject Sound3_Object;
    public GameObject Speak_Object;

    //此脚本永不消毁，并且每次进入初始场景时进行判断，若存在重复的则销毁  
    void Awake () {

        if (music_instance == null)
        {
            music_instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != music_instance)
        {
            Destroy(gameObject);
        }

    }

    void Start () {

        //初始化
        //默认打开两开关
        BGM_Switch = true;
        Sound_Speak_Switch = true;

    }

    void Update () {

        //bgm一直刷，而Sound和Speak需要触发
        playBGM();

    }


    //播放BGM的function
    public void playBGM () {

        //如果bgm开关是开着
        if (BGM_Switch == true)
        {
            //如果audio没有播放东西，或正在播放的与设置的不符
            if (BGM_Object.GetComponent<AudioSource>().isPlaying == false ||
                BGM_Object.GetComponent<AudioSource>().clip != audioclip_BGM[BGM_playing - 1])
            {
                //audio播放audioclip_BGM
                BGM_Object.GetComponent<AudioSource>().clip = audioclip_BGM[BGM_playing - 1];
                BGM_Object.GetComponent<AudioSource>().Play();
            }
        }
        //否则
        else
        {
            //audio停掉
            BGM_Object.GetComponent<AudioSource>().Stop();
        }
    }

    //播放Sound的function——Sound1
    public void playSound1 (int soundCount) {

        //声音开关是开着
        if (Sound_Speak_Switch == true)
        {
            //按编号播放文件
            //如果输入的soundCount是0，不播放文件
            //在SoundSwitch关掉的时候使用playSound(0)，用来把正在播放的音效或语音关掉
            if (soundCount > 0)
            {
                Sound1_Object.GetComponent<AudioSource>().clip = audioclip_sound[soundCount - 1];
                Sound1_Object.GetComponent<AudioSource>().Play();
            }
        }
        //否则
        else
        {
            //audio停掉
            Sound1_Object.GetComponent<AudioSource>().Stop();
        }
    }

    //播放Sound的function——Sound2
    public void playSound2(int soundCount)
    {

        //声音开关是开着
        if (Sound_Speak_Switch == true)
        {
            //按编号播放文件
            //如果输入的soundCount是0，不播放文件
            //在SoundSwitch关掉的时候使用playSound(0)，用来把正在播放的音效或语音关掉
            if (soundCount > 0)
            {
                Sound2_Object.GetComponent<AudioSource>().clip = audioclip_sound[soundCount - 1];
                Sound2_Object.GetComponent<AudioSource>().Play();
            }
        }
        //否则
        else
        {
            //audio停掉
            Sound2_Object.GetComponent<AudioSource>().Stop();
        }
    }

    //播放Sound的function——Sound3
    public void playSound3(int soundCount)
    {

        //声音开关是开着
        if (Sound_Speak_Switch == true)
        {
            //按编号播放文件
            //如果输入的soundCount是0，不播放文件
            //在SoundSwitch关掉的时候使用playSound(0)，用来把正在播放的音效或语音关掉
            if (soundCount > 0)
            {
                Sound3_Object.GetComponent<AudioSource>().clip = audioclip_sound[soundCount - 1];
                Sound3_Object.GetComponent<AudioSource>().Play();
            }
        }
        //否则
        else
        {
            //audio停掉
            Sound3_Object.GetComponent<AudioSource>().Stop();
        }
    }

    //播放Speak的function
    public void playSpeak (int speakCount) {

        //声音开关是开着
        if (Sound_Speak_Switch == true)
        {
            //按编号播放文件
            //如果输入的speakCount是0，不播放文件
            //在Sound_Speak_Switch关掉的时候使用playSpeak(0)，用来把正在播放的音效或语音关掉
            if (speakCount > 0)
            {
                Speak_Object.GetComponent<AudioSource>().clip = audioclip_speak[speakCount - 1];
                Speak_Object.GetComponent<AudioSource>().Play();
            }
        }
        //否则
        else
        {
            //audio停掉
            Speak_Object.GetComponent<AudioSource>().Stop();
        }
    }
}

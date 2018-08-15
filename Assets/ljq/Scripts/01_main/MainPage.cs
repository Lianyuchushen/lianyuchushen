using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MainPage总控制
public class MainPage : MonoBehaviour
{
    //Loading开关
    public bool boolLoading;

    //Loading对象
    public GameObject Obj_loading;

    //MusicControl对象
    MusicController musicControlScript;

    void Start()
    {
        boolLoading = false;

        musicControlScript = GameObject.Find("Music").GetComponent<MusicController>();
        //设置放哪一首bgm
        musicControlScript.BGM_playing = 0;
    }

    void Update()
    {
        if (boolLoading == true)
        {
            //Obj_loading对象显示
            Obj_loading.SetActive(true);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//挂在Loadding
public class Loadding : MonoBehaviour {

    //黄色进度条图案
    GameObject yellowLoadding;
    //跑动画的计时用
    float LoaddingTimeCD;

    //mainPage脚本
    MainPage mainPageScript;
    //data脚本
    Data dataScript;

    void Start () {

        //获取loading_yellow对象
        yellowLoadding = GameObject.Find("loading_yellow");

        //获取mainPage脚本
        mainPageScript = GameObject.Find("Main Camera").GetComponent<MainPage>();

        //获取Data脚本
        dataScript = GameObject.Find("Data").GetComponent<Data>();

        //yellowLoadding不显示
        yellowLoadding.transform.localScale = new Vector3(0,
                                                          yellowLoadding.transform.localScale.y,
                                                          yellowLoadding.transform.localScale.z);
        LoaddingTimeCD = 0;
    }

    void Update () {

        //如果它的x轴的大小小于0.35
        if (yellowLoadding.transform.localScale.x < 0.35)
        {
            //如果时间大于LoaddingTimeCD
            if (Time.time > LoaddingTimeCD)
            {
                //yellowLoadding加0.05宽
                yellowLoadding.transform.localScale = new Vector3(yellowLoadding.transform.localScale.x + 0.05f,
                                                                  yellowLoadding.transform.localScale.y,
                                                                  yellowLoadding.transform.localScale.z);
                //LoaddingTimeCD更新
                LoaddingTimeCD = Time.time + 0.2f;
            }
        }

        else
        {
            //根据选择的关卡进入不同场景
            if (mainPageScript.boolLoading == true)
            {
                SceneManager.LoadScene(dataScript.sceneID);
            }
            else
            {
                //obj_Loadding隐藏
                gameObject.SetActive(false);
            }
        }
    }
}

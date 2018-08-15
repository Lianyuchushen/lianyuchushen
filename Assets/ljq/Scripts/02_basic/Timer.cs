using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    //用来递增时间
    float floatTime1 = 0;

    //用来计算秒数
    public int timeCount = 0;

    //计时使能
    public bool timeEnable;

    void Start () {

        //初始化
        timeEnable = false;
        floatTime1 = 0;
        timeCount = 0;
    }

    void Update () {

        PrintTime();
    }

    void PrintTime()
    {
        if (timeEnable)
        {
            floatTime1 += Time.deltaTime;//0秒增加每帧时间

            if (floatTime1 > 1)//到达1秒的时候，timeCount更新
            {
                timeCount++;
                floatTime1 = 0;
            }
        }
    }
}

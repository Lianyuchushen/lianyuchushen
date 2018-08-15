using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//此脚本挂到每个场景的摄像机上，使摄像机的
//长宽比等于实际屏幕的长宽比，画面不会变形
//摄像机的高度是不变的，只影响显示的宽度
//iphone-1920×1080-16:9，ipad-2048×1536-4:3

public class ScreenSize : MonoBehaviour {

    Camera mainCamera;

    //设备的屏幕分辨率
    float width;
    float height;

    void Awake(){

        //获取屏幕分辨率
        width = Screen.width;
        height = Screen.height;

        Debug.Log("Screen.width=" + width.ToString() +
            " Screen.height=" + height.ToString());

        //设置相机的显示
        mainCamera = Camera.main;
        //摄像机的长宽比（宽度除以高度），注意是float
        mainCamera.aspect = width / height;
    }
}

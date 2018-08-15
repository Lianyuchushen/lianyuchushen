using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//在Android设备上按返回键退出
public class AndroidAPP : MonoBehaviour
{

    void Update()
    {
#if UNITY_ANDROID
        // To handle 'back' button on Android devices
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
}

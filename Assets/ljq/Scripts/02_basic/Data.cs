using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//全局存在，存储相关信息
public class Data : MonoBehaviour {

    static Data data_instance = null;

    //存储的数据

    //用户ID
    public int userID;
    //当前选择的关卡号
    public int level;
    //关卡号对应的场景名称
    public string  sceneID;

    //此脚本永不消毁，并且每次进入初始场景时进行判断，若存在重复的则销毁  
    void Awake () {

        if (data_instance == null)
        {
            data_instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != data_instance)
        {
            Destroy(gameObject);
        }
    }

    void Start () {

    }

	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏物体的触控事件和碰撞事件
public class A_1_ObjectController : MonoBehaviour {

    //物体本身
    Transform Player;
    //这个物体的外层全部
    GameObject father_object;

    //记录起始位置
    Vector3 position_reset;
    Quaternion rotation_reset;

    //脚本
    A_1_GameController game_controller;
    MusicController musicControlScript;
    A_1_ScoreBar scoreBarScript;

    //对象的状态 0待机 1选中 2拖动
    public int animIndex;
    //当前对象的编号
    //int object_num;

    void Start () {

        //获取物体本身
        Player = gameObject.transform;
        position_reset = gameObject.transform.position;
        rotation_reset = gameObject.transform.rotation;

        //获取外层物体
        father_object = transform.parent.gameObject.transform.parent.gameObject;

        //获取脚本内容
        game_controller = GameObject.Find("GameController").GetComponent<A_1_GameController>();
        musicControlScript = GameObject.Find("MusicController").GetComponent<MusicController>();
        scoreBarScript = GameObject.Find("UI/StarBar").GetComponent<A_1_ScoreBar>();

        //设置对象为待机
        animIndex = 0;
    }
	
	void Update () {
		
	}

    //将屏幕获取的2D坐标转换成3D坐标返回
    Vector3 GetWorldPos(Vector2 screenPos)
    {

        //声明mainCamera是主镜头
        Camera mainCamera = Camera.main;

        //返回主镜头投射出的世界坐标
        return mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Mathf.Abs(0 - mainCamera.transform.position.z)));

    }

    //按下事件
    void OnFingerDown(FingerDownEvent e)
    {
        //如果选取目标对象为本物体
        if (e.Selection == gameObject)
        {
            //设置控制器中选定的物体为本物体
            game_controller.selection = gameObject;
            //手指不松开不检测碰撞
            game_controller.isMotionEnd = false;
            //让正选中的物体移到别的上面，就能不受阻碍
            gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, -1);

        }

    }

    //手指移动事件
    void OnFingerMove(FingerMotionEvent e)
    {

        //如果事件状态是移动开始状态
        if (e.Phase == FingerMotionPhase.Started)
        {

            //如果选择本物体，且与控制器中当前选定的物体一致
            if (e.Selection == gameObject && game_controller.selection == gameObject)
            {
                gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, -1);
                //进入拖动的状态
                animIndex = 2;
            }
        }

        //如果事件状态是移动结束状态
        else if (e.Phase == FingerMotionPhase.Ended)
        {

            //如果选择本物体，且与控制器中当前选定的物体一致
            if (e.Selection == gameObject && game_controller.selection == gameObject)
            {
                //如果是拖动状态
                if (animIndex == 2)
                {
                    //角色的位置等于鼠标的位置
                    //gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, -0.5f);
                    animIndex = 0;
                    
                }
            }
        }

        //如果事件状态是移动中状态
        else if (e.Phase == FingerMotionPhase.Updated)
        {

            //如果选择本物体，且与控制器中当前选定的物体一致
            if (e.Selection == gameObject && game_controller.selection == gameObject)
            {
                //如果是拖动状态
                if (animIndex == 2)
                {
                    //角色的位置等于鼠标的位置
                    gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, -1);
                    
                }
            }
        }
    
    }

    //按下放开事件
    void OnFingerUp(FingerUpEvent e)
    {

        //如果选取目标对象为本物体
        if (e.Selection == gameObject)
        {
            //设置控制器中选定的物体为空
            game_controller.selection = null;
            //手指不松开不检测碰撞
            game_controller.isMotionEnd = true;
            //松手回复z坐标
            gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, 1);
            
        }

    }

    //点击事件
    void OnTap(TapGesture gesture)
    {

        ////点击图片1
        //if (gesture.Selection == gameObject)
        //{
        //    //如果是待机状态
        //    if (animIndex == 0)
        //    {
        //        //选中状态
        //        animIndex = 1;
        //    }
        //    else
        //    {
        //        //取消选中
        //        animIndex = 0;
        //    }
        //}
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (game_controller.isMotionEnd)
        {
            game_controller.operation++;

            //组件1的情况
            if (gameObject.name == "game1_left_big")
            {
                if (c.gameObject.name == "game1_right_big")
                {
                    Destroy(father_object, 0f);
                    game_controller.count_for_round++;
                    game_controller.count++;
                    musicControlScript.playSound1(6);
                    scoreBarScript.ScoreBar_update();
                }
                if (c.gameObject.name == "game1_left_small" || c.gameObject.name == "game1_right_small")
                {
                    Player.SetPositionAndRotation(position_reset, rotation_reset);
                    animIndex = 0;
                    musicControlScript.playSound1(8);
                }
            }

            //组件2的情况
            if (gameObject.name == "game1_left_small")
            {
                if (c.gameObject.name == "game1_right_small")
                {
                    Destroy(father_object, 0f);
                    game_controller.count_for_round++;
                    game_controller.count++;
                    musicControlScript.playSound1(6);
                    scoreBarScript.ScoreBar_update();
                }
                if (c.gameObject.name == "game1_left_big" || c.gameObject.name == "game1_right_big")
                {
                    Player.SetPositionAndRotation(position_reset, rotation_reset);
                    animIndex = 0;
                    musicControlScript.playSound1(8);
                }
            }

            //组件3的情况
            if (gameObject.name == "game1_right_small")
            {
                if (c.gameObject.name == "game1_left_small")
                {
                    Destroy(father_object, 0f);
                    game_controller.count_for_round++;
                    game_controller.count++;
                    musicControlScript.playSound1(6);
                    scoreBarScript.ScoreBar_update();
                }
                if (c.gameObject.name == "game1_left_big" || c.gameObject.name == "game1_right_big")
                {
                    Player.SetPositionAndRotation(position_reset, rotation_reset);
                    animIndex = 0;
                    musicControlScript.playSound1(8);
                }
            }

            //组件4的情况
            if (gameObject.name == "game1_right_big")
            {
                if (c.gameObject.name == "game1_left_big")
                {
                    //Player.SetPositionAndRotation(c.gameObject.transform.position, c.gameObject.transform.rotation);
                    Destroy(father_object, 0f);
                    game_controller.count_for_round++;
                    game_controller.count++;
                    musicControlScript.playSound1(6);
                    scoreBarScript.ScoreBar_update();
                }
                if (c.gameObject.name == "game1_right_small" || c.gameObject.name == "game1_left_small")
                {
                    Player.SetPositionAndRotation(position_reset, rotation_reset);
                    animIndex = 0;
                    musicControlScript.playSound1(8);
                }
            }

        }


    }
}

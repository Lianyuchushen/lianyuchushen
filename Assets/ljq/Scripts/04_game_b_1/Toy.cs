using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//挂在toy和book上
public class Toy : MonoBehaviour {

    //物体本身
    Transform Player;

    //脚本
    GameController_b game_controller;
    MusicController musicControlScript;
    GameController_b_1 game_controller_b_1;

    //对象的状态 0待机 1选中 2拖动
    public int animIndex;

    void Start () {

        //获取物体本身
        Player = gameObject.transform;

        //获取脚本内容
        game_controller = GameObject.Find("GameController").GetComponent<GameController_b>();
        game_controller_b_1 = GameObject.Find("GameController").GetComponent<GameController_b_1>();
        musicControlScript = GameObject.Find("Music").GetComponent<MusicController>();

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
            musicControlScript.playSound1(9);
            //设置控制器中选定的物体为本物体
            game_controller.selection = gameObject;
            //手指不松开不检测碰撞
            game_controller.isMotionEnd = false;
            //让正选中的物体移到别的上面，就能不受阻碍
            gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, -2);

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
                gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, -2);
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
                    gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, -2);

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
            gameObject.transform.position = GetWorldPos(e.Position) + new Vector3(0, 0, -1);

        }

    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (game_controller.isMotionEnd)
        {

            //放对了
            if (c.gameObject.name == "box" && ( gameObject.name == "toy1" || gameObject.name == "toy2" || gameObject.name == "toy3" || gameObject.name == "toy4" ))
            {
                game_controller_b_1.toy_finish++;
                Destroy(gameObject, 0f);

                musicControlScript.playSound1(2);
            }
            if (c.gameObject.name == "bookcase" && (gameObject.name == "book1" || gameObject.name == "book2" || gameObject.name == "book3" ))
            {
                game_controller_b_1.book_finish++;
                Destroy(gameObject, 0f);

                musicControlScript.playSound1(2);
            }
        }
    }
}

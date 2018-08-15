using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//挂在box，bookcase上
public class Box : MonoBehaviour {

    //盒子中的每一个玩具
    public GameObject toy_1;
    public GameObject toy_2;
    public GameObject toy_3;
    public GameObject toy_4;
    //书柜上的每一本书
    public GameObject book_1;
    public GameObject book_2;
    public GameObject book_3;

    //脚本
    GameController_b game_controller;

    //颜文字动作控制器
    Animator yanwenzi_anim;

    void Start () {

        //获取脚本内容
        game_controller = GameObject.Find("GameController").GetComponent<GameController_b>();
        yanwenzi_anim = GameObject.Find("yanwenzi6_1").GetComponent<Animator>();

        if (gameObject.name == "box")
        {
            toy_1.SetActive(false);
            toy_2.SetActive(false);
            toy_3.SetActive(false);
            toy_4.SetActive(false);
        }

        if (gameObject.name == "bookcase")
        {
            book_1.SetActive(false);
            book_2.SetActive(false);
            book_3.SetActive(false);
        }
            
    }

	void Update () {
		
	}

    //碰撞事件
    void OnTriggerStay2D(Collider2D c)
    {
        if (game_controller.isMotionEnd)
        {
            if (gameObject.name == "box")
            {
                if (c.gameObject.name == "toy1")
                {
                    toy_1.SetActive(true);
                    yanwenzi_anim.SetTrigger("right");

                }
                if (c.gameObject.name == "toy2")
                {
                    toy_2.SetActive(true);
                    yanwenzi_anim.SetTrigger("right");

                }
                if (c.gameObject.name == "toy3")
                {
                    toy_3.SetActive(true);
                    yanwenzi_anim.SetTrigger("right");

                }
                if (c.gameObject.name == "toy4")
                {
                    toy_4.SetActive(true);
                    yanwenzi_anim.SetTrigger("right");

                }
            }

            if (gameObject.name == "bookcase")
            {
                if (c.gameObject.name == "book1")
                {
                    book_1.SetActive(true);
                    yanwenzi_anim.SetTrigger("right");

                }
                if (c.gameObject.name == "book2")
                {
                    book_2.SetActive(true);
                    yanwenzi_anim.SetTrigger("right");

                }
                if (c.gameObject.name == "book3")
                {
                    book_3.SetActive(true);
                    yanwenzi_anim.SetTrigger("right");

                }
            }

        }

    }
}

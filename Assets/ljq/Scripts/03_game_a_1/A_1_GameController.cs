using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//挂在GameController上
//level 1-4,7-8
public class A_1_GameController : MonoBehaviour {

    //——————————游戏数据——————————

    //目前在第几轮
    public int round;
    //整个关卡进度（20结束）
    public int count;
    //一轮的进度
    public int count_for_round;
    //一轮操作几次完成
    public int operation;

    //一回合的计时
    int time_for_group;
    //无操作的时间
    public float time_no_operation;

    //当前拖动的物体，或当前选中的物体
    public GameObject selection;
    //开始移动为false，移动结束为true
    //在移动中不检测碰撞
    public bool isMotionEnd;

    ////——————————游戏中动态出现的物体——————————

    //初级中级4个物体的预制体
    public GameObject Prefab_left_big;
    public GameObject Prefab_left_small;
    public GameObject Prefab_right_small;
    public GameObject Prefab_right_big;

    //被创建出的预制体的SpriteRenderer
    SpriteRenderer clone_left_big;
    SpriteRenderer clone_left_small;
    SpriteRenderer clone_right_small;
    SpriteRenderer clone_right_big;

    //——————————预先设置好的参数——————————

    //4个物体的位置
    Vector2[] position_scene1 = new Vector2[4];

    //存储所有的图片
    //level1
    public Sprite[] game1_left_big;
    public Sprite[] game1_left_small;
    public Sprite[] game1_right_small;
    public Sprite[] game1_right_big;
    string[] topic_level_1 = { "'篮子-篮球'", "'猫-鱼'", "'笔-纸'", "'青蛙-荷叶'", "'玩具熊-礼物盒'" };

    //——————————链接场景中的物体——————————

    //UI中的项目
    public GameObject dialog_1;
    public GameObject AnimBeginning;
    public GameObject AnimEnd;
    public GameObject GameUI;
    public GameObject Tutu;
    public GameObject IceCream;
    public GameObject StarBar;


    //——————————链接脚本——————————

    Data dataScript;
    MusicController musicControllerScript;
    DbController DbControllerScript;
    Timer timerScript;
    A_1_ScoreBar scoreBarScript;


    //——————————Start——————————

    void Start () {
       
        //设置4个物体位置
        position_scene1[0] = new Vector2(4.5f, -0.5f);
        position_scene1[1] = new Vector2(1.5f, 2.5f);
        position_scene1[2] = new Vector2(-4.5f, 2.5f);
        position_scene1[3] = new Vector2(-1.5f, -0.5f);

        //获取脚本
        dataScript = GameObject.Find("Data").GetComponent<Data>();
        musicControllerScript = GameObject.Find("MusicController").GetComponent<MusicController>();
        timerScript = gameObject.GetComponent<Timer>();
        DbControllerScript = gameObject.GetComponent<DbController>();
        dataScript = GameObject.Find("Data").GetComponent<Data>();
        scoreBarScript = StarBar.GetComponent<A_1_ScoreBar>();

        //初始化
        DbControllerScript.level = dataScript.level;
        DbControllerScript.round = 1;
        DbControllerScript.point = 0;
        DbControllerScript.date = "'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
        DbControllerScript.topic = " ";
        DbControllerScript.time = 0;
        count = 0;
        round = 1;
        operation = 0;
        time_for_group = 0;
        time_no_operation = 0;
        isMotionEnd = false;

        //界面初始化
        dialog_1.SetActive(false);
        AnimBeginning.SetActive(false);
        AnimEnd.SetActive(false);
        GameUI.SetActive(false);
        Tutu.SetActive(false);
        IceCream.SetActive(false);
        StarBar.SetActive(true);
        AnimBeginning.SetActive(true);

        //——————————游戏开始时最初的动画效果——————————

        //设置播放哪一首bgm
        musicControllerScript.BGM_playing = 6;
        //1s后播放游戏开始的提示语音
        Invoke("play_first_speak", 1f);

        ////游戏开始动画，9s后删除动画，并显示UI
        AnimBeginning.SetActive(true);
        Invoke("kill_AnimBeginning", 9f);

        //延时10秒后，动画播放完毕，进入关卡循环
        Invoke("enter_next_group", 10f);
    }

    void play_first_speak()
    {
        musicControllerScript.playSpeak(1);
    }

    void kill_AnimBeginning()
    {
        AnimBeginning.SetActive(false);
        GameUI.SetActive(true);
        Tutu.SetActive(true);
        IceCream.SetActive(true);
    }

    void Update () {

        //——————————游戏流程控制——————————

        //无操作时间累加
        time_no_operation += Time.deltaTime;

        ////10秒没有操作
        //if (time_no_operation >= 10)
        //{
        //    anim_player_anim_controller.runtimeAnimatorController = anim_anim_player[1];
        //    anim_player.SetActive(true);
        //}

        //这里是一回合结束
        if (count_for_round == 4)
        {
            DbControllerScript.topic = topic_level_1[round - 1];
            DbControllerScript.time = timerScript.timeCount - time_for_group;
            DbControllerScript.point = 2 - operation / 2;
            DbControllerScript.Db_write();

            if (round < 5)
            {
                round++;
            }
            operation = 0;
            DbControllerScript.round = round;

            count_for_round = 0;

            time_for_group = timerScript.timeCount;

            //scoreBarScript.BarUpdate();
            //scoreBarScript.StarUpdate();
            //scoreBarScript.YanwenzijunUpdate();

            //如果本关还没结束，进入下一轮
            if (count < 20)
            {
                //anim_player.SetActive(true);

                Invoke("enter_next_group", 1f);
            }
        }

        //5组素材，则本关结束
        if (count == 20)
        {
            timerScript.timeEnable = false;
            musicControllerScript.playSound1(1);
            musicControllerScript.playSpeak(2);
            dialog_1.SetActive(true);
            count++;
        }
    }

    //新的一回合
    void enter_next_group()
    {

        //第一回合进入时，打开计时
        if (timerScript.timeEnable == false)
        {
            timerScript.timeEnable = true;
        }
        //anim_player.SetActive(false);

        if (dataScript.level == 1)
        {

            //创建4个对象
            Instantiate(Prefab_left_big, position_scene1[0], Quaternion.identity);
            Instantiate(Prefab_left_small, position_scene1[1], Quaternion.identity);
            Instantiate(Prefab_right_big, position_scene1[2], Quaternion.identity);
            Instantiate(Prefab_right_small, position_scene1[3], Quaternion.identity);

            //找到这几个物体的SpriteRenderer
            clone_left_big = GameObject.Find("game_a_1_Object1(Clone)/bubble_1/game1_left_big").GetComponent<SpriteRenderer>();
            clone_left_small = GameObject.Find("game_a_1_Object2(Clone)/bubble_2/game1_left_small").GetComponent<SpriteRenderer>();
            clone_right_small = GameObject.Find("game_a_1_Object3(Clone)/bubble_3/game1_right_small").GetComponent<SpriteRenderer>();
            clone_right_big = GameObject.Find("game_a_1_Object4(Clone)/bubble_4/game1_right_big").GetComponent<SpriteRenderer>();

            //设置图片
            clone_left_big.sprite = game1_left_big[round - 1];
            clone_left_small.sprite = game1_left_small[round - 1];
            clone_right_small.sprite = game1_right_big[round - 1];
            clone_right_big.sprite = game1_right_small[round - 1];
        }
        //else if (dataScript.level == 2)
        //{
        //    //将4个物体放到随机的位置
        //    object_1 = Random.Range(1, 5);
        //    object_2 = Random.Range(1, 5);
        //    if (object_2 == object_1)
        //    {
        //        object_2++;
        //        if (object_2 > 4)
        //        {
        //            object_2 = 1;
        //        }
        //    }
        //    object_3 = Random.Range(1, 5);
        //    if (object_3 == object_1 || object_3 == object_2)
        //    {
        //        object_3++;
        //        if (object_3 > 4)
        //        {
        //            object_3 = 1;
        //        }
        //    }
        //    if (object_3 == object_1 || object_3 == object_2)
        //    {
        //        object_3++;
        //        if (object_3 > 4)
        //        {
        //            object_3 = 1;
        //        }
        //    }
        //    object_4 = 1;
        //    while (object_4 == object_1 || object_4 == object_2 || object_4 == object_3)
        //    {
        //        object_4++;
        //    }

        //    //分配动画
        //    image_pair = Random.Range(0, IMAGE_NUM_GAME_1_2_3); //在n对图片中选择一对
        //    DbControllerScript.topic = topic_game1_2_3[image_pair];
        //    //image_left_big = game2_left_big[image_pair];
        //    //image_left_small = game2_left_small[image_pair];
        //    //image_right_big = game2_right_big[image_pair];
        //    //image_right_small = game2_right_small[image_pair];

        //    //创建4个对象
        //    Instantiate(Prefab_left_big, position_scene1[object_1 - 1], Quaternion.identity);
        //    Instantiate(Prefab_left_small, position_scene1[object_2 - 1], Quaternion.identity);
        //    Instantiate(Prefab_right_big, position_scene1[object_3 - 1], Quaternion.identity);
        //    Instantiate(Prefab_right_small, position_scene1[object_4 - 1], Quaternion.identity);


        //}
        //else if (dataScript.level == 4)
        //{
        //    //安排物体的位置
        //    object_1 = Random.Range(1, 3);
        //    if (object_1 == 1)
        //    {
        //        object_2 = 2;
        //        object_3 = 3;
        //        object_4 = 4;
        //    }
        //    else
        //    {
        //        object_2 = 1;
        //        object_3 = 4;
        //        object_4 = 3;
        //    }

        //    //分配动画
        //    image_pair = Random.Range(0, IMAGE_NUM_GAME_4_5_6); //在n对图片中选择一对
        //    DbControllerScript.topic = topic_game4_5_6[image_pair];
        //    //image_left_big = game4_left_big[image_pair];
        //    //image_left_small = game4_left_small[image_pair];
        //    //image_right_big = game4_right_big[image_pair];
        //    //image_right_small = game4_right_small[image_pair];

        //    //创建4个对象
        //    Instantiate(Prefab_left_big, position_scene1[object_1 - 1], Quaternion.identity);
        //    Instantiate(Prefab_left_small, position_scene1[object_2 - 1], Quaternion.identity);
        //    Instantiate(Prefab_right_big, position_scene1[object_3 - 1], Quaternion.identity);
        //    Instantiate(Prefab_right_small, position_scene1[object_4 - 1], Quaternion.identity);


        //}
        //else if (dataScript.level == 5)
        //{
        //    //将4个物体放到随机的位置
        //    object_1 = Random.Range(1, 5);
        //    object_2 = Random.Range(1, 5);
        //    if (object_2 == object_1)
        //    {
        //        object_2++;
        //        if (object_2 > 4)
        //        {
        //            object_2 = 1;
        //        }
        //    }
        //    object_3 = Random.Range(1, 5);
        //    if (object_3 == object_1 || object_3 == object_2)
        //    {
        //        object_3++;
        //        if (object_3 > 4)
        //        {
        //            object_3 = 1;
        //        }
        //    }
        //    if (object_3 == object_1 || object_3 == object_2)
        //    {
        //        object_3++;
        //        if (object_3 > 4)
        //        {
        //            object_3 = 1;
        //        }
        //    }
        //    object_4 = 1;
        //    while (object_4 == object_1 || object_4 == object_2 || object_4 == object_3)
        //    {
        //        object_4++;
        //    }

        //    //分配动画
        //    image_pair = Random.Range(0, IMAGE_NUM_GAME_4_5_6); //在n对图片中选择一对
        //    DbControllerScript.topic = topic_game4_5_6[image_pair];
        //    //image_left_big = game5_left_big[image_pair];
        //    //image_left_small = game5_left_small[image_pair];
        //    //image_right_big = game5_right_big[image_pair];
        //    //image_right_small = game5_right_small[image_pair];

        //    //创建4个对象
        //    Instantiate(Prefab_left_big, position_scene1[object_1 - 1], Quaternion.identity);
        //    Instantiate(Prefab_left_small, position_scene1[object_2 - 1], Quaternion.identity);
        //    Instantiate(Prefab_right_big, position_scene1[object_3 - 1], Quaternion.identity);
        //    Instantiate(Prefab_right_small, position_scene1[object_4 - 1], Quaternion.identity);

        //}
    }
}

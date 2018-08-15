using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;

public class DbController : MonoBehaviour
{

    DbAccess db;

    //题目与什么有关
    public string topic;

    //第几回合
    public int round;

    //得分（错误次数）
    public int point;

    //游戏的关卡是哪个
    public int level;

    //游戏的日期
    public string date;

    //游戏完成的时间
    public int time;

    public void Db_write()
    {
        db.InsertInto("lianyuchushen1", new string[] { date, level.ToString(), round.ToString(), topic, point.ToString(), time.ToString() });
    }

    void Start()
    {

        ////数据库文件储存地址  
        //string appDBPath = Application.persistentDataPath + "/zyc.db";  
        ////注意！！！！！！！这行代码的改动  
        //DbAccess db = new DbAccess("URI=file:" + appDBPath);  

        //如果运行在编辑器中  
#if UNITY_EDITOR
        //通过路径找到第三方数据库  
        string appDBPath = Application.dataPath + "/ljq/Plugins/Android/assets/" + "lianyuchushen.db";
        db = new DbAccess("URI=file:" + appDBPath);
        //DbAccess db = new DbAccess("URI=file:" + appDBPath);  

        //如果运行在Android设备中  
#elif UNITY_ANDROID
        //将第三方数据库拷贝至Android可找到的地方  
        string appDBPath = Application.persistentDataPath + "/" + "lianyuchushen.db";  
          
        //如果已知路径没有地方放数据库，那么我们从Unity中拷贝  
        if(!File.Exists(appDBPath))  
        {  
            //用www先从Unity中下载到数据库  
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "lianyuchushen.db");   
  
            while(!loadDB.isDone){}  
             //拷贝至规定的地方  
             File.WriteAllBytes(appDBPath, loadDB.bytes);                
        }  
   
        //在这里重新得到db对象。  
        db = new DbAccess("URI=file:" + appDBPath);  
        //DbAccess db = new DbAccess("URI=file:" + appDBPath);
#endif

        //db.CreateTable("PuzzleDebris", new string[] { "_coordinates_number", "_number", "_value" }, new string[] { "text", "text", "text" });
        //db.InsertInto("card", new string[] { "'21'", "'大象'", "'zyc21'" });
        //db.InsertInto("card", new string[] { "'22'", "'狗  '", "'zyc22'" });
        //using (SqliteDataReader sqReader = db.SelectWhere("card", new string[] { "an_name", "bk_name" }, new string[] { "id_name" }, new string[] { "=" }, new string[] { "6" }))
        //{
        //    Debug.Log("Begining Select !!!");
        //    while (sqReader.Read())
        //    {
        //        //目前中文无法显示  
        //        Debug.Log("zyc" + sqReader.GetString(sqReader.GetOrdinal("an_name")));
        //        Debug.Log("zyc" + sqReader.GetString(sqReader.GetOrdinal("bk_name")));
        //        an_name = sqReader.GetString(sqReader.GetOrdinal("an_name"));
        //        bk_name = sqReader.GetString(sqReader.GetOrdinal("bk_name"));

        //        objText.text = an_name;
        //    }

        //    sqReader.Close();

        //    db.CloseSqlConnection();
        //}

    }

    void Update()
    {

    }

}
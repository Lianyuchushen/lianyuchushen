using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookbagPanel : MonoBehaviour {

    //脚本
    MusicController musicControlScript;

    //bookbag_panel
    public GameObject bookbag_panel;
    //原来界面上的按钮
    public GameObject ui_button;

    //book的列表
    public GameObject book_list;
    //penceil的列表
    public GameObject pencil_list;
    //目前正显示的列表
    GameObject now_select;

    //所有物体被选中的显示
    public GameObject[] item_selected;
    public GameObject[] book_selected;
    public GameObject[] pencil_selected;
    //目前被选中的物体的高亮
    GameObject now_item_selected;
    GameObject now_book_selected;
    GameObject now_pencil_selected;

    //所有可选择物品的图片
    public Sprite[] book_texture;
    public Sprite[] pencil_texture;

    //声明需要改变图片的按钮
    public Image book_button;
    public Image pencil_button;

    //提示
    public GameObject Tutorial3;

    void Start () {
        musicControlScript = GameObject.Find("Music").GetComponent<MusicController>();
        Tutorial3.SetActive(true);
    }
	
	void Update () {
		
	}

    //按钮点击事件
    //BookbagPanel close
    public void BookbagPanel_close_click()
    {
        musicControlScript.playSound1(9);
        bookbag_panel.SetActive(false);
        ui_button.SetActive(true);
    }

    //按钮点击事件
    //item中的book
    public void book_click()
    {
        musicControlScript.playSound1(9);

        Tutorial3.SetActive(false);

        //显示book选择界面
        if (now_select)
        {
            now_select.SetActive(false);
        }
        book_list.SetActive(true);
        now_select = book_list;

        //显示book按钮高亮
        if (now_item_selected)
        {
            now_item_selected.SetActive(false);
        }
        item_selected[0].SetActive(true);
        now_item_selected = item_selected[0];


    }

    //按钮点击事件
    //item中的pencil
    public void pencil_click()
    {
        musicControlScript.playSound1(9);

        Tutorial3.SetActive(false);

        //显示pencil选择界面
        if (now_select)
        {
            now_select.SetActive(false);
        }
        pencil_list.SetActive(true);
        now_select = pencil_list;

        //显示book按钮高亮
        if (now_item_selected)
        {
            now_item_selected.SetActive(false);
        }
        item_selected[1].SetActive(true);
        now_item_selected = item_selected[1];
    }

    //按钮点击事件
    //book中的book1
    public void book1_click()
    {
        musicControlScript.playSound1(9);

        //显示高亮
        if (now_book_selected)
        {
            now_book_selected.SetActive(false);
        }
        book_selected[0].SetActive(true);
        now_book_selected = book_selected[0];

        //更改图片
        book_button.GetComponent<Image>().sprite = book_texture[0];
    }

    //按钮点击事件
    //book中的book2
    public void book2_click()
    {
        musicControlScript.playSound1(9);

        //显示高亮
        if (now_book_selected)
        {
            now_book_selected.SetActive(false);
        }
        book_selected[1].SetActive(true);
        now_book_selected = book_selected[1];

        //更改图片
        book_button.GetComponent<Image>().sprite = book_texture[1];
    }

    //按钮点击事件
    //book中的book3
    public void book3_click()
    {
        musicControlScript.playSound1(9);

        //显示高亮
        if (now_book_selected)
        {
            now_book_selected.SetActive(false);
        }
        book_selected[2].SetActive(true);
        now_book_selected = book_selected[2];

        //更改图片
        book_button.GetComponent<Image>().sprite = book_texture[2];
    }

    //按钮点击事件
    //book中的book4
    public void book4_click()
    {
        musicControlScript.playSound1(9);

        //显示高亮
        if (now_book_selected)
        {
            now_book_selected.SetActive(false);
        }
        book_selected[3].SetActive(true);
        now_book_selected = book_selected[3];

        //更改图片
        book_button.GetComponent<Image>().sprite = book_texture[3];
    }

    //按钮点击事件
    //pencil中的pencil1
    public void pencil1_click()
    {
        musicControlScript.playSound1(9);

        //显示高亮
        if (now_pencil_selected)
        {
            now_pencil_selected.SetActive(false);
        }
        pencil_selected[0].SetActive(true);
        now_pencil_selected = pencil_selected[0];

        //更改图片
        pencil_button.GetComponent<Image>().sprite = pencil_texture[0];
    }

    //按钮点击事件
    //pencil中的pencil2
    public void pencil2_click()
    {
        musicControlScript.playSound1(9);

        //显示高亮
        if (now_pencil_selected)
        {
            now_pencil_selected.SetActive(false);
        }
        pencil_selected[1].SetActive(true);
        now_pencil_selected = pencil_selected[1];

        //更改图片
        pencil_button.GetComponent<Image>().sprite = pencil_texture[1];
    }

    //按钮点击事件
    //pencil中的pencil3
    public void pencil3_click()
    {
        musicControlScript.playSound1(9);

        //显示高亮
        if (now_pencil_selected)
        {
            now_pencil_selected.SetActive(false);
        }
        pencil_selected[2].SetActive(true);
        now_pencil_selected = pencil_selected[2];

        //更改图片
        pencil_button.GetComponent<Image>().sprite = pencil_texture[2];
    }

    //按钮点击事件
    //pencil中的pencil4
    public void pencil4_click()
    {
        musicControlScript.playSound1(9);

        //显示高亮
        if (now_pencil_selected)
        {
            now_pencil_selected.SetActive(false);
        }
        pencil_selected[3].SetActive(true);
        now_pencil_selected = pencil_selected[3];

        //更改图片
        pencil_button.GetComponent<Image>().sprite = pencil_texture[3];
    }

}

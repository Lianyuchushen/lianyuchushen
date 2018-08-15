using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class AdventureLevelManager : MonoBehaviour {

    public GameObject RightSlide_Button;
    public GameObject LeftSlide_Button;
    public GameObject AdventureLevel_Holder;
    public float slideSpeed = 1.0f;

    private void Start()
    {
        AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    public static void Load_AdventureLevel(int num)
    {
        print(num);
    }

    public void Right_Slide()
    {
        if (AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition.x >= 0) return;
        StartCoroutine(RS());
    }
    IEnumerator RS()
    {
        Vector2 initialPos = AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition;
        Vector2 destPos = AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition + new Vector2(700, 0);

        RightSlide_Button.SetActive(false);
        LeftSlide_Button.SetActive(false);

        for (float i = initialPos.x; i <= destPos.x; i += Time.deltaTime * slideSpeed)
        {
            AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition = new Vector2(i, destPos.y);
            yield return null;
        }

        AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition = destPos;
        RightSlide_Button.SetActive(true);
        LeftSlide_Button.SetActive(true);
    }


    public void Left_Slide()
    {
        if (AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition.x <= -2100) return;
        StartCoroutine(LS());
    }
    IEnumerator LS()
    {
        Vector2 initialPos = AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition;
        Vector2 destPos = AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition - new Vector2(700, 0);

        RightSlide_Button.SetActive(false);
        LeftSlide_Button.SetActive(false);

        for (float i = initialPos.x; i >= destPos.x; i -= Time.deltaTime * slideSpeed)
        {
            AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition = new Vector2(i, destPos.y);
            yield return null;
        }

        AdventureLevel_Holder.GetComponent<RectTransform>().anchoredPosition = destPos;
        RightSlide_Button.SetActive(true);
        LeftSlide_Button.SetActive(true);
    }


}

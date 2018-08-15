using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelData_Load : MonoBehaviour {

    // index in levelPrefab_LoadUI_List
    public int index;

    public string levelName;
    public string levelDir;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (SaveLoadData.previousLevelPrefab_LoadUI != gameObject)
        {
            if (SaveLoadData.currentLevelPrefab_LoadUI == null)
            {
                SaveLoadData.currentLevelPrefab_LoadUI = gameObject;
                SaveLoadData.currentLevelPrefab_LoadUI.GetComponent<Image>().color = new Vector4(0.1f, 0.3f, 0.7f, 0.6f);
            }
            else
            {
                SaveLoadData.previousLevelPrefab_LoadUI = SaveLoadData.currentLevelPrefab_LoadUI;
                SaveLoadData.currentLevelPrefab_LoadUI = gameObject;

                SaveLoadData.previousLevelPrefab_LoadUI.GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 0.6f);
                SaveLoadData.currentLevelPrefab_LoadUI.GetComponent<Image>().color = new Vector4(0.1f, 0.3f, 0.7f, 0.6f);

                SaveLoadData.previousLevelPrefab_LoadUI = gameObject;
            }
        }
    }

}

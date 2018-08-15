using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// enum type CurrentLevelMode include all gamemode
public enum LevelType
{
    LinearGame_SameMatch_Basic,
    LinearGame_SameMatch_Intermediate,
    LinearGame_SameMatch_Advanced,

    LinearGame_DifferentMatch_Basic,
    LinearGame_DifferentMatch_Intermediate,
    LinearGame_DifferentMatch_Advanced,

    LinearGame_Perception_Basic,
    LinearGame_Perception_Intermediate,
    LinearGame_Perception_Advanced,

    LinearGame_Expression_Basic,
    LinearGame_Expression_Intermediate,
    LinearGame_Expression_Advanced,
}

// SaveLoadLeveTypeChoose
public class SaveLoadData : MonoBehaviour
{
	#region attributes
    private static Encoding encoding = Encoding.UTF8;

    #region target data used in save and load
    public static LinearGame_SameMatch_Basic_Data targetData_LGSMB;
    public static LinearGame_SameMatch_Intermediate_Data targetData_LGSMI;
    public static LinearGame_SameMatch_Advanced_Data targetData_LGSMA;

    public static LinearGame_DifferentMatch_Basic_Data targetData_LGDMB;
    public static LinearGame_DifferentMatch_Intermediate_Data targetData_LGDMI;
    public static LinearGame_DifferentMatch_Advanced_Data targetData_LGDMA;

    public static LinearGame_Perception_Basic_Data targetData_LGPB;
    public static LinearGame_Perception_Intermediate_Data targetData_LGPI;
    public static LinearGame_Perception_Advanced_Data targetData_LGPA;

    public static LinearGame_Expression_Basic_Data targetData_LGEB;
    public static LinearGame_Expression_Intermediate_Data targetData_LGEI;
    public static LinearGame_Expression_Advanced_Data targetData_LGEA;
    #endregion

    #region Create Custom Game Attributse
    // dropdown ui to show which gamemode to create
    public Dropdown dropDown_gameMode_Create;

    // interval between sublevels and addSublevel_UI and border
    public float interval = 30;

    // current gamemode to create
    public static LevelType LevelModeToCreate;

    // current gamemode template in template list
    public GameObject currentTemplate = null;

    public List<GameObject> SubLevelTemplateList_UI;

    public GameObject LevelListHolder;

    public GameObject SuccesslyCreateLevel_Popup;

    public GameObject NameLevel_Popup;

    // current sublevel template width and height
    public float currentTemplateWidth;
    public float currentTemplateHeight;

    // current image button select on sublevel list and showimage list
    public static GameObject currentImage_Selected_Template;
    public static GameObject currentImage_Selected_Show;

    // the data to save after creating
    public GameObject saveTarget;

    // the number of sub-level in one level
    public int OneLevelContentLength;

    // the UI to add sub-level
    public GameObject AddLevelDataUI;

    // the UI to cut sub-level
    public GameObject SubtractLevelDataUI;

    #region sub template in different level mode
    [HeaderAttribute("Template")]
    public GameObject LGSM_Basic_Creator_Template = null;   		// CreateCustomLevelMode LinearGame_SameMatch_Basic
	public GameObject LGSM_Intermediate_Creator_Template = null;	// CreateCustomLevelMode LinearGame_SameMatch_Intermediate
	public GameObject LGSM_Advanced_Creator_Template = null;		// CreateCustomLevelMode LinearGame_SameMatch_Advanced

	public GameObject LGDM_Basic_Creator_Template = null;   		// CreateCustomLevelMode LinearGame_DifferentMatch_Basic
	public GameObject LGDM_Intermediate_Creator_Template = null;	// CreateCustomLevelMode LinearGame_DifferentMatch_Intermediate
	public GameObject LGDM_Advanced_Creator_Template = null;		// CreateCustomLevelMode LinearGame_DifferentMatch_Advanced

	public GameObject LGP_Basic_Creator_Template = null;   			// CreateCustomLevelMode LinearGame_Perception_Basic
	public GameObject LGP_Intermediate_Creator_Template = null;		// CreateCustomLevelMode LinearGame_Perception_Intermediate
	public GameObject LGP_Advanced_Creator_Template = null;			// CreateCustomLevelMode LinearGame_Perception_Advanced

	public GameObject LGE_Basic_Creator_Template = null;    		// CreateCustomLevelMode LinearGame_Expression_Basic
	public GameObject LGE_Intermediate_Creator_Template = null;		// CreateCustomLevelMode LinearGame_Expression_Intermediate
	public GameObject LGE_Advanced_Creator_Template = null;         // CreateCustomLevelMode LinearGame_Expression_Advanced
    [Space]
    #endregion
    #endregion

    #region Load Custom Game Attribute
    // dropdown ui to show which gamemode to create
    public Dropdown dropDown_gameMode_Load;

    // current gamemode to load
    public static LevelType LevelModeToLoad;

    // level template prefab in load list
    public GameObject levelPrefab_LoadUI;

    public List<GameObject> levelPrefab_LoadUI_List;

    // current selected level prefab
    public static GameObject currentLevelPrefab_LoadUI;
    // previous selected level prefab
    public static GameObject previousLevelPrefab_LoadUI;

    public GameObject levelPrefabHolder_Load;

    public bool selectLevel = false;

    // rename level input field
    public InputField renameField;

    // rename level UI Popup
    public GameObject RenameLevel_Popup;

    // naming conflicts UI Popup
    public GameObject NamingConflicts_Popup;

    // successfully rename Popup UI
    public GameObject SuccessfullyRename_Popup;
    #endregion

    #endregion

    void Start()
	{
        targetData_LGSMB = new LinearGame_SameMatch_Basic_Data();
        targetData_LGSMI = new LinearGame_SameMatch_Intermediate_Data();
        targetData_LGSMA = new LinearGame_SameMatch_Advanced_Data();

        targetData_LGDMB = new LinearGame_DifferentMatch_Basic_Data();
        targetData_LGDMI = new LinearGame_DifferentMatch_Intermediate_Data();
        targetData_LGDMA = new LinearGame_DifferentMatch_Advanced_Data();

        targetData_LGPB = new LinearGame_Perception_Basic_Data();
        targetData_LGPI = new LinearGame_Perception_Intermediate_Data();
        targetData_LGPA = new LinearGame_Perception_Advanced_Data();

        targetData_LGEB = new LinearGame_Expression_Basic_Data();
        targetData_LGEI = new LinearGame_Expression_Intermediate_Data();
        targetData_LGEA = new LinearGame_Expression_Advanced_Data();



        // Create game data folder
        for(int i = 0; i < 12; i++)
        if (!Directory.Exists(Application.persistentDataPath + "/" + (LevelType)i))
            Directory.CreateDirectory(Application.persistentDataPath + "/" + (LevelType)i);
        
        RefreshLoadList();
    }

	#region Load Custom Level
    public void ChangeGameMode_Load()
    {
        switch (dropDown_gameMode_Load.value)
        {
            //  LinearGame_SameMatch_Basic  0
            case 0:
                LevelModeToLoad = LevelType.LinearGame_SameMatch_Basic;
                break;

            // LinearGame_SameMatch_Intermediate    1
            case 1:
                LevelModeToLoad = LevelType.LinearGame_SameMatch_Intermediate;
                break;

            // LinearGame_SameMatch_Advanced    2
            case 2:
                LevelModeToLoad = LevelType.LinearGame_SameMatch_Advanced;
                break;

            // LinearGame_DifferentMatch_Basic  3
            case 3:
                LevelModeToLoad = LevelType.LinearGame_DifferentMatch_Basic;
                break;

            // LinearGame_DifferentMatch_Intermediate   4
            case 4:
                LevelModeToLoad = LevelType.LinearGame_DifferentMatch_Intermediate;
                break;

            // LinearGame_DifferentMatch_Advanced   5
            case 5:
                LevelModeToLoad = LevelType.LinearGame_DifferentMatch_Advanced;
                break;

            // LinearGame_Perception_Basic  6
            case 6:
                LevelModeToLoad = LevelType.LinearGame_Perception_Basic;
                break;

            // LinearGame_Perception_Intermediate   7
            case 7:
                LevelModeToLoad = LevelType.LinearGame_Perception_Intermediate;
                break;

            // LinearGame_Perception_Advanced   8
            case 8:
                LevelModeToLoad = LevelType.LinearGame_Perception_Advanced;
                break;

            // LinearGame_Expression_Ba sic  9
            case 9:
                LevelModeToLoad = LevelType.LinearGame_Expression_Basic;
                break;

            // LinearGame_Expression_Intermediate   10
            case 10:
                LevelModeToLoad = LevelType.LinearGame_Expression_Intermediate;
                break;

            // LinearGame_Expression_Advanced   11
            case 11:
                LevelModeToLoad = LevelType.LinearGame_Expression_Advanced;
                break;
        }

        RefreshLoadList();
    }
    public void DeleteLevel()
    {
        if(currentLevelPrefab_LoadUI != null)
        {
            // delete data
            SaveLoadManager.Delete
                (
                currentLevelPrefab_LoadUI.GetComponent<LevelData_Load>().levelName,
                currentLevelPrefab_LoadUI.GetComponent<LevelData_Load>().levelDir
                );

            // delete UI
            int index = currentLevelPrefab_LoadUI.GetComponent<LevelData_Load>().index;
            Destroy(levelPrefab_LoadUI_List[index]);
            levelPrefab_LoadUI_List.RemoveAt(index);
            for (int i = index; i < levelPrefab_LoadUI_List.Count; i++)
                levelPrefab_LoadUI_List[i].GetComponent<RectTransform>().anchoredPosition =
                    new Vector2
                    (
                        0,
                        -50 - i * 100
                        );

            levelPrefabHolder_Load.GetComponent<RectTransform>().sizeDelta =
            new Vector2(
                0,
                100 * (index + 1) + 50
                );
        }
    }
    public void RefreshLoadList()
    {
        string filedir;
        int index = 0;

        filedir = string.Format("{0}/{1}", Application.persistentDataPath, LevelModeToLoad);

        for (int i = 0; i < levelPrefab_LoadUI_List.Count; i++)
            Destroy(levelPrefab_LoadUI_List[i]);

        levelPrefab_LoadUI_List.Clear();

        print(filedir);
        DirectoryInfo dir = new DirectoryInfo(filedir);
        foreach(FileInfo info in dir.GetFiles())
        {
            // change data
            levelPrefab_LoadUI_List.Add(Instantiate(levelPrefab_LoadUI));
            levelPrefab_LoadUI_List[index].transform.SetParent(levelPrefabHolder_Load.transform, false);
            levelPrefab_LoadUI_List[index].GetComponent<LevelData_Load>().index = index;
            levelPrefab_LoadUI_List[index].GetComponent<LevelData_Load>().levelName = info.Name;
            levelPrefab_LoadUI_List[index].GetComponent<LevelData_Load>().levelDir = info.DirectoryName;
        
            levelPrefab_LoadUI_List[index].transform.GetChild(0).GetComponent<Text>().text = info.Name;

            // change UI
            levelPrefab_LoadUI_List[index].GetComponent<RectTransform>().anchoredPosition =
                new Vector2(
                    0,
                    -50 - index * 100
                    );

            index++;
        }

        // change UI
        levelPrefabHolder_Load.GetComponent<RectTransform>().sizeDelta =
            new Vector2(
                0,
                100 * (index + 1) + 50
                ); 
    }
    public void LoadLevel()
    {
        if (currentLevelPrefab_LoadUI == null)
            return;

        string levelName = currentLevelPrefab_LoadUI.GetComponent<LevelData_Load>().levelName;
        switch (LevelModeToLoad)
        {
            case LevelType.LinearGame_SameMatch_Basic:
                targetData_LGSMB = SaveLoadManager.Load<LinearGame_SameMatch_Basic_Data>(levelName, encoding, LevelModeToLoad);
                break;

            case LevelType.LinearGame_SameMatch_Intermediate:
                targetData_LGSMI = SaveLoadManager.Load<LinearGame_SameMatch_Intermediate_Data>(levelName, encoding, LevelModeToLoad);
                break;

            case LevelType.LinearGame_SameMatch_Advanced:
                targetData_LGSMA = SaveLoadManager.Load<LinearGame_SameMatch_Advanced_Data>(levelName, encoding, LevelModeToLoad);
                break;


            case LevelType.LinearGame_DifferentMatch_Basic:
                targetData_LGDMB = SaveLoadManager.Load<LinearGame_DifferentMatch_Basic_Data>(levelName, encoding, LevelModeToLoad);
                break;

            case LevelType.LinearGame_DifferentMatch_Intermediate:
                targetData_LGDMI = SaveLoadManager.Load<LinearGame_DifferentMatch_Intermediate_Data>(levelName, encoding, LevelModeToLoad);
                break;

            case LevelType.LinearGame_DifferentMatch_Advanced:
                targetData_LGDMA = SaveLoadManager.Load<LinearGame_DifferentMatch_Advanced_Data>(levelName, encoding, LevelModeToLoad);
                break;


            case LevelType.LinearGame_Perception_Basic:
                targetData_LGPB = SaveLoadManager.Load<LinearGame_Perception_Basic_Data>(levelName, encoding, LevelModeToLoad);
                break;

            case LevelType.LinearGame_Perception_Intermediate:
                targetData_LGPI = SaveLoadManager.Load<LinearGame_Perception_Intermediate_Data>(levelName, encoding, LevelModeToLoad);
                break;

            case LevelType.LinearGame_Perception_Advanced:
                targetData_LGPA = SaveLoadManager.Load<LinearGame_Perception_Advanced_Data>(levelName, encoding, LevelModeToLoad);
                break;


            case LevelType.LinearGame_Expression_Basic:
                targetData_LGEB = SaveLoadManager.Load<LinearGame_Expression_Basic_Data>(levelName, encoding, LevelModeToLoad);
                break;

            case LevelType.LinearGame_Expression_Intermediate:
                targetData_LGEI = SaveLoadManager.Load<LinearGame_Expression_Intermediate_Data>(levelName, encoding, LevelModeToLoad);
                break;

            case LevelType.LinearGame_Expression_Advanced:
                targetData_LGEA = SaveLoadManager.Load<LinearGame_Expression_Advanced_Data>(levelName, encoding, LevelModeToLoad);
                break;
        }
    }

    // Rename Level
    public void RenameLevel_RenameButton()
    {
        if (currentLevelPrefab_LoadUI != null)
        {
            RenameLevel_Popup.SetActive(true);
            renameField.text = null;
        }
    }
    public void RenameLevel_RenameInput()
    {
        // whether new name conflict
        bool isConflict = false;

        string originName;
        string destName;

        destName = renameField.text;

        for(int i = 0; i < levelPrefab_LoadUI_List.Count; i++)
        {
            if (destName == levelPrefab_LoadUI_List[i].GetComponent<LevelData_Load>().levelName)
            {
                isConflict = true;
                break;
            }
        }

        if(isConflict == false)
        {
            originName = currentLevelPrefab_LoadUI.GetComponent<LevelData_Load>().levelName;
            currentLevelPrefab_LoadUI.GetComponent<LevelData_Load>().levelName = renameField.text;

            // change UI
            currentLevelPrefab_LoadUI.transform.GetChild(0).GetComponent<Text>().text = renameField.text;
            SaveLoadManager.Rename(originName, destName, LevelModeToLoad);
            SuccessfullyRename_Popup.SetActive(true);
        }
        else
        {
            NamingConflicts_Popup.SetActive(true);
        }
    }
    public void Deactive_RenameLevelPopup()
    {
        RenameLevel_Popup.SetActive(false);
    }
    public void Deactive_NamingConflictsPopup()
    {
        NamingConflicts_Popup.SetActive(false);
    }
    public void Deactive_SuccessfullyRenamePopup()
    {
        RenameLevel_Popup.SetActive(false);
        SuccessfullyRename_Popup.SetActive(false);
    }
    #endregion



    #region Create Custom Level 
    // which style to change the custom level
    public void AddSubLevel()
    {
        AddNewTemplate_ChangeUI();
    }
    public void DeleteSubLevel()
    {
        DeleteOneTemplate_ChangeUI();
    }
    public void OnCurrentCustomLevelChanged()
    {
        ChangeCustomGameMode_ChangeUI();
    }
    public void SaveCustomLevel()
    {
        SaveCustomLevel_ChangeData();
        SaveCustomLevel_ChangeUI();
    }

	#region change data when creating custom level
    public void ChangeCustomGameMode_ChangeData()
    {
        switch (dropDown_gameMode_Create.value)
        {
            //  LinearGame_SameMatch_Basic  0
            case 0:
                LevelModeToCreate = LevelType.LinearGame_SameMatch_Basic;
                break;

            // LinearGame_SameMatch_Intermediate    1
            case 1:
                LevelModeToCreate = LevelType.LinearGame_SameMatch_Intermediate;
                break;

            // LinearGame_SameMatch_Advanced    2
            case 2:
                LevelModeToCreate = LevelType.LinearGame_SameMatch_Advanced;
                break;

            // LinearGame_DifferentMatch_Basic  3
            case 3:
                LevelModeToCreate = LevelType.LinearGame_DifferentMatch_Basic;
                break;

            // LinearGame_DifferentMatch_Intermediate   4
            case 4:
                LevelModeToCreate = LevelType.LinearGame_DifferentMatch_Intermediate;
                break;

            // LinearGame_DifferentMatch_Advanced   5
            case 5:
                LevelModeToCreate = LevelType.LinearGame_DifferentMatch_Advanced;
                break;

            // LinearGame_Perception_Basic  6
            case 6:
                LevelModeToCreate = LevelType.LinearGame_Perception_Basic;
                break;

            // LinearGame_Perception_Intermediate   7
            case 7:
                LevelModeToCreate = LevelType.LinearGame_Perception_Intermediate;
                break;

            // LinearGame_Perception_Advanced   8
            case 8:
                LevelModeToCreate = LevelType.LinearGame_Perception_Advanced;
                break;

            // LinearGame_Expression_Basic  9
            case 9:
                LevelModeToCreate = LevelType.LinearGame_Expression_Basic;
                break;

            // LinearGame_Expression_Intermediate   10
            case 10:
                LevelModeToCreate = LevelType.LinearGame_Expression_Intermediate;
                break;

            // LinearGame_Expression_Advanced   11
            case 11:
                LevelModeToCreate = LevelType.LinearGame_Expression_Advanced;
                break;
        }
    }
    public void SaveCustomLevel_ChangeData()
    {
        switch (LevelModeToCreate)
        {
            case LevelType.LinearGame_SameMatch_Basic:
                targetData_LGSMB.levelDatas.Clear();
                for (int i = 0; i < SubLevelTemplateList_UI.Count; i++)
                {
                    targetData_LGSMB.levelDatas.Add(
                        new LGSM_Basic_Data(
                                SubLevelTemplateList_UI[i].transform.GetChild(0).GetComponent<ImageInfo_Template>().imageNumber,
                                SubLevelTemplateList_UI[i].transform.GetChild(1).GetComponent<ImageInfo_Template>().imageNumber,
                                SubLevelTemplateList_UI[i].transform.GetChild(3).GetComponent<ImageInfo_Template>().imageNumber,
                                SubLevelTemplateList_UI[i].transform.GetChild(4).GetComponent<ImageInfo_Template>().imageNumber,

                                SubLevelTemplateList_UI[i].transform.GetChild(0).GetComponent<ImageInfo_Template>().imageName,
                                SubLevelTemplateList_UI[i].transform.GetChild(1).GetComponent<ImageInfo_Template>().imageName,
                                SubLevelTemplateList_UI[i].transform.GetChild(3).GetComponent<ImageInfo_Template>().imageName,
                                SubLevelTemplateList_UI[i].transform.GetChild(4).GetComponent<ImageInfo_Template>().imageName
                            )
                        );
                }
                break;

            case LevelType.LinearGame_SameMatch_Intermediate:
                targetData_LGSMI.levelDatas.Clear();
                for (int i = 0; i < SubLevelTemplateList_UI.Count; i++)
                {
                    targetData_LGSMI.levelDatas.Add(
                        new LGSM_Intermediate_Data(
                                SubLevelTemplateList_UI[i].transform.GetChild(0).GetComponent<ImageInfo_Template>().imageNumber,
                                SubLevelTemplateList_UI[i].transform.GetChild(1).GetComponent<ImageInfo_Template>().imageNumber,
                                SubLevelTemplateList_UI[i].transform.GetChild(3).GetComponent<ImageInfo_Template>().imageNumber,
                                SubLevelTemplateList_UI[i].transform.GetChild(4).GetComponent<ImageInfo_Template>().imageNumber,
                                SubLevelTemplateList_UI[i].transform.GetChild(6).GetComponent<ImageInfo_Template>().imageNumber,
                                SubLevelTemplateList_UI[i].transform.GetChild(7).GetComponent<ImageInfo_Template>().imageNumber,

                                SubLevelTemplateList_UI[i].transform.GetChild(0).GetComponent<ImageInfo_Template>().imageName,
                                SubLevelTemplateList_UI[i].transform.GetChild(1).GetComponent<ImageInfo_Template>().imageName,
                                SubLevelTemplateList_UI[i].transform.GetChild(3).GetComponent<ImageInfo_Template>().imageName,
                                SubLevelTemplateList_UI[i].transform.GetChild(4).GetComponent<ImageInfo_Template>().imageName,
                                SubLevelTemplateList_UI[i].transform.GetChild(6).GetComponent<ImageInfo_Template>().imageName,
                                SubLevelTemplateList_UI[i].transform.GetChild(7).GetComponent<ImageInfo_Template>().imageName
                            )
                        );
                }
                break;

            case LevelType.LinearGame_SameMatch_Advanced:
                targetData_LGSMA.levelDatas.Clear();
                break;

            case LevelType.LinearGame_DifferentMatch_Basic:
                targetData_LGDMB.levelDatas.Clear();
                break;

            case LevelType.LinearGame_DifferentMatch_Intermediate:
                targetData_LGDMI.levelDatas.Clear();
                break;

            case LevelType.LinearGame_DifferentMatch_Advanced:
                targetData_LGDMA.levelDatas.Clear();
                break;

            case LevelType.LinearGame_Perception_Basic:
                targetData_LGPB.levelDatas.Clear();
                break;

            case LevelType.LinearGame_Perception_Intermediate:
                targetData_LGPI.levelDatas.Clear();
                break;

            case LevelType.LinearGame_Perception_Advanced:
                targetData_LGPA.levelDatas.Clear();
                break;

            case LevelType.LinearGame_Expression_Basic:
                targetData_LGEB.levelDatas.Clear();
                break;

            case LevelType.LinearGame_Expression_Intermediate:
                targetData_LGEI.levelDatas.Clear();
                break;

            case LevelType.LinearGame_Expression_Advanced:
                targetData_LGEA.levelDatas.Clear();
                break;
        }
    }
    #endregion

    #region change UI when creating custom level
    public void AddNewTemplate_ChangeUI()
    {
        Vector2 prevSubLevelPosition = new Vector2();

        //
        currentTemplateWidth = currentTemplate.GetComponent<RectTransform>().sizeDelta.x;
        currentTemplateHeight = currentTemplate.GetComponent<RectTransform>().sizeDelta.y;
        //

        // change OneLevelContent_UI
        SubLevelTemplateList_UI.Add(Instantiate(currentTemplate));
        SubLevelTemplateList_UI[SubLevelTemplateList_UI.Count - 1].transform.SetParent(LevelListHolder.transform, false);
        if (SubLevelTemplateList_UI.Count == 1)
        {
            SubLevelTemplateList_UI[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -1 * (30f + currentTemplateHeight / 2));
        }
        else
        {
            prevSubLevelPosition = SubLevelTemplateList_UI[SubLevelTemplateList_UI.Count - 2].GetComponent<RectTransform>().anchoredPosition;
            SubLevelTemplateList_UI[SubLevelTemplateList_UI.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(
                prevSubLevelPosition.x, 
                prevSubLevelPosition.y + (30 + currentTemplateHeight) * -1
                );
        }

        // change Plus SubGame Button UI
        AddLevelDataUI.GetComponent<RectTransform>().anchoredPosition = new Vector2
            ( 
                -90,
                SubLevelTemplateList_UI[SubLevelTemplateList_UI.Count - 1].GetComponent<RectTransform>().anchoredPosition.y + (currentTemplateHeight / 2 + 30 + 60) * -1
                );

        // change Subtract SubGame Button
        SubtractLevelDataUI.GetComponent<RectTransform>().anchoredPosition = new Vector2
           (
                90,
                SubLevelTemplateList_UI[SubLevelTemplateList_UI.Count - 1].GetComponent<RectTransform>().anchoredPosition.y + (currentTemplateHeight / 2 + 30 + 60) * -1
                );

        // the half height of AddLevelDataUI is 60
        //
        // 60
        LevelListHolder.GetComponent<RectTransform>().sizeDelta = new Vector2
            (
                0,
                AddLevelDataUI.GetComponent<RectTransform>().anchoredPosition.y * -1 + 60 + interval
                );
    }
    public void DeleteOneTemplate_ChangeUI()
    {
        //
        currentTemplateWidth = currentTemplate.GetComponent<RectTransform>().sizeDelta.x;
        currentTemplateHeight = currentTemplate.GetComponent<RectTransform>().sizeDelta.y;
        //

        if(SubLevelTemplateList_UI.Count == 0)
        {
            return;
        }
        else if(SubLevelTemplateList_UI.Count == 1)
        {
            Destroy(SubLevelTemplateList_UI[0]);
            SubLevelTemplateList_UI.Clear();

            AddLevelDataUI.GetComponent<RectTransform>().anchoredPosition = new Vector2
            (
                -90,
                (60 + interval) * -1
                );

            SubtractLevelDataUI.GetComponent<RectTransform>().anchoredPosition = new Vector2
            (
                90,
                (60 + interval) * -1
                );
        }
        else
        {
            Destroy(SubLevelTemplateList_UI[SubLevelTemplateList_UI.Count - 1]);
            SubLevelTemplateList_UI.RemoveAt(SubLevelTemplateList_UI.Count - 1);

            AddLevelDataUI.GetComponent<RectTransform>().anchoredPosition = new Vector2
            (
                -90,
                SubLevelTemplateList_UI[SubLevelTemplateList_UI.Count - 1].GetComponent<RectTransform>().anchoredPosition.y + (currentTemplateHeight / 2 + 30 + 60) * -1
                );

            SubtractLevelDataUI.GetComponent<RectTransform>().anchoredPosition = new Vector2
            (
                90,
                SubLevelTemplateList_UI[SubLevelTemplateList_UI.Count - 1].GetComponent<RectTransform>().anchoredPosition.y + (currentTemplateHeight / 2 + 30 + 60) * -1
                );
        }

        LevelListHolder.GetComponent<RectTransform>().sizeDelta = new Vector2
            (
                0,
                AddLevelDataUI.GetComponent<RectTransform>().anchoredPosition.y * -1 + 60 + interval
                );
    }
    public void ChangeCustomGameMode_ChangeUI()
    {
        switch (dropDown_gameMode_Create.value)
        {
            //  LinearGame_SameMatch_Basic  0
            case 0:
                currentTemplate = LGSM_Basic_Creator_Template;
                break;

            // LinearGame_SameMatch_Intermediate    1
            case 1:
                currentTemplate = LGSM_Intermediate_Creator_Template;
                break;

            // LinearGame_SameMatch_Advanced    2
            case 2:
                currentTemplate = LGSM_Advanced_Creator_Template;
                break;

            // LinearGame_DifferentMatch_Basic  3
            case 3:
                currentTemplate = LGDM_Basic_Creator_Template;
                break;

            // LinearGame_DifferentMatch_Intermediate   4
            case 4:
                currentTemplate = LGDM_Intermediate_Creator_Template;
                break;

            // LinearGame_DifferentMatch_Advanced   5
            case 5:
                currentTemplate = LGDM_Advanced_Creator_Template;
                break;

            // LinearGame_Perception_Basic  6
            case 6:
                currentTemplate = LGP_Basic_Creator_Template;
                break;

            // LinearGame_Perception_Intermediate   7
            case 7:
                currentTemplate = LGP_Intermediate_Creator_Template;
                break;

            // LinearGame_Perception_Advanced   8
            case 8:
                currentTemplate = LGP_Advanced_Creator_Template;
                break;

            // LinearGame_Expression_Ba sic  9
            case 9:
                currentTemplate = LGE_Basic_Creator_Template;
                break;

            // LinearGame_Expression_Intermediate   10
            case 10:
                currentTemplate = LGE_Intermediate_Creator_Template;
                break;

            // LinearGame_Expression_Advanced   11
            case 11:
                currentTemplate = LGE_Advanced_Creator_Template;
                break;
        }
        RefreshCustomLevel_ChangeUI();
    }
    public void SaveCustomLevel_ChangeUI()
    {
        NameLevel_Popup.SetActive(true);
    }
    public void RefreshCustomLevel_ChangeUI()
    {
        if (SubLevelTemplateList_UI.Count == 0)
            return;

        for (int i = 0; i < SubLevelTemplateList_UI.Count; i++)
            Destroy(SubLevelTemplateList_UI[i]);
        SubLevelTemplateList_UI.Clear();

        AddLevelDataUI.GetComponent<RectTransform>().anchoredPosition = new Vector2
        (
            -90,
            (60 + interval) * -1
            );

        SubtractLevelDataUI.GetComponent<RectTransform>().anchoredPosition = new Vector2
        (
            90,
            (60 + interval) * -1
            );

        LevelListHolder.GetComponent<RectTransform>().sizeDelta = new Vector2
        (
            0,
            AddLevelDataUI.GetComponent<RectTransform>().anchoredPosition.y * -1 + 60 + interval
            );
    }
    #endregion

    public void Deactive_Name_Popup()
    {
        NameLevel_Popup.SetActive(false);
    }
    public void Deactive_Successly_Popup()
    {
        SuccesslyCreateLevel_Popup.SetActive(false);
    }
    #endregion

}

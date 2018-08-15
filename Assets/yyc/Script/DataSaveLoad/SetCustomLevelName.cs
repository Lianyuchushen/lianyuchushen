using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SetCustomLevelName : MonoBehaviour {

    public InputField LevelNameInputField;
    public GameObject SuccessfullyCreateLevel_Popup;
    public GameObject NameLevel_Popup;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GainLevelName);
    }

    public void GainLevelName()
    {
        switch(SaveLoadData.LevelModeToCreate)
        {
            case LevelType.LinearGame_SameMatch_Basic:

                SaveLoadData.targetData_LGSMB.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_SameMatch_Basic_Data>(SaveLoadData.targetData_LGSMB.levelName, SaveLoadData.targetData_LGSMB, LevelType.LinearGame_SameMatch_Basic);

                break;


            case LevelType.LinearGame_SameMatch_Intermediate:

                SaveLoadData.targetData_LGSMI.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_SameMatch_Intermediate_Data>(SaveLoadData.targetData_LGSMI.levelName, SaveLoadData.targetData_LGSMI, LevelType.LinearGame_SameMatch_Intermediate);

                break;


            case LevelType.LinearGame_SameMatch_Advanced:
                SaveLoadData.targetData_LGSMA.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_SameMatch_Advanced_Data>(SaveLoadData.targetData_LGSMA.levelName, SaveLoadData.targetData_LGSMA, LevelType.LinearGame_SameMatch_Advanced);
                break;




            case LevelType.LinearGame_DifferentMatch_Basic:

                SaveLoadData.targetData_LGDMB.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_DifferentMatch_Basic_Data>(SaveLoadData.targetData_LGDMB.levelName, SaveLoadData.targetData_LGDMB, LevelType.LinearGame_DifferentMatch_Basic);

                break;


            case LevelType.LinearGame_DifferentMatch_Intermediate:

                SaveLoadData.targetData_LGDMI.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_DifferentMatch_Intermediate_Data>(SaveLoadData.targetData_LGDMI.levelName, SaveLoadData.targetData_LGDMI, LevelType.LinearGame_DifferentMatch_Intermediate);

                break;


            case LevelType.LinearGame_DifferentMatch_Advanced:

                SaveLoadData.targetData_LGDMA.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_DifferentMatch_Advanced_Data>(SaveLoadData.targetData_LGDMA.levelName, SaveLoadData.targetData_LGDMA, LevelType.LinearGame_DifferentMatch_Advanced);

                break;




            case LevelType.LinearGame_Perception_Basic:

                SaveLoadData.targetData_LGPB.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_Perception_Basic_Data>(SaveLoadData.targetData_LGPB.levelName, SaveLoadData.targetData_LGPB, LevelType.LinearGame_Perception_Basic);

                break;


            case LevelType.LinearGame_Perception_Intermediate:

                SaveLoadData.targetData_LGPI.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_Perception_Intermediate_Data>(SaveLoadData.targetData_LGPI.levelName, SaveLoadData.targetData_LGPI, LevelType.LinearGame_Perception_Intermediate);

                break;


            case LevelType.LinearGame_Perception_Advanced:

                SaveLoadData.targetData_LGPA.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_Perception_Advanced_Data>(SaveLoadData.targetData_LGPA.levelName, SaveLoadData.targetData_LGPA, LevelType.LinearGame_Perception_Advanced);

                break;




            case LevelType.LinearGame_Expression_Basic:

                SaveLoadData.targetData_LGEB.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_Expression_Basic_Data>(SaveLoadData.targetData_LGEB.levelName, SaveLoadData.targetData_LGEB, LevelType.LinearGame_Expression_Basic);

                break;


            case LevelType.LinearGame_Expression_Intermediate:

                SaveLoadData.targetData_LGEI.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_Expression_Intermediate_Data>(SaveLoadData.targetData_LGEI.levelName, SaveLoadData.targetData_LGEI, LevelType.LinearGame_Expression_Intermediate);

                break;


            case LevelType.LinearGame_Expression_Advanced:

                SaveLoadData.targetData_LGEA.levelName = LevelNameInputField.text;

                SaveLoadManager.Save<LinearGame_Expression_Advanced_Data>(SaveLoadData.targetData_LGEA.levelName, SaveLoadData.targetData_LGEA, LevelType.LinearGame_Expression_Advanced);

                break;
        }

        SuccessfullyCreateLevel_Popup.SetActive(true);

        NameLevel_Popup.SetActive(false);
    }
	
}

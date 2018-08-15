using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureLevelTemplate : MonoBehaviour {

    public int num;
    public Button button;

	// Use this for initialization
	void Start () {
        // num = gameObject
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Load);
        num = int.Parse(gameObject.transform.GetChild(0).GetComponent<Text>().text);
    }
	
    void Load()
    {
        AdventureLevelManager.Load_AdventureLevel(num);
    }
    
}

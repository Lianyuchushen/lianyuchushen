using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

#region struct
// every image information in "Custom Image" folder
public struct CustomImageData
{
	public string imageName;    // image name
	public string imagePath;    // image path
	public int imageNumber;     // image number

	public CustomImageData(string name, string path, int number)
	{
		this.imageName = name;
		this.imagePath = path;
		this.imageNumber = number; 
	}
}

// custom image prefab position in Custom Image Manager UI
public struct ImageTemplate_CIM_position	
{
	public int positionX;
	public int positionY;

	public ImageTemplate_CIM_position(int x, int y)
	{
		this.positionX = x;
		this.positionY = y;
	}
}

// custom image prefab position in LG Level Creator UI
public struct ImageTemplate_LGLC_position
{
	public int positionX;
	public int positionY;

	public ImageTemplate_LGLC_position(int x, int y)
	{
		this.positionX = x;
		this.positionY = y;
	}
}
#endregion

public class CustomImageManager : MonoBehaviour 
{
	#region attributes
	public static string CustomImageDirectionary;
	public static DirectoryInfo CustomImageFolder;

	public static List<CustomImageData> CustomImageDataList;
	Texture2D tex = null;
	byte[] imageData;

	// UI control in Custom Image Creator 
	public GameObject ImageTemplateHolder_CIM;
	public GameObject ImageTemplate_CIM;

    // custom image prefab position in Custom Image Manager UI
    public List<ImageTemplate_CIM_position> ImageTemplate_CIM_position_List;  
    
	public List<GameObject> ImageTemplate_CIM_prefab_List;


	// UI control in LG Level Creator UI
	public GameObject ImageTemplateHolder_LGLC;
	public GameObject ImageTemplate_LGLC;

    // custom image prefab position in LG Level Creator UI
    public List<ImageTemplate_LGLC_position> ImageTemplate_LGLC_position_List;

	public List<GameObject> ImageTemplate_LGLC_prefab_List;
	#endregion

	#region Awake() Start() Update()
	void Awake()
	{
		CustomImageDirectionary = Application.persistentDataPath + "/Custom Image";
		CustomImageFolder = new DirectoryInfo (CustomImageDirectionary);
        if (!CustomImageFolder.Exists)
            Directory.CreateDirectory(CustomImageDirectionary);

		CustomImageDataList = new List<CustomImageData> ();
		ImageTemplate_CIM_position_List = new List<ImageTemplate_CIM_position> ();
		ImageTemplate_LGLC_position_List = new List<ImageTemplate_LGLC_position> ();
	}

	void Start()
	{
        // travel all custom image in custom image folder
        TravelCustomImageFolder();

        if (CustomImageDataList.Count != 0)
        {
            SetImageData_InCustomImageManager();
            ShowImage_InCustomImageManager();
            ArrangeImage_InCustomImageManager();

            SetImageData_InLGLevelCreator();
            ShowImage_InLGLevelCreator();
            ArrangeImage_InLGLevelCreator();
        }
    }

	void Update()
	{
        if (CustomImageDataList.Count != 0)
        {
            if (ImageTemplateHolder_CIM.activeInHierarchy)
            {
                ArrangeImage_InCustomImageManager();
            }
            if (ImageTemplateHolder_LGLC.activeInHierarchy)
            {
                ArrangeImage_InLGLevelCreator();
            }
        }
	}
    #endregion

    // travel all custom image in custom image folder
    public void TravelCustomImageFolder()
	{
        if(ImageTemplate_CIM_prefab_List.Count != 0 || ImageTemplate_LGLC_prefab_List.Count != 0)
        {
            for(int i = 0; i < ImageTemplate_CIM_prefab_List.Count; i++)
            {
                Destroy(ImageTemplate_CIM_prefab_List[i]);
                Destroy(ImageTemplate_LGLC_prefab_List[i]);
            }
        }

		CustomImageDataList.Clear ();
		foreach(FileInfo image in CustomImageFolder.GetFiles())
		{
			CustomImageDataList.Add (new CustomImageData (image.Name, image.FullName, CustomImageDataList.Count + 1));
		}
	}

    #region Control in Custom Image Manager
    // set all image prefab and image prefab text in CustomImageManager
    public void SetImageData_InCustomImageManager()
	{
		ImageTemplate_CIM_prefab_List.Clear ();
		ImageTemplate_CIM_position_List.Clear ();
		for(int i = 0; i < CustomImageDataList.Count; i++)
		{
			ImageTemplate_CIM_prefab_List.Add(Instantiate (ImageTemplate_CIM));
		}

		for(int i = 0; i < CustomImageDataList.Count; i++)
		{
			ImageTemplate_CIM_prefab_List [i].transform.SetParent (ImageTemplateHolder_CIM.transform, false);
			ImageTemplate_CIM_prefab_List [i].transform.GetChild (1).GetComponent<Text> ().text = CustomImageDataList[i].imageNumber.ToString();
			ImageTemplate_CIM_prefab_List [i].transform.GetChild (2).GetComponent<Text> ().text = CustomImageDataList [i].imageName;
		}
	}

    // assign all sprite to their custom image template in CustomImageManager 
    public void ShowImage_InCustomImageManager()
	{
		for(int i = 0; i < CustomImageDataList.Count; i++)
		{
			imageData = File.ReadAllBytes (CustomImageDataList [i].imagePath);
			tex = new Texture2D (2, 2);
			tex.LoadImage (imageData);
			ImageTemplate_CIM_prefab_List[i].transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
		}
	}

    // set all custom image template position in CustomImageManager
    public void ArrangeImage_InCustomImageManager()
	{
		// -1 Left   and   1 Right
		int leftOrRight = -1;	
		int row = 0;

		for(int i = 0; i < CustomImageDataList.Count; i++)
		{
			row = i / 2;
			ImageTemplate_CIM_position_List.Add (new ImageTemplate_CIM_position (150 * leftOrRight, (row * 400 + 200) * -1));
			leftOrRight = leftOrRight * -1;
			ImageTemplate_CIM_prefab_List [i].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (ImageTemplate_CIM_position_List [i].positionX, ImageTemplate_CIM_position_List [i].positionY);
		}
		ImageTemplateHolder_CIM.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, ImageTemplate_CIM_position_List [ImageTemplate_CIM_position_List.Count - 1].positionY * -1 + 200);
	}
    #endregion

    #region Control in LG Level Creator
    // set all image prefab and image prefab text in LGLevelCreator
    public void SetImageData_InLGLevelCreator()
	{
		ImageTemplate_LGLC_prefab_List.Clear ();
		ImageTemplate_LGLC_position_List.Clear ();
		for(int i = 0; i < CustomImageDataList.Count; i++)
		{
			ImageTemplate_LGLC_prefab_List.Add(Instantiate (ImageTemplate_LGLC));
		}

		for(int i = 0; i < CustomImageDataList.Count; i++)
		{
			ImageTemplate_LGLC_prefab_List [i].transform.SetParent (ImageTemplateHolder_LGLC.transform, false);
			ImageTemplate_LGLC_prefab_List [i].transform.GetChild (0).GetComponent<Text> ().text = CustomImageDataList[i].imageNumber.ToString();
			ImageTemplate_LGLC_prefab_List [i].transform.GetChild (1).GetComponent<Text> ().text = CustomImageDataList [i].imageName;
		}
	}

    // assign all sprite to their custom image template in LGLevelCreator 
    public void ShowImage_InLGLevelCreator()
	{
		for(int i = 0; i < CustomImageDataList.Count; i++)
		{
			ImageTemplate_LGLC_prefab_List [i].transform.GetChild (2).GetComponent<Image> ().sprite = ImageTemplate_CIM_prefab_List [i].transform.GetChild (0).GetComponent<Image> ().sprite;
		}
	}

    // set all custom image template position in LGLevelCreator
    public void ArrangeImage_InLGLevelCreator()
	{
		for(int i = 0; i < CustomImageDataList.Count; i++)
		{
			ImageTemplate_LGLC_position_List.Add (new ImageTemplate_LGLC_position (0, -120 + -220 * i));
			ImageTemplate_LGLC_prefab_List [i].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, ImageTemplate_LGLC_position_List [i].positionY);
		}
		ImageTemplateHolder_LGLC.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, ImageTemplate_LGLC_position_List [ImageTemplate_LGLC_position_List.Count - 1].positionY * -1 + 130);
	}
	#endregion
}
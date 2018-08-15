using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************* 相同素材配对 *******************************/
[Serializable]
public class LinearGame_SameMatch_Basic_Data
{
    public string levelName;
    public List<LGSM_Basic_Data> levelDatas = new List<LGSM_Basic_Data>();
}
[Serializable]
public struct LGSM_Basic_Data
{
		public int pic1num;
        public int pic2num;
        public int pic3num;
        public int pic4num;

		public string pic1name;
        public string pic2name;
        public string pic3name;
        public string pic4name;

        public LGSM_Basic_Data(int pic1num, int pic2num, int pic3num, int pic4num, string pic1name, string pic2name, string pic3name, string pic4name)
        {
            this.pic1num = pic1num;
            this.pic2num = pic2num;
            this.pic3num = pic3num;
            this.pic4num = pic4num;
            this.pic1name = pic1name;
            this.pic2name = pic2name;
            this.pic3name = pic3name;
            this.pic4name = pic4name;
        }
}


[Serializable]
public class LinearGame_SameMatch_Intermediate_Data
{
    public string levelName;
    public List<LGSM_Intermediate_Data> levelDatas = new List<LGSM_Intermediate_Data>();
}
[Serializable]
public struct LGSM_Intermediate_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;
    public int pic5num;
    public int pic6num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;
    public string pic5name;
    public string pic6name;

    public LGSM_Intermediate_Data(int pic1num, int pic2num, int pic3num, int pic4num, int pic5num, int pic6num, string pic1name, string pic2name, string pic3name, string pic4name, string pic5name, string pic6name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic5num = pic5num;
        this.pic6num = pic6num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
        this.pic5name = pic5name;
        this.pic6name = pic6name;
    }
}


[Serializable]
public class LinearGame_SameMatch_Advanced_Data
{
    public string levelName;
    public List<LGSM_Advanced_Data> levelDatas = new List<LGSM_Advanced_Data>();
}
[Serializable]
public struct LGSM_Advanced_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;
    public int pic5num;
    public int pic6num;
    public int pic7num;
    public int pic8num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;
    public string pic5name;
    public string pic6name;
    public string pic7name;
    public string pic8name;

    public LGSM_Advanced_Data(int pic1num, int pic2num, int pic3num, int pic4num, int pic5num, int pic6num, int pic7num, int pic8num, string pic1name, string pic2name, string pic3name, string pic4name, string pic5name, string pic6name, string pic7name, string pic8name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic5num = pic5num;
        this.pic6num = pic6num;
        this.pic7num = pic7num;
        this.pic8num = pic8num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
        this.pic5name = pic5name;
        this.pic6name = pic6name;
        this.pic7name = pic7name;
        this.pic8name = pic8name;
    }
}
/****************************************************/



/******************************* 不同素材配对 *******************************/
[Serializable]
public class LinearGame_DifferentMatch_Basic_Data
{
    public string levelName;
    public List<LGDM_Basic_Data> levelDatas = new List<LGDM_Basic_Data>();
}
[Serializable]
public struct LGDM_Basic_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;

    public LGDM_Basic_Data(int pic1num, int pic2num, int pic3num, int pic4num, string pic1name, string pic2name, string pic3name, string pic4name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
    }
}


[Serializable]
public class LinearGame_DifferentMatch_Intermediate_Data
{
    public string levelName;
    public List<LGDM_Intermediate_Data> levelDatas = new List<LGDM_Intermediate_Data>();
}
[Serializable]
public struct LGDM_Intermediate_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;
    public int pic5num;
    public int pic6num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;
    public string pic5name;
    public string pic6name;

    public LGDM_Intermediate_Data(int pic1num, int pic2num, int pic3num, int pic4num, int pic5num, int pic6num, string pic1name, string pic2name, string pic3name, string pic4name, string pic5name, string pic6name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic5num = pic5num;
        this.pic6num = pic6num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
        this.pic5name = pic5name;
        this.pic6name = pic6name;
    }
}


[Serializable]
public class LinearGame_DifferentMatch_Advanced_Data
{
    public string levelName;
    public List<LGDM_Advanced_Data> levelDatas = new List<LGDM_Advanced_Data>();
}
[Serializable]
public struct LGDM_Advanced_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;
    public int pic5num;
    public int pic6num;
    public int pic7num;
    public int pic8num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;
    public string pic5name;
    public string pic6name;
    public string pic7name;
    public string pic8name;

    public LGDM_Advanced_Data(int pic1num, int pic2num, int pic3num, int pic4num, int pic5num, int pic6num, int pic7num, int pic8num, string pic1name, string pic2name, string pic3name, string pic4name, string pic5name, string pic6name, string pic7name, string pic8name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic5num = pic5num;
        this.pic6num = pic6num;
        this.pic7num = pic7num;
        this.pic8num = pic8num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
        this.pic5name = pic5name;
        this.pic6name = pic6name;
        this.pic7name = pic7name;
        this.pic8name = pic8name;
    }
}
/****************************************************/



/******************************* 理解训练 *******************************/
[Serializable]
public class LinearGame_Perception_Basic_Data
{
    public string levelName;
    public List<LGP_Basic_Data> levelDatas = new List<LGP_Basic_Data>();
}
[Serializable]
public struct LGP_Basic_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;

    public LGP_Basic_Data(int pic1num, int pic2num, int pic3num, int pic4num, string pic1name, string pic2name, string pic3name, string pic4name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
    }
}


[Serializable]
public class LinearGame_Perception_Intermediate_Data
{
    public string levelName;
    public List<LGP_Intermediate_Data> levelDatas = new List<LGP_Intermediate_Data>();
}
[Serializable]
public struct LGP_Intermediate_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;

    public LGP_Intermediate_Data(int pic1num, int pic2num, int pic3num, int pic4num, string pic1name, string pic2name, string pic3name, string pic4name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
    }
}


[Serializable]
public class LinearGame_Perception_Advanced_Data
{
    public string levelName;
    public List<LGP_Advanced_Data> levelDatas = new List<LGP_Advanced_Data>();
}
[Serializable]
public struct LGP_Advanced_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;

    public LGP_Advanced_Data(int pic1num, int pic2num, int pic3num, int pic4num, string pic1name, string pic2name, string pic3name, string pic4name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
    }
}
/****************************************************/

/******************************* 表达训练 *******************************/
[Serializable]
public class LinearGame_Expression_Basic_Data
{
    public string levelName;
    public List<LGE_Basic_Data> levelDatas = new List<LGE_Basic_Data>();
}
[Serializable]
public struct LGE_Basic_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;

    public LGE_Basic_Data(int pic1num, int pic2num, int pic3num, int pic4num, string pic1name, string pic2name, string pic3name, string pic4name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
    }
}


[Serializable]
public class LinearGame_Expression_Intermediate_Data
{
    public string levelName;
    public List<LGE_Intermediate_Data> levelDatas = new List<LGE_Intermediate_Data>();
}
[Serializable]
public struct LGE_Intermediate_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;

    public LGE_Intermediate_Data(int pic1num, int pic2num, int pic3num, int pic4num, string pic1name, string pic2name, string pic3name, string pic4name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
    }
}


[Serializable]
public class LinearGame_Expression_Advanced_Data
{
    public string levelName;
    public List<LGE_Advanced_Data> levelDatas = new List<LGE_Advanced_Data>();
}
[Serializable]
public struct LGE_Advanced_Data
{
    public int pic1num;
    public int pic2num;
    public int pic3num;
    public int pic4num;

    public string pic1name;
    public string pic2name;
    public string pic3name;
    public string pic4name;

    public LGE_Advanced_Data(int pic1num, int pic2num, int pic3num, int pic4num, string pic1name, string pic2name, string pic3name, string pic4name)
    {
        this.pic1num = pic1num;
        this.pic2num = pic2num;
        this.pic3num = pic3num;
        this.pic4num = pic4num;
        this.pic1name = pic1name;
        this.pic2name = pic2name;
        this.pic3name = pic3name;
        this.pic4name = pic4name;
    }
}
/****************************************************/

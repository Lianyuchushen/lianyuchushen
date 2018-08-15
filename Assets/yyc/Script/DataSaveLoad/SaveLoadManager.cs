using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

// unity 数据管理
public static class SaveLoadManager
{
    public static Encoding Encoding = Encoding.UTF8;
    public static bool Encode = false;

    public static void Save<T>(string filename, T obj, LevelType levelTypeToSave)
    {
        string filePath = "";
        string fileDirectory = "";

        fileDirectory = string.Format("{0}/{1}", Application.persistentDataPath, levelTypeToSave);  // eg: C:/Users/GreatOldOne/AppData/LocalLow/yycwhs/yycwhs/LinearGame_SameMatch_Basic
        filePath = string.Format("{0}/{1}/{2}", Application.persistentDataPath, levelTypeToSave, filename); // eg: C:/Users/GreatOldOne/AppData/LocalLow/yycwhs/yycwhs/LinearGame_SameMatch_Basic/firstfile

        // 创建数据文件夹
        if (!Directory.Exists(fileDirectory)) Directory.CreateDirectory(fileDirectory);

        // 将保存内容传到数据文件
        Stream stream = null;
        stream = new MemoryStream();

        // public static class SaveGameJsonSerializer
        SaveGameJsonSerializer.Serialize(obj, stream, Encoding);

        string data = Encoding.GetString(((MemoryStream)stream).ToArray());

        // public static class SaveGameEncoder
        string encoded = SaveGameEncoder.Encode(data);
        //Debug.Log("encoded   " + encoded);
        File.WriteAllText(filePath, encoded, Encoding);

        stream.Dispose();
    }

    public static T Load<T>(string filename, Encoding encoding, LevelType levelTypeToLoad)
    {
        string filePath = "";
        filename = string.Format("{0}/{1}/{2}", Application.persistentDataPath, levelTypeToLoad, filename);

        Stream stream = null;

        string data = "";
        data = File.ReadAllText(filePath, encoding);
        
        string decoded = SaveGameEncoder.Decode(data);
        
        stream = new MemoryStream(encoding.GetBytes(decoded), true);

        T result = SaveGameJsonSerializer.Deserialize<T>(stream, encoding);
        stream.Dispose();
        return result;
    }
    
    public static void Delete(string fileName, string fileDir)
    {
        string filePath = string.Format("{0}/{1}", fileDir, fileName);
        File.Delete(filePath);
    }

    public static void Rename(string originName, string destName, LevelType levelTypeToLoad)
    {
        string originFile = string.Format("{0}/{1}/{2}", Application.persistentDataPath, levelTypeToLoad, originName);
        string destFile = string.Format("{0}/{1}/{2}", Application.persistentDataPath, levelTypeToLoad, destName);

        System.IO.File.Move(originFile, destFile);
    }
}

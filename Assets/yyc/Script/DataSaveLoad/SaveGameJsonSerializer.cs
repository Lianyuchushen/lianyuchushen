using System.IO;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGameJsonSerializer {

    public static void Serialize<T> (T obj, Stream stream, Encoding encoding)
	{
		StreamWriter writer = new StreamWriter (stream, encoding);
		writer.Write (JsonUtility.ToJson (obj));
		writer.Dispose ();
	}

	public static T Deserialize<T> (Stream stream, Encoding encoding)
	{
		T result = default(T);
		StreamReader reader = new StreamReader (stream, encoding);
		result = JsonUtility.FromJson<T> (reader.ReadToEnd ());
		reader.Dispose ();
        return result;
	}
}

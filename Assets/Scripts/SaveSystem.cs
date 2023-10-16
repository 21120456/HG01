using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.SocialPlatforms.Impl;

public static class SaveSystem
{
    public static void SavePoint(int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/point.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        int data = score;
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static int LoadPoint()
    {
        string path = Application.persistentDataPath + "/point.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            int data = (int)formatter.Deserialize(stream);

            stream.Close();
            return data;
        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            return 0;
        }
    }
}

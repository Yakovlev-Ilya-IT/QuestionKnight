using UnityEngine;
using System.IO;

public class JsonSaver : ISaver
{
    public void Load(ISaveable obj)
    {
        string json = File.ReadAllText(Path.Combine(Application.persistentDataPath, obj.GetFileName()));

        JsonUtility.FromJsonOverwrite(json, obj.SaveableObject);
    }

    public void Save(ISaveable obj)
    {
        string json = JsonUtility.ToJson(obj.SaveableObject);

        File.WriteAllText(Path.Combine(Application.persistentDataPath, obj.GetFileName()), json);
    }

    public bool IsFileExist(ISaveable obj)
    {
        return File.Exists(Path.Combine(Application.persistentDataPath, obj.GetFileName()));
    }
}

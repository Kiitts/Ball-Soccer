using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public int levelAcquired
    {
        get
        {
            return _levelAcquired;
        }
        set
        {
            if(value > _levelAcquired)
            {
                _levelAcquired = value;
            }
        }
    }

    private int _levelAcquired = 1;
    public static MainManager instance {get; private set;}

    private void Awake() 
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
        LoadLevel();
    }

    [System.Serializable]
    class SavedData
    {
        public int levelAcquired = 1;
    }

    public void SaveLevel(int level)
    {
        levelAcquired = level;
        SavedData data = new SavedData();
        data.levelAcquired = levelAcquired;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public void LoadLevel()
    {
        string path = Application.persistentDataPath + "/save.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            levelAcquired = data.levelAcquired;
        }
    }
}

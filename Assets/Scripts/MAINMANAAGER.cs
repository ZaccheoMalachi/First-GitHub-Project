using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MAINMANAAGER : MonoBehaviour
{
    public static MAINMANAAGER instance;
    public Color color;
    private void Awake()
    {   
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }   
        instance = this;
        DontDestroyOnLoad(gameObject);
        laodcoolor();
    }
    [System.Serializable]                                                                                                                                                           
    class savedata
    {
        public Color color;
    }
    public void savecolor()
    {
        savedata data = new savedata();
        data.color=color;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void laodcoolor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) 
        { 
            string json = File.ReadAllText(path);
            savedata data = JsonUtility.FromJson<savedata> (json);
            color = data.color;
        }
    }
}

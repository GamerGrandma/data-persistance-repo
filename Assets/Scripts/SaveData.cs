using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData
{
    public int highScore;
    public string highScoreName;

    //method to save highscore data.
    public static void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.highScore = HighscoreDate.highScore;
        data.highScoreName = HighscoreDate.highScoreName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    //method to load highscore data.
    public static void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighscoreDate.highScore = data.highScore;
            HighscoreDate.highScoreName = data.highScoreName;
        }
    }
}

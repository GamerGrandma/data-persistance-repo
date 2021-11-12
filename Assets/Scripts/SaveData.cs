using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData
{
    public int highScore, highScore2, highScore3, highScore4, highScore5;
    public string highScoreName, highScoreName2, highScoreName3, highScoreName4, highScoreName5;

    //method to save highscore data.
    public static void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.highScore = HighscoreDate.highScore;
        data.highScoreName = HighscoreDate.highScoreName;
    /*data.highScore2 = highScore2;
    data.highScoreName2 = highScoreName2;
    data.highScore3 = highScore3;
    data.highScoreName3 = highScoreName3;
    data.highScore4 = highScore4;
    data.highScoreName4 = highScoreName4;
    data.highScore5 = highScore5;
    data.highScoreName5 = highScoreName5;*/
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
        //BestScoreText.text = "Best Score : " + HighscoreDate.highScore;
        //NameText.text = "Name :" + highScoreName;
    }
}

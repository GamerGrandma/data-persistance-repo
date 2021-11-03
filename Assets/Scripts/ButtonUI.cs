using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
        using UnityEditor;
#endif

public class ButtonUI : MonoBehaviour
{
    public int highScore;
    public string highScoreName;
    public static string playerName;

    void Start()
    {
        //load highscore data
        SaveData.LoadBestScore();
    }
    //method for button to load game scene.
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //method to get data from name input field.
    public void ReadStringInput(string s)
    {
        playerName = s;
        GetName();
    }
    public void GetName()
    {
        string name = playerName;
        HighscoreDate.playerName = name;
    }
    //method for quit button to close game.
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    //method for reset button to delete all previous highscore data.
    public void ResetHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            File.Delete(path);
        }
        //sets highscore data and name back to 0 and empty.
        HighscoreDate.highScore = 0;
        HighscoreDate.highScoreName = null;
    }
}

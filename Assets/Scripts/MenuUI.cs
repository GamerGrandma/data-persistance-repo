using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuUI : MonoBehaviour
{
    public static MenuUI Instance;
    public static string playerName;

    void Awake()
    {
        //add if this exists so there are no multiple menuUIs
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReadStringInput(string s)
    {
        playerName = s;
        Debug.Log(playerName);
    }
    //add a loadsave method and and method to show bestscore and name. also multiple highscores.
    //add a quit button with quit application.
    //add a reset highscore button??
}

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
}

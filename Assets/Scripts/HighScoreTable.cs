using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    void Awake()
    {
        entryTemplate.gameObject.SetActive(false);
        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry {score = 234, name = "Wendy" },
        };
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
        CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 75f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "th"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }
        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;
        string name = highscoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;
        int score = highscoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
        transformList.Add(entryTransform);
    }
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
    
    void Update()
    {
        
    }
}

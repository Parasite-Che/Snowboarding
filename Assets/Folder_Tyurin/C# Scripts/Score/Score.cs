using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Scr
{
    public int count;
    public string name;
    public GameObject cell;
}

public class Score : MonoBehaviour
{
    public List<Scr> scrs = new List<Scr>();
    public GameObject scoreScreen;
    public Count_of_score countOfScore;
    public int numberScores;
    public void AddScore(int cnt, string nm)
    {
        Scr secondScr = new Scr()
        {
            name = nm,
            count = cnt
        };
    
    
        for (int i = 0; i < numberScores; i++)
        {
            if (scrs[i].count < cnt )
            {
                scrs.RemoveAt(numberScores - 1);
                scrs.Insert(i, secondScr);
                Debug.Log("Score aded");
                break;
            }
        }
    }

    public void UpdateScore()
    {
        for (int i = 0; i < numberScores; i++)
        {
            scrs[i].cell = GameObject.Find("Score " + i.ToString());
            scrs[i].cell.GetComponent<Text>().text = scrs[i].name + " : " + scrs[i].count.ToString();
        }
        Debug.Log("Update complete");
    }

    public void SaveScore()
    {
        for (int i = 0; i < numberScores; i++)
        {
            PlayerPrefs.SetInt("Score: " + i.ToString(), scrs[i].count);
            PlayerPrefs.SetString("Name: " + i.ToString(), scrs[i].name);
        }
        Debug.Log("Save complete");
        
    }

    public void LoadScore()
    {
        for (int i = 0; i < numberScores; i++)
        {
            scrs[i].count = PlayerPrefs.GetInt("Score: " + i.ToString());
            scrs[i].name = PlayerPrefs.GetString("Name: " + i.ToString());
        }
        Debug.Log("Load complete");
    }
}

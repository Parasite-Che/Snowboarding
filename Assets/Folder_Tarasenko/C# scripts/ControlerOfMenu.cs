using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlerOfMenu : MonoBehaviour
{
    public string NameOfPlayer="New player";
    private void Start()
    {
        if (PlayerPrefs.GetString("PlayerName") == null || PlayerPrefs.GetString("PlayerName") == "New player")
        PlayerPrefs.SetString("PlayerName", NameOfPlayer);
    }
    public void PlayPressed()
    {
        if (PlayerPrefs.GetString("PlayerName") == null || PlayerPrefs.GetString("PlayerName") == "")
            PlayerPrefs.SetString("PlayerName", "New player");
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
    public void RenamePressed()
    {
        if(PlayerPrefs.GetString("PlayerName")==null|| PlayerPrefs.GetString("PlayerName") == "")
        PlayerPrefs.SetString("PlayerName", "New player");
    }
}

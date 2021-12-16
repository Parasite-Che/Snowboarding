using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnteringOfName : MonoBehaviour
{
    [SerializeField] private InputField NameField;
    public string NameOfPlayer;
    public void SetName()
    {
        if (NameField.text == "")
        {
            Debug.Log("Error");
        }
        else
        {
            NameOfPlayer = NameField.text;
            PlayerPrefs.SetString("PlayerName", NameOfPlayer);
            NameField.text = "";
            Debug.Log(NameOfPlayer);
        }
    }
}

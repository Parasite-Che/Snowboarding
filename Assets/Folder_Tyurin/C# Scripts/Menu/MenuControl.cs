using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Inv;
    public GameObject DeathScreen;
    public GameObject ShopScreen;
    public GameObject SettingsScreen;
    public GameObject ScoreScreen;
    public Score Score;
    public Inventory2 updateInv;
    public ShopControl shopCntrl;

    public void Start()
    {
        Time.timeScale = 1;
        Score.LoadScore();
    }

    public void Update()
    {
        updateInv = GameObject.Find("InvControl").GetComponent<Inventory2>();
        updateInv.InventoryMainObject = Inv;
    }

    public void Exit()
    {
        updateInv.SaveCoins();
        updateInv.SaveInventory();
        Application.Quit();
    }

    public void Restart()
    {
        updateInv = GameObject.Find("InvControl").GetComponent<Inventory2>();
        updateInv.SaveInventory();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        updateInv.LoadCoins();
    }

    public void ActiveInventory()
    {
        updateInv = GameObject.Find("InvControl").GetComponent<Inventory2>();
        Inventory.SetActive(true);
        DeathScreen.SetActive(false);
        updateInv.SaveInventory();
        updateInv.UpdateInventory();
    }

    public void DeactiveInventory()
    {
        updateInv = GameObject.Find("InvControl").GetComponent<Inventory2>();
        updateInv.SaveInventory();
        Inventory.SetActive(false);
        DeathScreen.SetActive(true);
    }

    public void ActiveShop()
    {
        //GetComponent<UpgradeButtons>().HighlightUpgradeButtons();
        updateInv.SaveInventory();
        DeathScreen.SetActive(false);
        ShopScreen.SetActive(true);
        shopCntrl.ShopUpdate();
    }

    public void DeactiveShop()
    {
        updateInv.SaveInventory();
        ShopScreen.SetActive(false);
        DeathScreen.SetActive(true);
    }

    public void ActiveSettings()
    {
        DeathScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }

    public void DeactiveSettings()
    {
        SettingsScreen.SetActive(false);
        DeathScreen.SetActive(true);
    }

    public void ActiveScore()
    {
        DeathScreen.SetActive(false);
        ScoreScreen.SetActive(true);
        Score.LoadScore();
        Score.UpdateScore();
    }

    public void DeactiveScore()
    {
        ScoreScreen.SetActive(false);
        DeathScreen.SetActive(true);
        //Score.SaveScore();
    }

    public void ResetAllProgress()
    {
        string NameToSave;
        NameToSave = PlayerPrefs.GetString("PlayerName");
        PlayerPrefs.DeleteAll();
        //Destroy(GameObject.Find("InvControl"));
        PlayerPrefs.SetString("PlayerName",NameToSave);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitFromDeathToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

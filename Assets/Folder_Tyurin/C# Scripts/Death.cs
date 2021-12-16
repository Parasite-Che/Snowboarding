using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject player;
    public GameObject DS;
    public AvalancheMove avalancheMovement;
    public bool Die;
    public Inventory2 inv = null;
    public Score Scr;
    public Count_of_score countOfScore;
    public LayerMask groundLayer;
    private bool OTD = false;
    //public int headSaves;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        avalancheMovement = GameObject.FindWithTag("Avalanche").GetComponent<AvalancheMove>();
        Die = false;
        DS.SetActive(false);
    }

    void Update()
    {
        if (inv == null)
        {
            inv = GameObject.Find("InvControl").GetComponent<Inventory2>();
        }

        //if (GameObject.FindWithTag("Head").GetComponent<Collider2D>().IsTouchingLayers(groundLayer.value) && OTD == false)
        //{
        //    if (headSaves == 0)
        //    {
        //        Die = true;
        //        OTD = true;
        //    }
        //    else
        //    {
        //        headSaves--;
        //    }
        //}

        if (Die)
        {
            inv.RemoveCoins((int)(inv.coinsThisRun * player.GetComponent<PlayerUpgrades>().coinSavePercent));
            inv.coinsThisRun = 0;
            inv.SaveCoins();
            inv.SaveInventory();
            avalancheMovement.enabled = false;
            DS.SetActive(true);
            // Добовление и сохранение очков
            Scr.AddScore(countOfScore.ScoreReturn(), PlayerPrefs.GetString("PlayerName"));
            Scr.SaveScore();

            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Time.timeScale = 0;
            Die = false;
        }

    }

}

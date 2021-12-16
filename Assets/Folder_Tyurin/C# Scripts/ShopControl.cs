using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{
    public Upgrade currenntShop;
    public Inventory2 placeOfCoin = null;
    public PlayerUpgrades level;
    public int maxLVL;

    public GameObject helmetButton;
    public GameObject jetpackButton;
    public GameObject jacketButton;
    public GameObject InstrumentsButton;
    public GameObject WeaponsButton;
    public GameObject SteroidsButton;
    public GameObject SnowboardButton;

    public void ShopUpdate()
    {
        if (placeOfCoin == null)
        {
            placeOfCoin = GameObject.Find("InvControl").GetComponent<Inventory2>();
        }
        //                                                Helmet
        if (level.helmetLvl < maxLVL)
        {
            if (currenntShop.upgradeShop.HelmetUpgrades[level.helmetLvl + 1].unlockCost <= placeOfCoin.totalCoin)
            {
                helmetButton.GetComponent<Graphic>().color = new Color32(110, 176, 0, 255);
            }
            else
            {
                helmetButton.GetComponent<Graphic>().color = new Color32(85, 85, 85, 255);
            }
        }
        else
        {
            helmetButton.GetComponent<Graphic>().color = new Color32(0, 85, 0, 255);
        }
        //                                                Jetpack
        if (level.jetpackLvl < maxLVL)
        {
            if (currenntShop.upgradeShop.JetpackUpgrades[level.jetpackLvl + 1].unlockCost <= placeOfCoin.totalCoin)
            {
                jetpackButton.GetComponent<Graphic>().color = new Color32(110, 176, 0, 255);
            }
            else
            {
                jetpackButton.GetComponent<Graphic>().color = new Color32(85, 85, 85, 255);
            }
        }
        else
        {
            jetpackButton.GetComponent<Graphic>().color = new Color32(0, 85, 0, 255);
        }
        //                                                Jacket
        if (level.jacketLvl < maxLVL)
        {
            if (currenntShop.upgradeShop.JacketUpgrades[level.jacketLvl + 1].unlockCost <= placeOfCoin.totalCoin)
            {
                jacketButton.GetComponent<Graphic>().color = new Color32(110, 176, 0, 255);
            }
            else
            {
                jacketButton.GetComponent<Graphic>().color = new Color32(85, 85, 85, 255);
            }
        }
        else
        {
            jacketButton.GetComponent<Graphic>().color = new Color32(0, 85, 0, 255);
        }
        //                                                Instruments
        if (level.instrumentsLvl < maxLVL)
        {
            if (currenntShop.upgradeShop.InstrumentsUpgrades[level.instrumentsLvl + 1].unlockCost <= placeOfCoin.totalCoin)
            {
                InstrumentsButton.GetComponent<Graphic>().color = new Color32(110, 176, 0, 255);
            }
            else
            {
                InstrumentsButton.GetComponent<Graphic>().color = new Color32(85, 85, 85, 255);
            }
        }
        else
        {
            InstrumentsButton.GetComponent<Graphic>().color = new Color32(0, 85, 0, 255);
        }
        //                                                Weapons
        if (level.weaponsLvl < maxLVL)
        {
            if (currenntShop.upgradeShop.WeaponsUpgrades[level.weaponsLvl + 1].unlockCost <= placeOfCoin.totalCoin)
            {
                WeaponsButton.GetComponent<Graphic>().color = new Color32(110, 176, 0, 255);
            }
            else
            {
                WeaponsButton.GetComponent<Graphic>().color = new Color32(85, 85, 85, 255);
            }
        }
        else
        {
            WeaponsButton.GetComponent<Graphic>().color = new Color32(0, 85, 0, 255);
        }
        //                                                Steroids
        if (level.steroidsLvl < maxLVL)
        {
            if (currenntShop.upgradeShop.SteroidsUpgrades[level.steroidsLvl + 1].unlockCost <= placeOfCoin.totalCoin)
            {
                SteroidsButton.GetComponent<Graphic>().color = new Color32(110, 176, 0, 255);
            }
            else
            {
                SteroidsButton.GetComponent<Graphic>().color = new Color32(85, 85, 85, 255);
            }
        }
        else
        {
            SteroidsButton.GetComponent<Graphic>().color = new Color32(0, 85, 0, 255);
        }
        //                                                Snowboard
        if (level.snowboardLvl < maxLVL)
        {
            if (currenntShop.upgradeShop.SnowboardUpgrades[level.snowboardLvl + 1].unlockCost <= placeOfCoin.totalCoin)
            {
                SnowboardButton.GetComponent<Graphic>().color = new Color32(110, 176, 0, 255);
            }
            else
            {
                SnowboardButton.GetComponent<Graphic>().color = new Color32(85, 85, 85, 255);
            }
        }
        else
        {
            SnowboardButton.GetComponent<Graphic>().color = new Color32(0, 85, 0, 255);
        }
    }
}

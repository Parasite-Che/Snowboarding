using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    public Upgrade shop;
    public PlayerUpgrades upgrades;
    public GameObject upgradeButtons;
    private int maxLvl = 3;
    private int bagMaxLvl = 1;
    public Inventory2 inv = null;
    public ShopControl shopCntrl;

    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.Find("UpgradeSystem").GetComponent<Upgrade>();
        upgrades = GameObject.Find("Player").GetComponent<PlayerUpgrades>();
        upgradeButtons = GameObject.Find("UpgradeButtons");
    }

    // Update is called once per frame
    void Update()
    {
        if (inv == null)
        {
            inv = GameObject.Find("InvControl").GetComponent<Inventory2>();
        }
    }

    public void SnowboardUpgrade()
    {
        if ((upgrades.snowboardLvl < maxLvl)
            && inv.totalCoin >= shop.upgradeShop.SnowboardUpgrades[upgrades.snowboardLvl + 1].unlockCost)
        {
            inv.RemoveCoins(shop.upgradeShop.SnowboardUpgrades[upgrades.snowboardLvl + 1].unlockCost);
            upgrades.snowboardLvl++;
            PlayerPrefs.SetInt("snowboardLvl", upgrades.snowboardLvl);
            PlayerPrefs.Save();
            shopCntrl.ShopUpdate();
        }
    }

    public void JetpackUpgrade()
    {
        if ((upgrades.jetpackLvl < maxLvl)
            && inv.totalCoin >= shop.upgradeShop.JetpackUpgrades[upgrades.jetpackLvl + 1].unlockCost)
        {
            inv.RemoveCoins(shop.upgradeShop.JetpackUpgrades[upgrades.jetpackLvl + 1].unlockCost);
            upgrades.jetpackLvl++;
            PlayerPrefs.SetInt("jetpackLvl", upgrades.jetpackLvl);
            PlayerPrefs.Save();
            shopCntrl.ShopUpdate();
        }
    }

    public void JacketUpgrade()
    {
        if ((upgrades.jacketLvl < maxLvl)
            && inv.totalCoin >= shop.upgradeShop.JacketUpgrades[upgrades.jacketLvl + 1].unlockCost)
        {
            inv.RemoveCoins(shop.upgradeShop.JacketUpgrades[upgrades.jacketLvl + 1].unlockCost);
            upgrades.jacketLvl++;
            PlayerPrefs.SetInt("jacketLvl", upgrades.jacketLvl);
            PlayerPrefs.Save();
            shopCntrl.ShopUpdate();
        }
    }

    public void InstrumentsUpgrade()
    {
        if ((upgrades.instrumentsLvl < maxLvl)
            && inv.totalCoin >= shop.upgradeShop.InstrumentsUpgrades[upgrades.instrumentsLvl + 1].unlockCost)
        {
            inv.RemoveCoins(shop.upgradeShop.InstrumentsUpgrades[upgrades.instrumentsLvl + 1].unlockCost);
            upgrades.instrumentsLvl++;
            PlayerPrefs.SetInt("instrumentsLvl", upgrades.instrumentsLvl);
            PlayerPrefs.Save();
            shopCntrl.ShopUpdate();
        }
    }

    public void WeaponsUpgrade()
    {
        if ((upgrades.weaponsLvl < maxLvl)
            && inv.totalCoin >= shop.upgradeShop.WeaponsUpgrades[upgrades.weaponsLvl + 1].unlockCost)
        {
            inv.RemoveCoins(shop.upgradeShop.WeaponsUpgrades[upgrades.weaponsLvl + 1].unlockCost);
            upgrades.weaponsLvl++;
            PlayerPrefs.SetInt("weaponsLvl", upgrades.weaponsLvl);
            PlayerPrefs.Save();
            shopCntrl.ShopUpdate();
        }
        
    }

    public void SteroidsUpgrade()
    {
        if ((upgrades.steroidsLvl < maxLvl)
            && inv.totalCoin >= shop.upgradeShop.SteroidsUpgrades[upgrades.snowboardLvl + 1].unlockCost)
        {
            inv.RemoveCoins(shop.upgradeShop.SteroidsUpgrades[upgrades.steroidsLvl + 1].unlockCost);
            upgrades.steroidsLvl++;
            PlayerPrefs.SetInt("steroidsLvl", upgrades.steroidsLvl);
            PlayerPrefs.Save();
            shopCntrl.ShopUpdate();
        }
        
    }

    public void HelmetUpgrade()
    {
        if ((upgrades.helmetLvl < maxLvl)
            && inv.totalCoin >= shop.upgradeShop.HelmetUpgrades[upgrades.helmetLvl + 1].unlockCost)
        {
            inv.RemoveCoins(shop.upgradeShop.HelmetUpgrades[upgrades.helmetLvl + 1].unlockCost);
            upgrades.helmetLvl++;
            PlayerPrefs.SetInt("helmetLvl", upgrades.helmetLvl);
            PlayerPrefs.Save();
            shopCntrl.ShopUpdate();
        }
        
    }
    public void BagUpgrade()
    {
        if ((upgrades.bagLvl < bagMaxLvl)
            && inv.totalCoin >= shop.upgradeShop.BagUpgrades[upgrades.bagLvl + 1].unlockCost)
        {
            inv.RemoveCoins(shop.upgradeShop.BagUpgrades[upgrades.bagLvl + 1].unlockCost);
            upgrades.bagLvl++;
            PlayerPrefs.SetInt("bagLvl", upgrades.bagLvl);
            PlayerPrefs.Save();
            shopCntrl.ShopUpdate();
        }
    }
}

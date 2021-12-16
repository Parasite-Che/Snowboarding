using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public GameObject upgrades;
    
    public float defaultFriction;

    [Header("Snowboard")]
    public int snowboardLvl;
    public float modifiedFriction;
    public float speedMultiplier;

    [Header("Jetpack")]
    public int jetpackLvl;
    public bool jetpackActive;
    public float forceMultiplier;
    public float fuelMax;
    [SerializeField]
    private GameObject dash;

    [Header("Jacket")]
    public int jacketLvl;
    public float coinSavePercent;

    [Header("Instruments")]
    public int instrumentsLvl;
    public bool smallAnimals;
    public bool bigAnimals;
    public int skinsModifier;

    [Header("Weapons")]
    public int weaponsLvl;
    public int killChance;
    public float bigAnimalImpactModifier;
    public float smallAnimalImpactModifier;

    [Header("Steroids")]
    public int steroidsLvl;
    public float jumpModifier;
    public GameObject jumpLeftButton;
    public GameObject jumpRightButton;

    [Header("Helmet")]
    public int helmetLvl;
    public int saves;
    public GameObject head;


    // Start is called before the first frame update
    void Start()
    {
        GetUpgradeLvls();
        InitializeUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetUpgradeLvls()
    {
        snowboardLvl = PlayerPrefs.GetInt("snowboardLvl", 0);
        jetpackLvl = PlayerPrefs.GetInt("jetpackLvl", 0);   
        jacketLvl = PlayerPrefs.GetInt("jacketLvl", 0);
        instrumentsLvl = PlayerPrefs.GetInt("instrumentsLvl", 0);
        weaponsLvl = PlayerPrefs.GetInt("weaponsLvl", 0);
        steroidsLvl = PlayerPrefs.GetInt("steroidsLvl", 0);
        helmetLvl = PlayerPrefs.GetInt("helmetLvl", 0);
    }

    void InitializeUpgrades()
    {
        SnowboardUpgrades();
        JetpackUpgrades();
        JacketUpgrades();
        InstrumentsUpgrades();
        WeaponsUpgrades();
        SteroidsUpgrades();
        HelmetUpgrades();
    }

    void SnowboardUpgrades()
    {
        modifiedFriction = upgrades.GetComponent<Upgrade>().upgradeShop.SnowboardUpgrades[snowboardLvl].frictionMultiplier * defaultFriction;
        speedMultiplier = upgrades.GetComponent<Upgrade>().upgradeShop.SnowboardUpgrades[snowboardLvl].speedMultiplier;

        GetComponent<CapsuleCollider2D>().sharedMaterial.friction = modifiedFriction;
        GetComponent<Move>().speedModifier = speedMultiplier;
    }

    void JetpackUpgrades()
    {
        fuelMax = upgrades.GetComponent<Upgrade>().upgradeShop.JetpackUpgrades[jetpackLvl].fuelMax;
        forceMultiplier = upgrades.GetComponent<Upgrade>().upgradeShop.JetpackUpgrades[jetpackLvl].forceMultiplier;
        jetpackActive = upgrades.GetComponent<Upgrade>().upgradeShop.JetpackUpgrades[jetpackLvl].jetpackActive;

        dash.SetActive(jetpackActive);
        dash.GetComponent<FuelFill>().SetFuelMax(fuelMax);
        dash.GetComponent<Dash>().fuelMax = fuelMax;
        dash.GetComponent<Dash>().Power *= forceMultiplier;
    }

    void JacketUpgrades()
    {
        coinSavePercent = upgrades.GetComponent<Upgrade>().upgradeShop.JacketUpgrades[jacketLvl].coinSavePercent;
    }

    void InstrumentsUpgrades()
    {
        skinsModifier = upgrades.GetComponent<Upgrade>().upgradeShop.InstrumentsUpgrades[instrumentsLvl].skinsMultiplier;
        smallAnimals = upgrades.GetComponent<Upgrade>().upgradeShop.InstrumentsUpgrades[instrumentsLvl].smallAnimals;
        bigAnimals = upgrades.GetComponent<Upgrade>().upgradeShop.InstrumentsUpgrades[instrumentsLvl].bigAnimals;

    }

    void WeaponsUpgrades()
    {
        killChance = upgrades.GetComponent<Upgrade>().upgradeShop.WeaponsUpgrades[weaponsLvl].chanceToKill;
        smallAnimalImpactModifier = upgrades.GetComponent<Upgrade>().upgradeShop.WeaponsUpgrades[weaponsLvl].smallAnimalImpactModifier;
        bigAnimalImpactModifier = upgrades.GetComponent<Upgrade>().upgradeShop.WeaponsUpgrades[weaponsLvl].bigAnimalImpactModifier;
    }

    void SteroidsUpgrades()
    {
        jumpModifier = upgrades.GetComponent<Upgrade>().upgradeShop.SteroidsUpgrades[steroidsLvl].jumpMultiplier;
        jumpLeftButton.GetComponent<Rotate>().JumpForceModifier = jumpModifier;
        jumpRightButton.GetComponent<Rotate>().JumpForceModifier = jumpModifier;
    }

    void HelmetUpgrades()
    {
        saves = upgrades.GetComponent<Upgrade>().upgradeShop.HelmetUpgrades[helmetLvl].saves;

        head.GetComponent<HeadCollisionCheck>().headSaves = saves;
    }
}

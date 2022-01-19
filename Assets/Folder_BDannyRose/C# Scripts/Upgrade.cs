using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shop
{

    [System.Serializable]
    public class UpgradeShop
    {
        public SnowboardItem[] SnowboardUpgrades;
        public JetpackItem[] JetpackUpgrades;
        public JacketItem[] JacketUpgrades;
        public InstrumentsItem[] InstrumentsUpgrades;
        public WeaponsItem[] WeaponsUpgrades;
        public SteroidsItem[] SteroidsUpgrades;
        public HelmetItem[] HelmetUpgrades;
        public BagItem[] BagUpgrades;
    }

    public class Item
    {
        public string itemName;
        public string description;
        public int unlockCost;
    }

    // level 0 - default
    // level 1 - less friction
    // level 2 - less friction
    // level 3 - bigger max speed
    [System.Serializable]
    public class SnowboardItem : Item
    {
        public float speedMultiplier;
        public float frictionMultiplier;
    }

    // level 0 - nothing
    // level 1 - unlock
    // level 2 - more fuel
    // level 3 - more force
    [System.Serializable]
    public class JetpackItem : Item
    {
        public bool jetpackActive;
        public float forceMultiplier;
        public float fuelMax;
    }

    // level 0 - lose 50% of coins
    // level 1 - lose 40% of coins
    // level 2 - lose 30% of coins
    // level 3 - lose 20% of coins
    [System.Serializable]
    public class JacketItem : Item
    {
        public float coinSavePercent;
    }

    // level 0 - no skins
    // level 1 - skins from small animals
    // level 2 - skins from big animals
    // level 3 - 2x the skins
    [System.Serializable]
    public class InstrumentsItem : Item
    {
        public bool smallAnimals;
        public bool bigAnimals;
        public int skinsMultiplier;
    }

    // level 1 - chance to kill a big animal, lesser impact from small animals
    // level 2 - better chance, lesser impact from big animals
    // level 3 - certain kill chance, lesser impact from big animals
    [System.Serializable]
    public class WeaponsItem : Item
    {
        public int chanceToKill;
        public float bigAnimalImpactModifier;
        public float smallAnimalImpactModifier;
    }

    // level 1 - higher jump
    // level 2 - higher jump
    // level 3 - higher jump
    [System.Serializable]
    public class SteroidsItem : Item
    {
        public float jumpMultiplier;
    }

    // level 1 - character doesn't die on fall (1 time)
    // level 2 - character doesn't die on fall (2 times)
    // level 3 - character doesn't die on fall (4 times)
    [System.Serializable]
    public class HelmetItem : Item
    {
        public int saves;
    }

    // level 0 - no bag
    // level 1 - yes bag (holds 1 bonus)
    [System.Serializable]
    public class BagItem : Item
    {
        
    }
}

public class Upgrade : MonoBehaviour
{
    public Shop.UpgradeShop upgradeShop;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bonus
{
    // Start is called before the first frame update
    [System.Serializable]
    public class BonusInv
    {
        public Shield shield;
        public CommonFuel fuel;
        public NuclearFuel nuclearFuel;
        public Mushroom mushroom;
        public Steroids steroids;
    }

    public class Bonus
    {
        public string bonusName;
        public string description;
        public bool active;
        public float timer;
        virtual public void Activate()
        {
            active = true;
        }
        virtual public void Deactivate()
        {
            active = false;
        }

    }

    [System.Serializable]
    public class Shield : Bonus
    {
        public int uses;
        public override void Activate()
        {
            active = true;
            uses = 3;
        }
        public override void Deactivate()
        {
            ;
        }

        public void ShieldUse()
        {
            uses--;
            if (uses == 0)
            {
                active = false;
            }
        }
    }

    [System.Serializable]
    public class CommonFuel : Bonus
    {
        public float refuelModifier;
    }

    [System.Serializable]
    public class NuclearFuel : Bonus
    {

    }

    [System.Serializable]
    public class Mushroom : Bonus
    {
        public GameObject player;
        public override void Activate()
        {
            active = true;
            player.transform.localScale = new Vector3(player.transform.localScale.x * 2, player.transform.localScale.y * 2);
        }
        public override void Deactivate()
        {
            active = false;
            player.transform.localScale = new Vector3(player.transform.localScale.x / 2, player.transform.localScale.y / 2);
        }
    }

    [System.Serializable]
    public class Steroids : Bonus
    {
        public float bonusJumpForceModifier;
    }

    
}

public class Bonuses : MonoBehaviour
{
    public Bonus.BonusInv bonuses;
    public void ActivateBonus(int ID)
    {
        Bonus.Bonus bonus = RetrieveBonus(ID);
        StartCoroutine(BonusTimer(bonus));
    }
    Bonus.Bonus RetrieveBonus(int ID)
    {
        switch (ID)
        {
            case 0:
                return bonuses.fuel;
            case 1:
                return bonuses.mushroom;
            case 2:
                return bonuses.nuclearFuel;
            case 3:
                return bonuses.shield;
            case 4:
                return bonuses.steroids;
            default:
                return null;
        }
    }
    IEnumerator BonusTimer(Bonus.Bonus bonus)
    {
        bonus.Activate();
        yield return new WaitForSeconds(bonus.timer);
        bonus.Deactivate();
        yield break;
    }
    
}
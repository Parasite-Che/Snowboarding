using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackControl : MonoBehaviour
{
    // 0 = common fuel
    // 1 = mushroom
    // 2 = nuclear fuel
    // 3 = shield
    // 4 = steroids
    private const int NO_ITEM = 5;
    public Bonuses bonus;
    public PlayerUpgrades upgrades;
    public int currentItem;
    public GameObject button;
    public List<Sprite> sprites;
    private void Start()
    {
        UpdateBackpack();
    }

    public void UpdateBackpack()
    {
        button.GetComponent<Image>().sprite = sprites[currentItem];
    }

    public bool StoreBonusItem(int id)
    {
        if (currentItem == NO_ITEM)
        {
            currentItem = id;
            UpdateBackpack();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PressTheButton()
    {
        if (currentItem != NO_ITEM)
        {
            bonus.ActivateBonus(currentItem);
            currentItem = NO_ITEM;
            UpdateBackpack();
        }
    }


}

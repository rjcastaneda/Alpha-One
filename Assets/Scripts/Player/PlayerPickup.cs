using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    PlayerData playerData;
    WeaponInventory playerWepInv;

    private void Start()
    {
        playerData = this.gameObject.GetComponent<PlayerData>();
        playerWepInv = this.gameObject.GetComponent<WeaponInventory>();
    }

    public void PickupItem(Item itemPickup)
    {
        if(itemPickup.type == "Weapon")
        {
            playerWepInv.AddNewWep(itemPickup.itemName);
        }

        if(itemPickup.type == "Upgrade")
        {
            playerData.upgrades.Add(itemPickup);
            if(itemPickup.modAtt == "wShot")
            {
                playerData.wShot = true;
            }

            if(itemPickup.modAtt == "attackSpeed")
            {
                playerData.asMod += itemPickup.modifier;
            }

            if (itemPickup.modAtt == "attackDamage")
            {
                playerData.attackMod += itemPickup.modifier;
            }
        }
    }
}

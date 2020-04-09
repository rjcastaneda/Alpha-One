using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInventory : MonoBehaviour
{
    private PlayerData player;
    private Transform gunTransform;
    public GunObj selectedWeapon;
    

    private void Awake()
    {
        //Initialize variables, and set defaults.
        player = GameObject.Find("Player").GetComponent<PlayerData>();
        gunTransform = GameObject.Find("Gun").GetComponent<Transform>();
        SetCurrentEquip("M9");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SetCurrentEquip("M9"); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SetCurrentEquip("MP5"); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { SetCurrentEquip("AK47"); }
    }

    //Sets the weapon to be used by the player.
    void SetCurrentEquip(string name)
    {
        //Checks to see if player has the weapon in the inventory.
        if(player.weaponInventory.Contains(name) == false) { return; }

        //Iterates through the transform of "Gun" to activate the current weapon.
        GunObj weaponSearched;
        foreach(GameObject gameGuns in gunTransform)
        {
            weaponSearched = gameGuns.GetComponent<GunObj>();
            if(weaponSearched.gunName == name)
            {
                gameGuns.SetActive(true);
                selectedWeapon = weaponSearched;
            }
            else
            {
                gameGuns.SetActive(false);
            }
        }
        return;
    }

    //Function for the weapon pick-up item
    void AddNewGun(string name) { player.weaponInventory.Add(name); }
}

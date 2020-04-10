using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private PlayerData player;
    private Transform wepTransform;
    public WeaponObj selectedWeapon;
    

    private void Awake()
    {
        //Initialize variables, and set defaults.
        player = GameObject.Find("Player").GetComponent<PlayerData>();
        wepTransform = GameObject.Find("Weapons").GetComponent<Transform>();
        AddNewWep("BasicBlaster");
        AddNewWep("ShockBlaster");
        SetCurrentEquip("BasicBlaster");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SetCurrentEquip("BasicBlaster"); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SetCurrentEquip("ShockBlaster"); }
    }

    //Sets the weapon to be used by the player.
    void SetCurrentEquip(string name)
    {
        //Checks to see if player has the weapon in the inventory.
        if(player.weaponInventory.Contains(name) == false) { Debug.Log("No Weapon of that name."); return;  }

        //Iterates through the transform of "Gun" to activate the current weapon.
        WeaponObj weaponSearched;
        foreach(Transform gameWeps in wepTransform)
        {
            weaponSearched = gameWeps.gameObject.GetComponent<WeaponObj>();
            if(weaponSearched.wepName == name)
            {
                gameWeps.gameObject.SetActive(true);
                selectedWeapon = weaponSearched;
                Debug.Log("Weapon Set Successfully");
            }
            else
            {
                gameWeps.gameObject.SetActive(false);
            }
        }
        return;
    }

    //Function for the weapon pick-up item
    void AddNewWep(string name) { player.weaponInventory.Add(name); }
}

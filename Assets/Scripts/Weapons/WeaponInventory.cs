using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private PlayerData _playerData;
    private Transform wepTransform;

    public WeaponObj selectedWeapon;
    

    private void Awake()
    {
        //Initialize variables, and set defaults.
        _playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        wepTransform = GameObject.Find("Weapons").GetComponent<Transform>();
        AddNewWep("Basic Blaster");
        SetCurrentEquip("Basic Blaster");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SetCurrentEquip("Basic Blaster"); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SetCurrentEquip("Shock Blaster"); }
    }

    //Sets the weapon to be used by the player.
    void SetCurrentEquip(string name)
    {
        //Checks to see if player has the weapon in the inventory.
        if(_playerData.weaponInventory.Contains(name) == false) { Debug.Log("No Weapon of that name."); return;  }

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
    public void AddNewWep(string name) { _playerData.weaponInventory.Add(name); }
}

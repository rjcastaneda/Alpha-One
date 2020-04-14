using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    PlayerData _playerData;
    WeaponInventory _weaponInventory;
    TextMeshProUGUI score;
    TextMeshProUGUI weapon;
    TextMeshProUGUI lives;

    void Start()
    {
        _playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        _weaponInventory = GameObject.Find("Player").GetComponent<WeaponInventory>();
        score = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        weapon = GameObject.Find("WeaponText").GetComponent<TextMeshProUGUI>();
        lives = GameObject.Find("LivesText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score.text = _playerData.score.ToString("D10");
        weapon.text = _weaponInventory.selectedWeapon.wepName;
        lives.text = _playerData.lives.ToString();
    }
}

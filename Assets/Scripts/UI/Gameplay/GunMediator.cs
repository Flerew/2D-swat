using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GunMediator : MonoBehaviour
{
    [SerializeField] private Text _ammoCountText;

    private Gun _playerGun;

    [Inject]
    private void Construct(Player player)
    {
        _playerGun = player.Gun;

        _playerGun.AmmoChange += UpdateAmmoCount;
    }

    private void UpdateAmmoCount(int magazineAmmoCount, int AmmoCount)
    {
        _ammoCountText.text = magazineAmmoCount.ToString() + "/" + AmmoCount;
    }
}

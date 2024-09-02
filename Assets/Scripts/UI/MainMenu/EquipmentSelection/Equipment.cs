using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Equipment : MonoBehaviour
{
    [SerializeField] private GunDropdown _gunDropdown;
    [SerializeField] private GunFactory _gunFactory;

    private SaveEquipment _saveEquipment = new SaveEquipment();
    private EquipmentData _equipmentData;

    public Gun Gun { get; private set; }

    [Inject]
    private void Construct()
    {
        _equipmentData = _saveEquipment.GetData();

        _gunDropdown.Initialize(_gunFactory, _equipmentData.SelectedGunId);

        _gunDropdown.ChangeGun += ChangeGun;
        _gunDropdown.OnMenuChoice();
    }

    private void ChangeGun(Gun gun, int id)
    {
        Gun = gun;
        _equipmentData.SelectedGunId = id;
        _saveEquipment.SaveData(_equipmentData);
    }
}

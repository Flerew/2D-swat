using UnityEngine;

public class SaveEquipment
{
    private const string GunString = "SelectedGunId";
    private const string GrenadeString = "SelectedGrenadeId";


    private EquipmentData _equipmentData = new EquipmentData();

    public void SaveData(EquipmentData equipmentData)
    {
        _equipmentData = equipmentData;

        SaveValues(_equipmentData.SelectedGunId, _equipmentData.SelectedGrenadeId);
    }

    public EquipmentData GetData()
    {
        if (PlayerPrefs.HasKey(GunString) == false || PlayerPrefs.HasKey(GrenadeString) == false)
            SetDefaultValues();

        _equipmentData.SelectedGunId = PlayerPrefs.GetInt(GunString);
        _equipmentData.SelectedGrenadeId = PlayerPrefs.GetInt(GrenadeString);

        return _equipmentData;
    }
    private void SaveValues(int gunId, int grenadeId)
    {
        PlayerPrefs.SetInt(GunString, gunId);
        PlayerPrefs.SetInt(GrenadeString, grenadeId);
    }


    private void SetDefaultValues()
    {
        int defaultValue = 0;

        SaveValues(defaultValue, defaultValue);
    }
}

public class EquipmentData
{
    public int SelectedGunId { get; set; }
    public int SelectedGrenadeId { get; set; }
}

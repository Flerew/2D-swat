using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIBootstrap : MonoBehaviour
{
    [SerializeField] private MobileInputUI _mobileUI;

    private void Awake()
    {
        CheckDeviceUI();
    }

    private void CheckDeviceUI()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            _mobileUI.EnableMobileUI();
    }
}

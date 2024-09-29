using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintMediator : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private List<HintTrigger> _triggers;
    [SerializeField] private float _showTime;

    private bool _isMobile;

    private void Awake()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            _isMobile = true;

        RegisterTriggers();
    }

    private void RegisterTriggers()
    {
        foreach (HintTrigger trigger in _triggers)
        {
            trigger.OnTriggerEnter += UpdateText;
        }
    }

    private void UpdateText(string DesktopText, string mobileText)
    {
        if(_isMobile)
            _text.text = mobileText;
        else
            _text.text = DesktopText;

        StartCoroutine(TextDelay());
    }

    private IEnumerator TextDelay()
    {
        yield return new WaitForSeconds(_showTime);
        _text.text = String.Empty;
    }
}

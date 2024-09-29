using System;
using UnityEngine;

public class HintTrigger : MonoBehaviour, IPlayerTrigger
{
    public event Action<string, string> OnTriggerEnter; // Desktop, Mobile text

    [SerializeField] private string _desktopText;
    [SerializeField] private string _mobileText;

    private bool _isShowed;

    public void OnPlayerEnter()
    {
        if (_isShowed == false)
        {
            OnTriggerEnter?.Invoke(_desktopText, _mobileText);
            _isShowed = true;
        }
    }
}

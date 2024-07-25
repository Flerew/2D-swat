using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectLevelButton : MonoBehaviour
{
    public event Action<int> Click;

    [SerializeField] private int _levelIndex;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(OnClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnClick);

    private void OnClick() => Click?.Invoke(_levelIndex);
}

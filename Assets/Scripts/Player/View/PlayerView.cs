using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView : MonoBehaviour
{
    private bool _isHandledDevice;
    private ILook _playerControls;
    private Rigidbody2D _rb;

    private Vector3 _mousePosition;

    [Inject]
    private void Construct(PlayerControls playerControls)
    {
        _playerControls = playerControls;
        _rb = GetComponent<Rigidbody2D>();

        //if (SystemInfo.deviceType == DeviceType.Handheld)
        //{
            _isHandledDevice = true;
            _playerControls.Look += MobileLook;
        //}
    }

    private void Update()
    {
        if (_isHandledDevice)
            _playerControls.GetMobileLook();
        else
            DesktopLook();
    }

    private void OnDisable()
    {
        _playerControls.Look -= MobileLook;
    }

    private void DesktopLook()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = _mousePosition - transform.position;
        float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, rotateZ);
    }

    private void MobileLook(Vector2 joystickPos)
    {
        float angle = Mathf.Atan2(joystickPos.x , joystickPos.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -angle);
    }
}

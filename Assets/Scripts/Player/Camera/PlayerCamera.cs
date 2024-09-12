using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class PlayerCamera : MonoBehaviour
{
    private Transform _player;
    private CinemachineVirtualCamera _camera;
    private CameraShake _cameraShake;

    [Inject]
    private void Construct(Player player)
    {
        _player = player.gameObject.transform;

        _camera = GetComponent<CinemachineVirtualCamera>();
        _camera.Follow = _player;

        _cameraShake = new CameraShake(_camera);
    }

    private void Update()
    {
        _cameraShake.Update();
    }
}

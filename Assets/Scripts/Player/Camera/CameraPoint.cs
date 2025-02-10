using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraPoint : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 5f;
    [SerializeField] private float _minDistance = 3f;

    private Transform _playerTransfrom;

    public void Initialize(Transform playerTransfrom)
    {
        _playerTransfrom = playerTransfrom;
    }

    private void Update()
    {
        if (_playerTransfrom != null)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = GetCenterPoint(_playerTransfrom.position, cursorPosition);

            float distance = Vector2.Distance(_playerTransfrom.position, newPosition);

            if (distance < _minDistance)
                transform.position = Vector3.MoveTowards(_playerTransfrom.position, newPosition, _minDistance);
            else if(distance < _maxDistance)
                transform.position = Vector3.MoveTowards(transform.position, newPosition, _maxDistance);
        }
    }

    private Vector3 GetCenterPoint(Vector3 point1, Vector3 point2)
    {
        float x1 = point1.x, x2 = point2.x;
        float y1 = point1.y, y2 = point2.y;
        float z1 = point1.z, z2 = point2.z;

        return new Vector3((x1 + x2) / 2f, (y1 + y2) / 2f, (z1 + z2) / 2f);
    }
}

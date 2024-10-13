using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [Header("LeftDoor")]
    [SerializeField] private Transform _leftDoor;
    [SerializeField] private float _endLeftPositionX;

    [Header("RightDoor")]
    [SerializeField] private Transform _rightDoor;
    [SerializeField] private float _endRightPositionX;

    [SerializeField] private float _duration;
    [SerializeField] private bool _isLocked;

    private bool _isOpen;
    private float _startLeftPositionX;
    private float _startRightPositionX;

    private void Awake()
    {
        _startLeftPositionX = _leftDoor.localPosition.x;
        _startRightPositionX = _rightDoor.localPosition.x;
    }

    public void OpenCloseDoor()
    {
        _isOpen = !_isOpen;

        if (_isOpen && _isLocked == false)
            OpenDoor();
        else
            CloseDoor();
    }

    public void LockDoor(bool isLock) => _isLocked = isLock;

    private void OpenDoor()
    {
        _leftDoor.DOLocalMoveX(_endLeftPositionX, _duration);
        _rightDoor.DOLocalMoveX(_endRightPositionX, _duration);
    }

    private void CloseDoor()
    {
        _leftDoor.DOLocalMoveX(_startLeftPositionX, _duration);
        _rightDoor.DOLocalMoveX(_startRightPositionX, _duration);
    }
}

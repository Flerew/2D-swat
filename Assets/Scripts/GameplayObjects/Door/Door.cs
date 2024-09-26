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

        if (_isOpen)
            OpenDoor();
        else
            CloseDoor();
    }

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

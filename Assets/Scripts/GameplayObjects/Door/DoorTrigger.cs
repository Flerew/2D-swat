using UnityEngine;

public class DoorTrigger : MonoBehaviour, IInteractiveObjectTrigger
{
    [SerializeField] private Door _door;

    public void Interact()
    {
        _door.OpenCloseDoor();
    }
}

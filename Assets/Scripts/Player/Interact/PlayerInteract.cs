using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

public class PlayerInteract : MonoBehaviour
{
    private const float InteractState = 1f;

    [SerializeField] private float _interactionDelay = 0.2f;

    private IInteract _controls;
    private GameObject _currentTrigger;
    private bool _isInteractDelay;

    [Inject]
    private void Construct(PlayerControls playerControls)
    {
        _controls = playerControls;
        _controls.OnInteract += TryInteract;
    }

    private void Update()
    {
        _controls.GetInteract();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckCollisionLayer(collision))
        {
            _currentTrigger = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckCollisionLayer(collision))
        {
            _currentTrigger = null;
        }
    }

    private void TryInteract(float value)
    {
        if (value == InteractState && _currentTrigger != null && _isInteractDelay == false)
            _ = Interact();
    }

    private async UniTask Interact()
    {
        if (_currentTrigger.TryGetComponent(out IInteractiveObjectTrigger component))
        {
            component.Interact();

            _isInteractDelay = true;
            await UniTask.Delay(TimeSpan.FromSeconds(_interactionDelay));
            _isInteractDelay = false;
        }
    }

    private bool CheckCollisionLayer(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ObjectTrigger"))
            return true;
        else
            return false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewTrigger : MonoBehaviour
{
    public event Action DetectPlayer;

    [SerializeField] private GameObject _lastPlayerPositionPrefab;

    private List<Transform> _playerTriggers;

    public GameObject LastPlayerPositionPoint { get; private set; } = null;

    [Inject]
    private void Construct(Player player)
    {
        _playerTriggers = player.ViewTriggers;
    }


    private void Update()
    {
        CreateRays();
    }

    private void CreateRays()
    {
        foreach (Transform trigger in _playerTriggers)
        {
            Vector2 direction = trigger.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
            
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ViewTrigger"))
            {
                DetectPlayer?.Invoke();
                SetLastPointPosition(hit.collider.transform); 
            }
        }
    }

    private void SetLastPointPosition(Transform point)
    {
        if (LastPlayerPositionPoint == null)
            LastPlayerPositionPoint = Instantiate(_lastPlayerPositionPrefab, point.position, Quaternion.identity);

        LastPlayerPositionPoint.transform.position = point.position;
    }
}

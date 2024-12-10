using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewTrigger : MonoBehaviour
{
    public event Action DetectPlayer; 

    private List<Transform> _playerTriggers;

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
            }
        }
    }
}

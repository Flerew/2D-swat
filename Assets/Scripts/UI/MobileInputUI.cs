using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _mobileUI;

    public void EnableMobileUI()
    {
        foreach (GameObject obj in _mobileUI)
        {
            obj.SetActive(true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLevelHandler : MonoBehaviour
{
    [SerializeField] private int _targetButtonsCount;
    [SerializeField] private GameObject _containner;
    [SerializeField] private GameObject _buttonPrefabs;
    [SerializeField] private List<GameObject> _buttonsLevel;

    private void Start()
    {
        for (int i = 0; i < _targetButtonsCount; i++)
        {
            GameObject newButtons;
            newButtons = Instantiate(_buttonPrefabs,_containner.transform);
            newButtons.GetComponent<ButtonLevelHandler>()._id = i;
            _buttonsLevel.Add(newButtons);
        }
    }
}

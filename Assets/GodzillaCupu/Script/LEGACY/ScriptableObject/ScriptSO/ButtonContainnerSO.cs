using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[Serializable, CreateAssetMenu(fileName = "ButtonsHandler",menuName = "Manager/Buttons")]
public class ButtonContainnerSO : ScriptableObject
{
    public List<GameObject> Buttons;
}

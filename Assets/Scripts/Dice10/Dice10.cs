using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tools.Animations;
using System;

[SelectionBase]
public class Dice10 : MonoBehaviour
{
    public Action OnActivate;

    private bool isActivate;

    public bool IsActivate => isActivate;

    public void Activate()
    {
        isActivate = true;
        OnActivate?.Invoke();
    }
}

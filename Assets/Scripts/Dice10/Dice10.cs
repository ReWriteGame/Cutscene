using UnityEngine;
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

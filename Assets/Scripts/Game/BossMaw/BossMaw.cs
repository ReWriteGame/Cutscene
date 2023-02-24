using System;
using UnityEngine;

public class BossMaw : MonoBehaviour
{
    public Action OnActivate;

    public void Activate() 
    {
        OnActivate?.Invoke();
    }
}

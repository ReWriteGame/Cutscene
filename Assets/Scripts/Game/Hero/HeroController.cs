using System;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private bool castActivation;

    public Action OnCastActivation;
  
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed / 1000);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastActivation();
        }
    }


    private void CastActivation()
    {
        OnCastActivation?.Invoke();
    }
}

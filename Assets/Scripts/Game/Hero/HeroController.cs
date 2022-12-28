using System;
using UnityEngine;
using System.Collections;


public class HeroController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;

    public Action OnCastActivation;
    public Action OnCast;
    public Action<bool> OnWalk;

    private void Start()
    {
        StartCoroutine(CutsceneClip());
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed / 1000);
            OnWalk?.Invoke(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            OnWalk?.Invoke(false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastActivation();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cast();
        }
    }


    private void CastActivation()
    {
        OnCastActivation?.Invoke();
    }
    private void Cast()
    {
        OnCast?.Invoke();
    }


    private IEnumerator CutsceneClip()
    {

        yield break;
    }
}

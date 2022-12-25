using System;
using UnityEngine;
using System.Collections;


public class HeroController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;

    public Action OnCastActivation;
    public Action<bool> OnWalk;

    private void Start()
    {
        StartCoroutine(CutsceneClip());
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed / 1000);
            OnWalk?.Invoke(true);
        }
        else
        {
            OnWalk?.Invoke(false);
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


    private IEnumerator CutsceneClip()
    {

        yield break;
    }
}

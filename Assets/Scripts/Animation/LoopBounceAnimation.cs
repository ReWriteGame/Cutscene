using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBounceAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.up;
    [SerializeField] private float heightBounce;
    [SerializeField][Min(0)] private float bouncePerSeconds = 1;

    [SerializeField][Min(0)] private bool useCurve = false;
    [SerializeField][Min(0)] private float ñurveTime = 1;
    [SerializeField] private AnimationCurve rotationCurve = AnimationCurve.Constant(0, 1, 1);
    [Space]
    [SerializeField] private bool playOnAwake = true;
    //[SerializeField] private bool playOnAwake = true;
    [SerializeField] private bool animated;

    private Transform transformObject;
    private float time = 0;

    private void Awake()
    {
        transformObject = GetComponent<Transform>();
        if (playOnAwake) Play();
    }


    private IEnumerator Bounce()
    {
        //while (true)
        //{
        //      transformObject.position
        //    yield return null;
        //}
        yield return null;
    }
    public void Play()
    {
        animated = true;
    }

    public void Stop()
    {
        animated = false;
    }
}

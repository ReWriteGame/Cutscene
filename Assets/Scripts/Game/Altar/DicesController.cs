using System.Collections.Generic;
using UnityEngine;
using Tools.Animations;

public class DicesController : MonoBehaviour
{
    [SerializeField] private List<LoopRotateAnimation> dicesAnimation;


    private void Start()
    {
        DisableAnimationRotate();
    }

    public void EnableAnimationRotate()
    {
        dicesAnimation.ForEach(x => x.Play());
    }

    public void DisableAnimationRotate()
    {
        dicesAnimation.ForEach(x => x.Stop());
    }
}

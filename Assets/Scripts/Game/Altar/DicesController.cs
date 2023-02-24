using System.Collections.Generic;
using UnityEngine;

public class DicesController : MonoBehaviour
{
    [SerializeField] private List<Dice10> dicesAnimation;

   
    public void ActivateDices()
    {
        dicesAnimation.ForEach(x => x.Activate());
    }


    /*private void Start()
    {
        DisableAnimationRotate();
    }
  
    public void EnableAnimationRotate()
    {
        dicesAnimation.ForEach(x => x.LoopRotateAnimatio.Play());
    }

    public void DisableAnimationRotate()
    {
        dicesAnimation.ForEach(x => x.LoopRotateAnimatio.Stop());
    }

    public void EnableAnimationShowSymbols()
    {
        dicesAnimation.ForEach(x => x.ShowSymbols());
    }

    public void EnableAnimationHideSymbols()
    {
        dicesAnimation.ForEach(x => x.HideSymbols());
    }*/
}

using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    [SerializeField] private HeroController hero;
    [SerializeField] private Animator animator;
    
    private const string ACTIVATE = "Activate"; 
    private const string ACTIVATE2 = "Play"; 
    private void OnEnable()
    {
        hero.OnCastActivation += AnimationActivate;
    }

    private void OnDisable()
    {
        hero.OnCastActivation -= AnimationActivate;
    }

    private void AnimationActivate()
    {
        animator.SetTrigger(ACTIVATE2);
    }
}

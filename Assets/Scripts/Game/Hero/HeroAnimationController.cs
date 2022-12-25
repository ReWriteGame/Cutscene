using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    [SerializeField] private HeroController hero;
    [SerializeField] private Animator animator;
    
    private const string ACTIVATE = "Activate"; 
    private const string WALK = "Walk"; 

    private void OnEnable()
    {
        hero.OnCastActivation += AnimationActivate;
        hero.OnWalk += Walk;
    }

    private void OnDisable()
    {
        hero.OnCastActivation -= AnimationActivate;
        hero.OnWalk -= Walk;

    }

    private void AnimationActivate()
    {
        animator.SetTrigger(ACTIVATE);
    }

    private void Walk(bool state)
    {
        animator.SetBool(WALK, state);
    }
}

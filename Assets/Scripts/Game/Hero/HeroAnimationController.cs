using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    [SerializeField] private HeroController hero;
    [SerializeField] private Animator animator;
    
    private const string CAST = "Cast"; 
    private const string WALK = "Walk";
    private const string ACTIVATE = "Activate";


    private void OnEnable()
    {
        hero.OnCastActivation += AnimationActivation;
        hero.OnCast += AnimationCast;
        hero.OnWalk += Walk;
    }

    private void OnDisable()
    {
        hero.OnCastActivation -= AnimationActivation;
        hero.OnCast -= AnimationCast;
        hero.OnWalk -= Walk;

    }

    private void AnimationCast()
    {
        animator.SetTrigger(CAST);
    }
    private void AnimationActivation()
    {
        animator.SetTrigger(ACTIVATE);
    }

    private void Walk(bool state)
    {
        animator.SetBool(WALK, state);
    }
}

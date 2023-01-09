using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Hero hero;

    private float animationBlend;

    // animation IDs
    private int animIDSpeed;
    private int animIDGrounded;
    private int animIDJump;
    private int animIDFreeFall;
    private int animIDMotionSpeed;
    private int animIDSpellActivate;
    private int animIDSpellPortal;
    private int animIDSpellLight;


    private void Start()
    {
        AssignAnimationIDs();
    }

    private void AssignAnimationIDs()
    {
        animIDSpeed = Animator.StringToHash("MoveSpeed");
        animIDGrounded = Animator.StringToHash("Grounded");
        animIDJump = Animator.StringToHash("Jump");
        animIDFreeFall = Animator.StringToHash("FreeFall");
        animIDMotionSpeed = Animator.StringToHash("MotionSpeed");

        animIDSpellActivate = Animator.StringToHash("SpellActivate");
        animIDSpellPortal = Animator.StringToHash("SpellPortal");
        animIDSpellLight = Animator.StringToHash("SpellLight");
    }

    private void Update()
    {
        if (animator == null) return;
        AnimationMove();
        AnimationGround();
        AnimationFall();
    }
    private void OnEnable()
    {
        hero.OnSpellActivate += AnimationSpellActivate;
        hero.OnSpellPortal += AnimationSpellPortal;
        hero.OnSpellLight += AnimationSpellLight;
    }

    private void OnDisable()
    {
        hero.OnSpellActivate -= AnimationSpellActivate;
        hero.OnSpellPortal -= AnimationSpellPortal;
        hero.OnSpellLight -= AnimationSpellLight;
    }

    private void AnimationMove()
    {
        animationBlend = Mathf.Lerp(animationBlend, hero.TargetSpeed, Time.deltaTime * hero.speedChangeRate);
        if (animationBlend < 0.01f) animationBlend = 0f;

        animator.SetFloat(animIDSpeed, animationBlend);
        animator.SetFloat(animIDMotionSpeed, NormalizedToOne(hero.inputUserDirection).magnitude);
    }

    private void AnimationGround()
    {
        animator.SetBool(animIDGrounded, hero.Move.Grounded);

        if (!hero.Move.Grounded) return;

        bool jump = hero.Move.jump && hero.Move._jumpTimeoutDelta <= 0.0f;
        animator.SetBool(animIDJump, jump);

        animator.SetBool(animIDFreeFall, false);

    }

    private void AnimationFall()
    {
        if (hero.Move.Grounded) return;

        if (hero.Move._fallTimeoutDelta < 0.0f)
            animator.SetBool(animIDFreeFall, true);
    }

    private void AnimationSpellActivate()
    {
        animator.SetTrigger(animIDSpellActivate);
    }

    private void AnimationSpellPortal()
    {
        animator.SetTrigger(animIDSpellPortal);
    }

    private void AnimationSpellLight()
    {
        animator.SetTrigger(animIDSpellLight);
    }

    private Vector2 NormalizedToOne(Vector2 vector)
    {
        return vector.magnitude > 1 ? vector.normalized : vector;
    }
}

using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    [SerializeField] private HeroController hero;
    [SerializeField] private Animator animator;
    [SerializeField] private Move move;


    // animation IDs
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed;


    private float _animationBlend;
    public float SpeedChangeRate = 10.0f;


    private bool _hasAnimator;


    private void Start()
    {
        _hasAnimator = animator == null;
        AssignAnimationIDs();
    }

    private void Update()
    {
        //_hasAnimator = TryGetComponent(out animator);

        //if (!_hasAnimator) return;
        AnimationMove();
        AnimationGround();
        AnimationFall();
    }


    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("MoveSpeed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }


    private void AnimationMove()
    {
        _animationBlend = Mathf.Lerp(_animationBlend, hero.targetSpeed, Time.deltaTime * SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;
        Debug.Log(2);
        animator.SetFloat(_animIDSpeed, _animationBlend);
        animator.SetFloat(_animIDMotionSpeed, NormalizedToOne(hero.inputUserDirection).magnitude);
    }

    private void AnimationGround()
    {
        animator.SetBool(_animIDGrounded, move.Grounded);


        if (move.Grounded)
        {
            bool jump = move.jump && move._jumpTimeoutDelta <= 0.0f;
            animator.SetBool(_animIDJump, jump);

            animator.SetBool(_animIDFreeFall, false);
        }
    }

    private void AnimationFall()
    {
        if (move.Grounded) return;

        if (move._fallTimeoutDelta < 0.0f)
            animator.SetBool(_animIDFreeFall, true);
    }



    private Vector2 NormalizedToOne(Vector2 vector)
    {
        return vector.magnitude > 1 ? vector.normalized : vector;
    }
}

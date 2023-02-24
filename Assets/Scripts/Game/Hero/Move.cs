using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float jumpHeight = 1.2f;
    [SerializeField] private float gravity = -15.0f;
    [SerializeField] private float jumpTimeout = 0.50f;
    [SerializeField] private float fallTimeout = 0.15f;
    [SerializeField] private bool jump = false;
    [SerializeField] private bool grounded = true;



    private float verticalVelocity;
    private float terminalVelocity = 53.0f;
    private float jumpTimeoutDelta;
    private float fallTimeoutDelta;
    private Vector2 moveDirection;
    private float targetRotation;
    private float rotationVelocity;


    public Vector2 MoveDirection => moveDirection;
    public CharacterController Controller => controller;
    public float FallTimeoutDelta => fallTimeoutDelta;
    public float JumpTimeoutDelta => jumpTimeoutDelta;
    public bool Grounded => grounded;
    public bool Jump => jump;

    public void SetGroundState(bool value)
    {
        grounded = value;
    }

    public void SetJumpState(bool value)
    {
        jump = value;
    }
    public void HorizontalMove(Vector2 direction, float speed)
    {
        float scaledMoveSpeed = speed * Time.deltaTime;
        moveDirection = direction;

        //Fix the problem of diagonal acceleration
        Vector3 targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;

        Vector3 horizontalMove = targetDirection.normalized * scaledMoveSpeed;
        Vector3 verticalMove = new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime;
        controller.Move(horizontalMove + verticalMove);
    }

    public void RotateVector(Vector2 direction, float rotationSmoothTime, float additionalRotation = 0)
    {
        if (direction == Vector2.zero) return;

        Vector3 inputDirection = new Vector3(direction.x, 0.0f, direction.y).normalized;
        targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + additionalRotation;

        RotateDegree(targetRotation, rotationSmoothTime);
    }

    public void RotateDegree(float degree, float rotationSmoothTime)
    {
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, degree,
            ref rotationVelocity, rotationSmoothTime);
        transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
    }

    public void JumpAndGravity()
    {
        if (grounded)
        {
            fallTimeoutDelta = fallTimeout;


            // stop our velocity dropping infinitely when grounded
            if (verticalVelocity < 0.0f)
                verticalVelocity = -2f;


            if (jump && jumpTimeoutDelta <= 0.0f)
            {
                // the square root of H * -2 * G = how much velocity needed to reach desired height
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // jump timeout
            if (jumpTimeoutDelta >= 0.0f)
                jumpTimeoutDelta -= Time.deltaTime;

        }
        else
        {
            // reset the jump timeout timer
            jumpTimeoutDelta = jumpTimeout;

            // fall timeout
            if (fallTimeoutDelta >= 0.0f)
                fallTimeoutDelta -= Time.deltaTime;


            // if we are not grounded, do not jump
            jump = false;
        }

        // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        if (verticalVelocity < terminalVelocity)
            verticalVelocity += gravity * Time.deltaTime;
    }
}



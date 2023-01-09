using UnityEngine;
using System;

[SelectionBase]
public class Hero : MonoBehaviour
{
    public Vector2 inputUserDirection;

    [SerializeField] private Move move;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float sprintSpeed = 5;
    [Range(0.0f, 0.5f)]
    [SerializeField] private float rotationSmoothTime = 0.12f;

    public float speedChangeRate = 10.0f;
    public float speedOffset = 0.1f;

    public bool sprint = false;
    public bool analogMovement = true;

    public float groundedOffset = -0.14f;
    public float groundedRadius = 0.28f;
    public LayerMask groundLayers;


    [SerializeField] private Camera camera;

    public Action OnSpellActivate;
    public Action OnSpellPortal;
    public Action OnSpellLight;



    public Move Move => move;
    public float TargetSpeed => targetSpeed;

    private float speed;
    private float targetSpeed;
    private float currentHorizontalSpeed;
    private float inputMagnitude;

    
    private void Update()
    {
        MoveLogic();
        RotateLogic();
        JumpAndGravityLogic();
    }

    private void MoveLogic()
    {
        targetSpeed = sprint ? sprintSpeed : moveSpeed;
        if (inputUserDirection == Vector2.zero) targetSpeed = 0.0f;

        inputMagnitude = analogMovement ? inputUserDirection.magnitude : 1f;
        speed = targetSpeed;


        //currentHorizontalSpeed = (moveDirection * targetSpeed).magnitude;
        currentHorizontalSpeed = new Vector3(move.controller.velocity.x, 0.0f, move.controller.velocity.z).magnitude;

        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
            currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                Time.deltaTime * speedChangeRate);

            speed = RoundValue(speed, 1000f);
        }

        move.HorizontalMove(inputUserDirection, speed);

    }

    private void RotateLogic()
    {
        float cameraViewDirections = camera != null ? camera.transform.eulerAngles.y : 0; ;
        move.RotateVector(inputUserDirection, rotationSmoothTime, cameraViewDirections);
    }


    private void JumpAndGravityLogic()
    {
        move.Grounded = GroundedCheck();

        move.JumpAndGravity();
    }


    // round speed to X decimal places
    private float RoundValue(float value, float viewValue)
    {
        return Mathf.Round(speed * viewValue) / viewValue;
    }

    public bool GroundedCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset,
            transform.position.z);
        return Physics.CheckSphere(spherePosition, groundedRadius, groundLayers,
            QueryTriggerInteraction.Ignore);
    }
}

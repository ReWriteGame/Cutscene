using UnityEngine;
using System;

[SelectionBase]
public class Hero : MonoBehaviour
{
    [HideInInspector] public Vector2 inputUserDirection;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private Move move;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float sprintSpeed = 5;
    [Range(0.0f, 0.5f)]
    [SerializeField] private float rotationSmoothTime = 0.12f;

    [SerializeField] private float speedChangeRate = 10.0f;
    [SerializeField] private float speedOffset = 0.1f;

    [SerializeField] private bool sprint = false;
    [SerializeField] private bool analogMovement = true;

    [SerializeField] private float groundedOffset = -0.14f;
    [SerializeField] private float groundedRadius = 0.28f;
    [SerializeField] private LayerMask groundLayers;


    public Action OnSpellActivate;
    public Action OnSpellPortal;
    public Action OnSpellLight;
  

    private float speed;
    private float targetSpeed;
    private float currentHorizontalSpeed;
    private float inputMagnitude;

    public bool Sprint { get => sprint; set => sprint = value; }
    public Move Move => move;
    public float TargetSpeed => targetSpeed;
    public float SpeedChangeRate { get => speedChangeRate; set => speedChangeRate = value; }

    private void Update()
    {
        MoveLogic();
        RotateLogic();
        JumpAndGravityLogic();
    }

    private void MoveLogic()
    {
        targetSpeed = Sprint ? sprintSpeed : moveSpeed;
        if (inputUserDirection == Vector2.zero) targetSpeed = 0.0f;

        inputMagnitude = analogMovement ? inputUserDirection.magnitude : 1f;
        speed = targetSpeed;

        //currentHorizontalSpeed = (moveDirection * targetSpeed).magnitude;
        currentHorizontalSpeed = new Vector3(move.Controller.velocity.x, 0.0f, move.Controller.velocity.z).magnitude;

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
        float cameraViewDirections = playerCamera != null ? playerCamera.transform.eulerAngles.y : 0; ;
        move.RotateVector(inputUserDirection, rotationSmoothTime, cameraViewDirections);
    }


    private void JumpAndGravityLogic()
    {
        move.SetGroundState(GroundedCheck());
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

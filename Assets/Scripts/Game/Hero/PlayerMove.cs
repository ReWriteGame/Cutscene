using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheckPivot;
    [SerializeField] private float checkGroundRadius = 0.4f;

    private Vector3 moveDirection;
    private float velocity;


    private void FixedUpdate()
    {
        if (IsOnTheGround()) velocity = 0;

        Move(moveDirection);
        DoGravity();
    }

    private void Update()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        moveDirection = new Vector3(xPos, 0, yPos);

    }

    
    private void Move(Vector3 direction)
    {
        characterController.Move(direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void DoGravity()
    {
        velocity += gravity * Time.fixedDeltaTime;
        characterController.Move(Vector3.up * velocity * Time.fixedDeltaTime);
    }

    private bool IsOnTheGround()
    {
        return Physics.CheckSphere(groundCheckPivot.position, checkGroundRadius, groundMask);
    }
}

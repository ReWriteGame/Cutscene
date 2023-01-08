using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class HeroInputController : MonoBehaviour
{
    [SerializeField] private Move move;
    [SerializeField] private HeroController hero;

    private UserInput input;


    private void Awake()
    {
        input = new UserInput();
        input.Hero.Jump.performed += Jump;
        input.Hero.Sprint.performed += Sprint;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        hero.inputUserDirection = input.Hero.Move.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext callback)
    {
        move.jump = true;
    }

    private void Sprint(InputAction.CallbackContext callback)
    {
        hero.sprint = Convert.ToBoolean(callback.ReadValue<float>());
    }

   
}

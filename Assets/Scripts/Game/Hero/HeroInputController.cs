using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class HeroInputController : MonoBehaviour
{
    [SerializeField] private Hero hero;

    private UserInput input;


    private void Awake()
    {
        input = new UserInput();

        input.Hero.Jump.performed += Jump;
        input.Hero.Sprint.performed += Sprint;
        input.Hero.Look.performed += Look;
        input.Hero.ActionSpellActivate.performed += SpellActivate;
        input.Hero.ActionSpellPortal.performed += SpellPortal;
        input.Hero.ActionSpellLight.performed += SpellLight;
    }

    private void Update()
    {
        Move();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }


    private void Move()
    {
        hero.inputUserDirection = input.Hero.Move.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext callback)
    {
        hero.Move.jump = true;
    }

    private void Sprint(InputAction.CallbackContext callback)
    {
        hero.sprint = Convert.ToBoolean(callback.ReadValue<float>());
    }

    private void Look(InputAction.CallbackContext callback)
    {
        // playerView.look = callback.ReadValue<Vector2>();
    }

    private void SpellActivate(InputAction.CallbackContext callback)
    {
        hero.OnSpellActivate?.Invoke();
    }

    private void SpellPortal(InputAction.CallbackContext callback)
    {
        hero.OnSpellPortal?.Invoke();
    }

    private void SpellLight(InputAction.CallbackContext callback)
    {
        hero.OnSpellLight?.Invoke();
    }
}

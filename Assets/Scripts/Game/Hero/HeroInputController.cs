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
        hero.Move.jump = true;
    }

    private void Sprint(InputAction.CallbackContext callback)
    {
        hero.sprint = Convert.ToBoolean(callback.ReadValue<float>());
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        //if (animationEvent.animatorClipInfo.weight > 0.5f)
        //{
        //    if (FootstepAudioClips.Length > 0)
        //    {
        //        var index = Random.Range(0, FootstepAudioClips.Length);
        //        AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
        //    }
        //}
    }
}

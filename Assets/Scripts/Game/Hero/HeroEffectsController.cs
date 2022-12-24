using UnityEngine;
using System.Collections;

public class HeroEffectsController : MonoBehaviour
{
    [SerializeField] private HeroController hero;
    [SerializeField] private GameObject centerActivateEffect;
    [SerializeField] private GameObject leftHandActivateEffect;
    [SerializeField] private GameObject rightHandActivateEffect;
    [SerializeField] private float delayExploding = 3;
  
    private void OnEnable()
    {
        hero.OnCastActivation += ActivateEffect;
    }

    private void OnDisable()
    {
        hero.OnCastActivation -= ActivateEffect;
    }

    private void ActivateEffect()
    {
        StartCoroutine(ReStartEffect(centerActivateEffect));
        StartCoroutine(ReStartEffect(leftHandActivateEffect, delayExploding));
        StartCoroutine(ReStartEffect(rightHandActivateEffect, delayExploding));
    }

    private IEnumerator ReStartEffect(GameObject effect, float delay = 0)
    {
        if (delay > 0) yield return new WaitForSeconds(delay);
        effect.SetActive(false);
        effect.SetActive(true);
        yield break;
    }
}

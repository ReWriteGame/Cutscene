using UnityEngine;
using System.Collections;

public class HeroEffectsController : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private GameObject centerActivateEffect;
    [SerializeField] private GameObject leftHandActivateEffect;
    [SerializeField] private GameObject rightHandActivateEffect;
    [SerializeField] private float delayExploding = 3;
  
    private void OnEnable()
    {
        hero.OnSpellPortal += ActivateEffect;
        hero.OnSpellPortal += CastEffect;
    }

    private void OnDisable()
    {
        hero.OnSpellPortal -= ActivateEffect;
        hero.OnSpellPortal -= CastEffect;
    }

    private void CastEffect()
    {
        StartCoroutine(ReStartEffect(centerActivateEffect));
        StartCoroutine(ReStartEffect(leftHandActivateEffect, delayExploding));
        StartCoroutine(ReStartEffect(rightHandActivateEffect, delayExploding));
    }

    private void ActivateEffect()
    {
        
    }

    private IEnumerator ReStartEffect(GameObject effect, float delay = 0)
    {
        if (delay > 0) yield return new WaitForSeconds(delay);
        effect.SetActive(false);
        effect.SetActive(true);
        yield break;
    }
}

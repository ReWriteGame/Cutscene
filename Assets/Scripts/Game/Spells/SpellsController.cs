using System.Collections;
using UnityEngine;

public class SpellsController : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private LightSpell lightSpellPrefab;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform targetMovePoint;
    [SerializeField] private Vector3 shiftSpawn;
    [SerializeField] private float delayToFollow = 1;


    private void OnEnable()
    {
        hero.OnSpellActivate += LightSpell;
    }

    private void OnDisable()
    {
        hero.OnSpellActivate -= LightSpell;
    }

    private void LightSpell()
    {
        StartCoroutine(LightSpellRoutine());
    }

    private IEnumerator LightSpellRoutine()
    {
        LightSpell spell = Instantiate(lightSpellPrefab, rightHand);
        spell.transform.position = rightHand.position + shiftSpawn;

        yield return new WaitForSeconds(1f);
        spell.transform.SetParent(null, true);
        yield return new WaitForSeconds(delayToFollow);
        spell.SetTargetMove(targetMovePoint);
    }

}

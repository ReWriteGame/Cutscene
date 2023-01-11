using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsController : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private GameObject lightSpellPrefab;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Vector3 shiftSpawn;


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
        GameObject spell = Instantiate(lightSpellPrefab, rightHand);
        spell.transform.position = rightHand.position + shiftSpawn;

        yield return new WaitForSeconds(1.1f);
        spell.transform.SetParent(null, true);
    }

}

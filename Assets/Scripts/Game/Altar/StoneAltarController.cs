using UnityEngine;
using System.Collections;

public class StoneAltarController : MonoBehaviour
{
    [SerializeField] private Altar altar;
    [SerializeField] private Transform pointForSkill;
    [SerializeField] private GameObject boss;
    [SerializeField] private DicesController dicesController;
    [SerializeField] private float delayActivation = 1;
    [SerializeField] private float sizeScaleLight = 30;
    [SerializeField] private float radiusZoneActivation = 1;

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.GetComponent<Hero>())
        {
            altar.Activate();
            boss.SetActive(true);
            dicesController.EnableAnimationRotate();
        }*/

        if (other.gameObject.GetComponent<LightSpell>())
            StartCoroutine(ActivateAltarLightSpellRoutine(other.gameObject.GetComponent<LightSpell>()));
        

    }

    private IEnumerator ActivateAltarLightSpellRoutine(LightSpell spell)
    {
        spell.SetTargetMove(pointForSkill);

        yield return new WaitUntil(() => Vector3.Distance(spell.transform.position, pointForSkill.position) < radiusZoneActivation);
        spell.EndLight();
        spell.transform.localScale = Vector3.one * sizeScaleLight;


        yield return new WaitForSeconds(delayActivation);

        altar.Activate();
        boss.SetActive(true);
        dicesController.ActivateDices();
    }
}

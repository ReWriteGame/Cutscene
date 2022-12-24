using UnityEngine;
using System.Collections;

public class HeroEffectsController : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private GameObject handEffect;
    [SerializeField] private float delay;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(handEffect, leftHand.position, Quaternion.identity);
        Instantiate(handEffect, rightHand.position, Quaternion.identity);
    }
}

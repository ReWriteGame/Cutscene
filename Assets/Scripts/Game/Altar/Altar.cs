using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private GameObject activationEffects;

    public void Activate()
    {
        activationEffects.SetActive(true);
    }
}

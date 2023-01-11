using UnityEngine;

public class LightSpell : MonoBehaviour
{
    [SerializeField] private GameObject startLightSpell;
    [SerializeField] private GameObject endLightSpell;

    private void Start()
    {
        Instantiate(startLightSpell, transform);
    }
  
}

using UnityEngine;

public class StoneAltarController : MonoBehaviour
{
    [SerializeField] private Altar altar;
    [SerializeField] private GameObject boss;
    [SerializeField] private DicesController dicesController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Hero>())
        {
            altar.Activate();
            boss.SetActive(true);
            dicesController.EnableAnimationRotate();
        }
        
    }
}

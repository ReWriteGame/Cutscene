using UnityEngine;

public class LightSpell : MonoBehaviour
{
    [SerializeField] private GameObject startLightSpell;
    [SerializeField] private GameObject endLightSpell;
    [SerializeField] private Transform targetMove;
    [SerializeField] private Vector3 shiftTargetMove;
    [SerializeField] private float moveTime;

    private Vector3 velocity;

    public void SetTargetMove(Transform target)
    {
        targetMove = target;
    }

    public void SetMoveTimeMove(float time)
    {
        moveTime = time;
    }

    private void Start()
    {
        StartLight();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if(targetMove != null) transform.position = Vector3.SmoothDamp(transform.position, targetMove.position + shiftTargetMove, ref velocity, moveTime);
    }

    public void StartLight()
    {
        startLightSpell.SetActive(true);
        endLightSpell.SetActive(false);
    }

    public void EndLight()
    {
        startLightSpell.SetActive(false);
        endLightSpell.SetActive(true);
    }
}

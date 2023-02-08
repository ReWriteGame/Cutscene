using System.Collections;
using UnityEngine;

public class BossMawVisual : MonoBehaviour
{
    [SerializeField] private BossMaw bossMaw;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private float timeShowBoss = 5;

    private float opacityDefault;

    private void Start()
    {
        skinnedMeshRenderer.material = new Material(skinnedMeshRenderer.material);
        opacityDefault = skinnedMeshRenderer.material.color.a;

        ChangeOpacityMaterial(skinnedMeshRenderer.material, 0);

        bossMaw.OnActivate += ShowBoss;
    }

    private void ShowBoss()
    {
        StartCoroutine(ChangeOpacityRoutine(0, opacityDefault, timeShowBoss));
    }

    private void ChangeOpacityMaterial(Material material, float value)
    {
        Color color = material.color;
        color.a = Mathf.Clamp(value, 0, 1);
        material.color = color;
    }


    private IEnumerator ChangeOpacityRoutine(float startOpacity, float opacity, float timeDuration)
    {
        for (float time = 0; time < timeDuration; time += Time.deltaTime)
        {
            float value = 1 - time / timeDuration;
            float opacityValue = Mathf.Lerp(opacity, startOpacity, value);
            ChangeOpacityMaterial(skinnedMeshRenderer.material, opacityValue);
            yield return null;
        }
    }
}

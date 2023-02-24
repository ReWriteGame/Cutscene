using System.Collections;
using TMPro;
using Tools.Animations;
using UnityEngine;

public class Dice10Visual : MonoBehaviour
{
    [SerializeField] private Dice10 dice10;
    [SerializeField] private LoopRotateAnimation loopRotateAnimation;
    [SerializeField] private LoopBounceAnimation loopBounceAnimation;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private TMP_Text[] symbols;
    [SerializeField] private float timeShowText;


    private Coroutine opacityCor;

    public LoopRotateAnimation LoopRotateAnimatio => loopRotateAnimation;

    private void Start()
    {
        Initialize();

        dice10.OnActivate += ShowSymbols;
        dice10.OnActivate += loopRotateAnimation.Play;
        dice10.OnActivate += loopBounceAnimation.Play;
        dice10.OnActivate += particle.Play;
    }

    private void OnDestroy()
    {
        dice10.OnActivate -= ShowSymbols;
        dice10.OnActivate -= loopRotateAnimation.Play;
        dice10.OnActivate -= loopBounceAnimation.Play;
        dice10.OnActivate -= particle.Play;
    }

    private void Initialize()
    {
        foreach (var symbol in symbols)
            ChangeTransparencySymbol(symbol, 0);

        ApplyRandomNumbers();

        particle.Stop();
        loopRotateAnimation.Stop();
        loopBounceAnimation.Stop();
    }

    public void ShowSymbols()
    {
        if (opacityCor != null) StopCoroutine(opacityCor);
        opacityCor = StartCoroutine(ChangeOpacitySymbolsRoutine(1, timeShowText));
    }

    public void HideSymbols()
    {
        if (opacityCor != null) StopCoroutine(opacityCor);
        opacityCor = StartCoroutine(ChangeOpacitySymbolsRoutine(0, timeShowText));
    }

    public void ApplyRandomNumbers()
    {
        foreach(var symbol in symbols)
            symbol.text = $"{ Random.Range(0,9)}";
    }

    private void ChangeTransparencySymbol(TMP_Text text, float value)
    {
        Color color = text.color;
        color.a = Mathf.Clamp(value, 0, 1);
        text.color = color;
    }

    private IEnumerator ChangeOpacitySymbolsRoutine(float opacity, float timeDuration)
    {
        float currentValue = symbols[0].color.a;

        for (float time = 0; time < timeDuration; time += Time.deltaTime)
        {
            float value = 1 - time / timeDuration;
            float opacityValue = Mathf.Lerp(opacity, currentValue, value);

            foreach (var symbol in symbols)
                ChangeTransparencySymbol(symbol, opacityValue);

            yield return null;
        }
    }
}

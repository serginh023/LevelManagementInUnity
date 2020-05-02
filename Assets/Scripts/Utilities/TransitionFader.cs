using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFader : ScreenFader
{
    [SerializeField]
    private float _lifeTime = 1f;

    [SerializeField]
    private float _delay = .3f;

    public float Delay { get { return _delay; } }


    private void Awake()
    {
        _lifeTime = Mathf.Clamp(_lifeTime, FadeOnDuration + FadeOffDuration + _delay, 10f);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine()
    {
        SetAlpha(_clearAlpha);

        yield return new WaitForSeconds(_delay);

        FadeOn();

        float onTime = _lifeTime - (FadeOffDuration + _delay);

        yield return new WaitForSeconds(onTime);

        FadeOff();

        Destroy(gameObject, FadeOffDuration);
    }

    public static void PlayTransition(TransitionFader transitionFaderPrefab)
    {
        if(transitionFaderPrefab != null)
        {
            TransitionFader instance = Instantiate(transitionFaderPrefab, Vector3.zero, Quaternion.identity);
            instance.Play();
        }
    }

}

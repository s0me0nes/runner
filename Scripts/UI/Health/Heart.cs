using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(Filing(0, 1, _lerpDuration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filing(1, 0, _lerpDuration, Destroy));
    }

    private IEnumerator Filing(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapset = 0;
        float nextValue;

        while (elapset < duration)
        {
            nextValue = Mathf.Lerp(startValue,endValue, elapset / duration);
            _image.fillAmount = nextValue;
            elapset += Time.deltaTime;

            yield return null;
        }

        lerpingEnd?.Invoke(endValue);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AnimationViewer : MonoBehaviour
{
    [SerializeField] private float _smoothChangeSliderValueIndex;

    private Slider _slider;
    private Coroutine _changeValueCoroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void DisableVolume()
    {
        if (_changeValueCoroutine != null)
            StopCoroutine( _changeValueCoroutine);

        StartCoroutine(SetSliderValue(_slider.minValue));
    }

    public void EnableVolume() 
    {
        if (_changeValueCoroutine != null)
            StopCoroutine(_changeValueCoroutine);

        StartCoroutine(SetSliderValue(_slider.maxValue));
    }

    private IEnumerator SetSliderValue(float value)
    {
        while (_slider.value != value)
        { 
            _slider.value = Mathf.MoveTowards(_slider.value, value, _smoothChangeSliderValueIndex);

            yield return null;
        }
    }
}
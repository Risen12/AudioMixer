using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ValueChangeHandler : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioGroup;

    private float _multiplyer;
    private Slider _slder;

    private void Awake()
    {
        _multiplyer = 20f;
        _slder = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slder.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slder.onValueChanged.RemoveListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        _audioGroup.audioMixer.SetFloat(_audioGroup.name, Mathf.Log10(value) * _multiplyer);
    }
}
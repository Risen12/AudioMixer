using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private string _soundsMixerGroupName;
    [SerializeField] private string _backgroundMusicMixerGroupName;
    [SerializeField] private string _masterSoundGroupName;
    [SerializeField] private MasterVolumeSliderController _sliderController;

    private float _maxSound;
    private float _minSound;
    private float _multiplyer;

    private void Awake()
    {
        _minSound = -80f;
        _maxSound = 0;
        _multiplyer = 20f;
    }

    public void SwitchSound(bool state)
    {
        if (state)
        {
            _audioMixer.audioMixer.SetFloat(_masterSoundGroupName, _maxSound);
            _sliderController.EnableVolume();
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(_masterSoundGroupName, _minSound);
            _sliderController.DisableVolume();
        }
    }

    public void SetMusicVolume(float value)
    {
        _audioMixer.audioMixer.SetFloat(_backgroundMusicMixerGroupName, Mathf.Log10(value) * _multiplyer);
    }

    public void SetSoundsVolume(float value)
    {
        _audioMixer.audioMixer.SetFloat(_soundsMixerGroupName, Mathf.Log10(value) * _multiplyer);
    }

    public void SetMasterVolume(float value)
    {
        _audioMixer.audioMixer.SetFloat(_masterSoundGroupName, Mathf.Log10(value) * _multiplyer);
    }
}

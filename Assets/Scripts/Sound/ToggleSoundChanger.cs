using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AnimationViewer))]
public class ToggleSoundChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioGroup;

    private float _maxSound;
    private float _minSound;
    private AnimationViewer _animationViewer;

    private void Awake()
    {
        _minSound = -80f;
        _maxSound = 0;
        _animationViewer = GetComponent<AnimationViewer>();
    }

    public void Disable()
    {
        _audioGroup.audioMixer.SetFloat(_audioGroup.name, _minSound);
        _animationViewer.DisableVolume();
    }

    public void Enable()
    {
        _audioGroup.audioMixer.SetFloat(_audioGroup.name, _maxSound);
        _animationViewer.EnableVolume();
    }
}

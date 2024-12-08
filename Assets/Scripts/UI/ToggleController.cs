using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _currentSprite;
    [SerializeField] private Sprite _disabledStateSprite;
    [SerializeField] private Sprite _enabledStateSprite;
    [SerializeField] private ToggleSoundChanger _soundChanger;

    private Toggle _toggle;
    private string _disabledText;
    private string _enabledText;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();

        _enabledText = "Выключить звук";
        _disabledText = "Включить звук";
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(SwitchState);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(SwitchState);
    }

    private void SwitchState(bool state)
    {
        if (state)
        {
            _currentSprite.sprite = _enabledStateSprite;
            _text.text = _enabledText;
            _soundChanger.Enable();
        }
        else
        {
            _currentSprite.sprite = _disabledStateSprite;
            _text.text = _disabledText;
            _soundChanger.Disable();
        }
    }
}
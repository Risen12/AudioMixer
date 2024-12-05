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

    private Toggle _toggle;
    private string _disabledText;
    private string _enabledText;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();

        _enabledText = "��������� ����";
        _disabledText = "�������� ����";
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(SwitchState);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveAllListeners();
    }

    private void SwitchState(bool state)
    {
        if (state)
        {
            _currentSprite.sprite = _enabledStateSprite;
            _text.text = _enabledText;
        }
        else
        {
            _currentSprite.sprite = _disabledStateSprite;
            _text.text = _disabledText;
        }
    }
}
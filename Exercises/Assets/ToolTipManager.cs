using UnityEngine;
using TMPro;

public class ToolTipManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    void Start()
    {
        ToolTiper._onMouseOver += UpdateText;
    }

    void UpdateText(string value)
    {
        _text.text = value;
    }

    private void OnDestroy()
    {
        ToolTiper._onMouseOver -= UpdateText;

    }
}

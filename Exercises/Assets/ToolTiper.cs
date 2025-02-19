using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTiper : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private string _toolTipString;
    public static Action<string> _onMouseOver;

    public void OnPointerEnter(PointerEventData evenData)
    {
        _onMouseOver?.Invoke(_toolTipString);
        // ? check si est null
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _onMouseOver?.Invoke("");
    }

    private void OnMouseEnter()
    {
        _onMouseOver?.Invoke(_toolTipString);
    }

    private void OnMouseExit() 
    {
        _onMouseOver?.Invoke("");
    }
}

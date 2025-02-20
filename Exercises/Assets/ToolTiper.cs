using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTiper : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    //[SerializeField] private string _toolTipString;
    [SerializeField] private GameObject _gameObject;
    public static Action<string> _onMouseOver;

    public void OnPointerEnter(PointerEventData evenData)
    {
        //_onMouseOver?.Invoke(_toolTipString);
        _onMouseOver?.Invoke(_gameObject.name);
        // ? check si est null
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _onMouseOver?.Invoke("");
    }

    private void OnMouseEnter()
    {
        //_onMouseOver?.Invoke(_toolTipString);
        _onMouseOver?.Invoke(_gameObject.name);
    }

    private void OnMouseExit() 
    {
        _onMouseOver?.Invoke("");
    }
}

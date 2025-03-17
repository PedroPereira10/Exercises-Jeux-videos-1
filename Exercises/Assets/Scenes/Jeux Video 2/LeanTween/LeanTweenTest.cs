using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LeanTweenTest : MonoBehaviour
{
    [SerializeField] private float _delay = 5f;
    [SerializeField] private List<GameObject> _list;

    private GameObject _gameObeject;
    private int _index = 0;

    private void Start()
    {
        MoveObject();
    }
    private void MoveObject()
    {
        if (_index >= _list.Count)
            return;
        
        _gameObeject = _list[_index];
        LeanTween.move(_gameObeject, new Vector2(0,0),_delay).setOnComplete(ChangeColor);
    }

    private void ChangeColor()
    {
        LeanTween.alpha(_gameObeject, 0, _delay).setOnComplete(() =>
        {
            _index++;
            if (_index < _list.Count)
            {
                MoveObject();
            }
        });
    }
}

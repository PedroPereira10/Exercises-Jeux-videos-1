using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<CharacterScriptable> _characterList;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _hitPointTxt;
    [SerializeField] private TextMeshProUGUI _damangeTxt;

    [SerializeField] private float _speed;

    private int _index;

    private void Start()
    {
        UpdateCharacterDisplay();
    }

    private void UpdateCharacterDisplay()
    {
        _image.rectTransform.position = _characterList[_index]._position;
        _image.sprite = _characterList[_index]._sprite;
        _hitPointTxt.text = _characterList[_index]._hitPoint.ToString();
        _damangeTxt.text = _characterList[_index]._damage.ToString();
    }
    [Button]

    public void NextHero()
    {
        _index++;
        if (_index > _characterList.Count - 1)
        {
            _index = 0;
        }
        UpdateCharacterDisplay();
    }
    [Button]

    public void PreviousHero()
    {
        _index--;
        if (_index < 0)
        { 
            _index = (_characterList.Count - 1);
        }
        UpdateCharacterDisplay();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _image.rectTransform.position += Vector3.right * _speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _image.rectTransform.position += Vector3.left * _speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _image.rectTransform.position += Vector3.down * _speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _image.rectTransform.position += Vector3.up * _speed * Time.deltaTime;
        }
        _characterList[_index]._position = _image.rectTransform.position;
    }
}

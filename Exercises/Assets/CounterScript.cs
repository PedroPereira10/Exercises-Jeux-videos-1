using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class CounterScript : MonoBehaviour
{
    private int _counter = 0;
    [SerializeField] public Button _counterButton;
    [SerializeField] public Text _counterText;

    private void Start()
    {
        _counterText.text = "" + _counter;

        _counterButton.onClick.AddListener(CounterUp);
    }

    void CounterUp()
    {
        _counter++;
        _counterText.text = "" + _counter;
    }
        
}

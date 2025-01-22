using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Fruits
{
    [SerializeField] private bool _hasPeel;

    private void Start()
    {
        _vitamineCContent = 50f;
    }
    private void SquirtJuice()
    {
        Debug.Log("What a mess");
    }

    public  void OrangeEaten()
    {
        if (_hasPeel)
        {
            TasteBitter();
        }

        else 
        { 
            SquirtJuice();
            TasteSweet();
        }

        GetEaten();
    }

    public override float GetEaten()
    {
        return _hasPeel ? 0f : _vitamineCContent;
    }
}

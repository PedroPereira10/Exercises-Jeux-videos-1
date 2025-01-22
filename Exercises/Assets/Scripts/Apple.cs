using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Fruits
{
    private void Start()
    {
        _vitamineCContent = 20f;
    }
    public void EmitCrunchNoise()
    {
        Debug.Log("Crunch");
    }

    public void AppleEaten()
    {
        EmitCrunchNoise();
        TasteSweet();
        GetEaten();
    }
}

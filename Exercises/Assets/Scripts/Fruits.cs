using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public float _vitamineCContent; 

    public virtual float GetEaten()
    {
        return _vitamineCContent;
    }

    public virtual void TasteSweet()
    {
        Debug.Log("Yummy");
    }

    public virtual void TasteBitter()
    {
        Debug.Log("Yuck!");
    }

}


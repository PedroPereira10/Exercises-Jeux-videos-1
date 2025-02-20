using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Animal : MonoBehaviour,IShowName
{
    [SerializeField] protected string _AnimalNameString;

    public string GetName()
    {
        return _AnimalNameString;
    }
}


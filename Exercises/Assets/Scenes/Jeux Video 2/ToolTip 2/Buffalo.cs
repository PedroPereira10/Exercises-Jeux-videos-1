using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Buffalo : Animal, IWorker
{
    private void Awake()
    {
        _AnimalNameString = "Buffalo";
    }

    public void Work()
    {
        Debug.Log($"{_AnimalNameString} is working");
    }
}

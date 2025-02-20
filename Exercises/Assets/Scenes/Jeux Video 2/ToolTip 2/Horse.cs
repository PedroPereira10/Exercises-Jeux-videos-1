using UnityEngine;


public class Horse : Animal, IWorker
{
    private void Awake()
    {
        _AnimalNameString = "Horse";
    }

    public void Work()
    {
        Debug.Log($"{_AnimalNameString} is working");
    }
}

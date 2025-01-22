using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceManager : MonoBehaviour
{
    [SerializeField] private Text _foodTXT;
    [SerializeField] private Text _oreTXT;
    [SerializeField] private Text _woodTXT;
    [SerializeField] private int _foodCount = 100;
    [SerializeField] private int _woodCount = 0;
    [SerializeField] private int _oreCount = 0;

    private Worker[] _workers;

    private void Start()
    {
        _workers = GetComponentsInChildren<Worker>(); 
        UpdateAllTextField();
    }

    public void SpendDayOfWork()
    {
        foreach (Worker worker in _workers)
        {
            worker.Work(); 
        }
        UpdateAllTextField(); 
    }

    public void AddWood(int woodToAdd)
    {
        _woodCount += woodToAdd;
    }

    public void AddOre(int oreToAdd)
    {
        _oreCount += oreToAdd;
    }

    public void AddFood(int foodToAdd)
    {
        _foodCount += foodToAdd;
    }

    private void UpdateAllTextField()
    {
        _foodTXT.text = "Food: " + _foodCount;
        _woodTXT.text = "Wood: " + _woodCount;
        _oreTXT.text = "Ore: " + _oreCount;
    }
}

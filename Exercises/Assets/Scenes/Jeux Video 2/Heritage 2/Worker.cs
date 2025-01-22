using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] protected RessourceManager _manager;
    [SerializeField] private int _foodConsumptionRate;
    [SerializeField] protected int _production;

    private void Start()
    {
        _manager = transform.parent.GetComponent<RessourceManager>();
    }

    public virtual void Work()
    {
        if (_manager != null)
        { 
            _manager.AddFood(-_foodConsumptionRate);
        }
    }
}

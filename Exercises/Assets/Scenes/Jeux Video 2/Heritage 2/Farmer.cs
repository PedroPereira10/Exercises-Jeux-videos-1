using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Worker
{
    public override void Work()
    {
        base.Work(); 

        
        if (_manager != null)
        {
            _manager.AddFood(_production);
        }
    }
}

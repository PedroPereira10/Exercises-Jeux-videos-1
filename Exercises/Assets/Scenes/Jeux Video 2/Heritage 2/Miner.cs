using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Worker
{
    public override void Work()
    {
        base.Work(); 

        
        if (_manager != null)
        {
            _manager.AddOre(_production);
        }
    }
}

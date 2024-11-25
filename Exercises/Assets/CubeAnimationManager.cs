using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeAnimationManager : MonoBehaviour
{
    [SerializeField] Text counterText; 
    private int counter = 0; 

    
    public void IncrementCounter()
    {
        counter++;
        UpdateCounterUI();
    }

    private void UpdateCounterUI()
    {
        if (counterText != null)
        {
            counterText.text = "" + counter;
        }
    }
}

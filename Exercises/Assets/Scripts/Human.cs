using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fruitsList; 
    [SerializeField] private float _totalVitamineCContent; 

    public void EatFirstFruit()
    {
        if (_fruitsList.Count > 0)
        {
            
            GameObject fruitToEat = _fruitsList[0];

            Fruits fruitScript = fruitToEat.GetComponent<Fruits>();

            if (fruitScript != null)
            {
                
                _totalVitamineCContent += fruitScript.GetEaten();

                
                if (fruitScript is Orange orange)
                {
                    orange.OrangeEaten();
                }
                else if (fruitScript is Apple apple)
                {
                    apple.AppleEaten();
                }
                else
                {
                    fruitScript.TasteSweet(); 
                }

                Debug.Log($"Human ate: {fruitToEat.name}. Total Vitamin C: {_totalVitamineCContent}");
            }
            else
            {
                Debug.LogWarning($"The object {fruitToEat.name} does not have a Fruits script.");
            }

            
            _fruitsList.RemoveAt(0);
            Destroy(fruitToEat);
        }
        else
        {
            Debug.Log("No fruits left to eat");
        }
    }
}
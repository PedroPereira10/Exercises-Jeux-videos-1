using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumeration_fruits : MonoBehaviour
{
    private enum Fruits
    {
        Apple,
        Orange,
        Strawberry
    }

    [SerializeField] private List<Fruits> fruitList = new List<Fruits>();
    void Start()
    {
        Dictionary<Fruits, int> fruitCount = new Dictionary<Fruits, int>();

        foreach (Fruits fruit in System.Enum.GetValues(typeof(Fruits)))
        {
            fruitCount[fruit] = 0;
        }

        foreach (Fruits fruit in fruitList)
        {
            fruitCount[fruit]++;
        }

        foreach (KeyValuePair<Fruits, int> entry in fruitCount)
        {
            Debug.Log($"{entry.Key}: {entry.Value}");
        }
    }
}

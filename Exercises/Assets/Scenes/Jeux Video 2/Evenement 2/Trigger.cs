using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static event Action _OnCubePressed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            Debug.Log("The Cube touched");
            _OnCubePressed?.Invoke();
        }
    }
}


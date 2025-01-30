using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public static Action<int> _onCubeArrived;
    public static Action<int> _onCubeLeft;
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEvent(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Target")
        {
            Debug.Log("The Cube left");
            _onCubeLeft?.Invoke(_value);
        }
        else
        {
            Debug.Log("The Cube didn't leave");
        }
    }

    private void TriggerEvent(Collider other)
    {
        if (other.gameObject.name == "Target")
        {
            Debug.Log("The Cube entered");
            _onCubeArrived?.Invoke(_value);
        }
        else
        {
            Debug.Log("The Cube was not found");
        }

        if (other.GetComponent<Collider>() != null)
        {
            Debug.Log("Collider found on object: " + other.gameObject.name);
        }
        else
        {
            Debug.Log("Collider NOT found on object: " + other.gameObject.name);
        }
    }
}

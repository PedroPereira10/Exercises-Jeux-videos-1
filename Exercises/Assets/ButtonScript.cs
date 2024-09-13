using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject _Door;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name);
        Sphere collisionSphere = other.GetComponent<Sphere>();
        if (collisionSphere != null)
        {
            Destroy(_Door);
            Debug.Log("Door destroyed!");
        }
    }

    private void DestroyDoor(GameObject Door)
    {
        {
            Destroy(Door); 
        }
    }
}

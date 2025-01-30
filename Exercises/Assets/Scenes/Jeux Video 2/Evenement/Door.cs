using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void Start()
    {
        DoorController._onCubeArrived += Updoor;
        DoorController._onCubeLeft += Downdoor;
    }

    private void OnEnable()
    {
        DoorController._onCubeArrived += Updoor;
        DoorController._onCubeLeft += Downdoor;
    }

    private void OnDisable()
    {
        DoorController._onCubeArrived -= Updoor;
        DoorController._onCubeLeft -= Downdoor;
    }

    private void Updoor(int value)
    {
        Vector3 newScale = transform.localScale;
        newScale.y += 1;
        transform.localScale = newScale;
    }

    private void Downdoor(int value)
    {
        Vector3 newScale = transform.localScale;
        newScale.y = 0;
        transform.localScale = newScale;
    }
}

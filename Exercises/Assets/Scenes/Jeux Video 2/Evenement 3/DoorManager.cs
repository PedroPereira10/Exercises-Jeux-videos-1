using System;
using UnityEngine;
using System.Collections.Generic;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> doorPrefabs;
    private List<Animator> doorAnimators = new List<Animator>();
    private bool isUnlocked = false;
    private bool isOpen = false;

    private void Start()
    {
        foreach (GameObject doorPrefab in doorPrefabs)
        {
            Animator animator = doorPrefab.GetComponent<Animator>();
            if (animator != null)
            {
                doorAnimators.Add(animator);
            }
        }
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
        Debug.Log("Doors are now unlocked.");
    }

    public void ToggleDoor()
    {
        if (isUnlocked)
        {
            foreach (Animator animator in doorAnimators)
            {
                if (isOpen)
                {
                    animator.SetBool("Open", false);
                    animator.SetBool("Close", true);
                }
                else
                {
                    animator.SetBool("Close", false);
                    animator.SetBool("Open", true);
                }
            }
            isOpen = !isOpen;
        }
        else
        {
            Debug.Log("Doors are locked.");
        }
    }
}

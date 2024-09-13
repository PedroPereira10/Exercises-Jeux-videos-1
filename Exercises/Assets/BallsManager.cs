using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    [SerializeField] private MoveBalls blackballMoveScript;
    [SerializeField] private MoveBalls whiteballMoveScript;

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (blackballMoveScript != null) blackballMoveScript.enabled = true;
            if (whiteballMoveScript != null) whiteballMoveScript.enabled = false;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (blackballMoveScript != null) blackballMoveScript.enabled = false;
            if (whiteballMoveScript != null) whiteballMoveScript.enabled = true;
        }
    }
}

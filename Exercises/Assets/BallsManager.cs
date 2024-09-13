using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    [SerializeField] private MoveBalls _blackballMoveScript;
    [SerializeField] private MoveBalls _whiteballMoveScript;
    [SerializeField] private Collider _blackwall;
    [SerializeField] private Collider _whitewall;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_blackballMoveScript != null) _blackballMoveScript.enabled = true;
            if (_whiteballMoveScript != null) _whiteballMoveScript.enabled = false;

            if (_blackwall != null) _blackwall.enabled = false;
            if (_whitewall != null) _whitewall.enabled = true;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_blackballMoveScript != null) _blackballMoveScript.enabled = false;
            if (_whiteballMoveScript != null) _whiteballMoveScript.enabled = true;

            if (_whitewall != null) _whitewall.enabled = false;
            if (_blackwall != null) _blackwall.enabled = true;
            
        }
    }
}

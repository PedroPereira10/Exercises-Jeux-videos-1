using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private float _timer;
    private float _negativeOrPositive = 1;

    void Update()
    {
        transform.localScale += new Vector3(0,_negativeOrPositive * _speed,0) * Time.deltaTime;
        if (transform.localScale.y > 1)
        {
            _negativeOrPositive = -1;
        }

        if (transform.localScale.y <= 0)
        {
            _negativeOrPositive = 1;
        }
    }
}



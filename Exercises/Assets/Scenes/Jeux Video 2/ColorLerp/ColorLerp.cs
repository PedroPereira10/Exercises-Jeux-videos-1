using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        _material.color = Color.Lerp(Color.black, Color.red, (_timer / 5f));


    }
}

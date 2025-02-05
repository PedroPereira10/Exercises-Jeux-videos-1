using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePosition : MonoBehaviour
{
    
    [SerializeField] private Transform _plane;        // Associe le plan dans l'inspecteur
    [SerializeField] private Renderer _sphereRenderer;
    [SerializeField] private float _colorLerpSpeed = 5f; // Contr�le la vitesse de transition des couleurs

    private void Start()
    {
        if (_sphereRenderer == null)
            _sphereRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Direction de la normale du plan (toujours perpendiculaire � sa surface)
        Vector3 planeNormal = _plane.forward;

        // Vecteur entre le plan et la sph�re
        Vector3 toSphere = transform.position - _plane.position;

        // Dot Product pour v�rifier si la sph�re est devant (>0) ou derri�re (<0)
        float dotProduct = Vector3.Dot(planeNormal, toSphere);

        // D�termination de la couleur cible
        Color targetColor = dotProduct > 0 ? Color.green : Color.red;

        // Interpolation de la couleur (transition douce)
        _sphereRenderer.material.color = Color.Lerp(_sphereRenderer.material.color, targetColor, Time.deltaTime * _colorLerpSpeed);
    }
}

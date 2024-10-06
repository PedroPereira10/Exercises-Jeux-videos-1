using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereManager : MonoBehaviour
{
    [SerializeField] GameObject _spherePrefab;
    [SerializeField] Transform _movingObject;
    [SerializeField] float _radius = 5f;
    [SerializeField] float _speed = 2f;
    [SerializeField] Button _removeButton;

    private List<GameObject> _spheres = new List<GameObject>();
    private int _currentSphereIndex = 0;

    void Start()
    {
        
        for (int i = 0; i < 8; i++)
        {
            float angle = i * Mathf.PI * 2 / 8; 
            Vector3 position = new Vector3(Mathf.Cos(angle) * _radius, Mathf.Sin(angle) * _radius, 0);
            GameObject sphere = Instantiate(_spherePrefab, position, Quaternion.identity);
            _spheres.Add(sphere);
        }

        
        _removeButton.onClick.AddListener(RemoveLastSphere);
    }

    void Update()
    {
        
        if (_spheres.Count > 0)
        {
            Transform target = _spheres[_currentSphereIndex].transform;
            _movingObject.position = Vector3.MoveTowards(_movingObject.position, target.position, _speed * Time.deltaTime);

            
            if (Vector3.Distance(_movingObject.position, target.position) < 0.1f)
            {
                _currentSphereIndex = (_currentSphereIndex + 1) % _spheres.Count;
            }
        }
    }

    void RemoveLastSphere()
    {
        if (_spheres.Count > 0)
        {
            
            Destroy(_spheres[_spheres.Count - 1]);
            _spheres.RemoveAt(_spheres.Count - 1);

            
            _currentSphereIndex = _currentSphereIndex % _spheres.Count;
        }
    }
}

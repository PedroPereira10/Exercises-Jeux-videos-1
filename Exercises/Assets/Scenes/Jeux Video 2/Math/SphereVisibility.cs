using UnityEngine;

public class SphereVisibility : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Renderer _sphereRenderer;
    void Start()
    {
        _sphereRenderer = GetComponent<Renderer>();
    }
    void Update()
    {
        Vector3 directionToSphere = (transform.position - _camera.transform.position).normalized;
        float distanceToSphere = Vector3.Distance(_camera.transform.position, transform.position);
        float dotProduct = Vector3.Dot(_camera.transform.forward, directionToSphere);

        Color rayColor = Color.red;

        if (dotProduct > 0)
        {
            Ray ray = new Ray(_camera.transform.position, directionToSphere);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    _sphereRenderer.material.color = Color.green;
                    rayColor = Color.green;
                    Debug.DrawRay(_camera.transform.position, directionToSphere * distanceToSphere, rayColor);
                    return;
                }
                Debug.DrawRay(_camera.transform.position, directionToSphere * distanceToSphere, rayColor);
            }
        }
        _sphereRenderer.material.color = Color.red;
    }
}
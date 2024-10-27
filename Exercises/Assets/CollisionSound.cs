using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider is MeshCollider)
        {
            float impactSpeed = Mathf.Abs(GetComponent<Rigidbody>().velocity.y);

            audioSource.volume = Mathf.Clamp(impactSpeed / 10f, 0.1f, 1f);

            audioSource.Play();
        }
    }
}

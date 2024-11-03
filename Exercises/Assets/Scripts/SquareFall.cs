using System.Collections;
using UnityEngine;

public class SquareFall : MonoBehaviour
{
    public float fallSpeed = 2f; // Vitesse de chute
    public float colorChangeThreshold = -5f; // Niveau de l’écran pour changer de couleur

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(CheckPosition());
    }

    private void Update()
    {
        // Le carré tombe constamment
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private IEnumerator CheckPosition()
    {
        // Attend que la position Y soit en-dessous du seuil
        yield return new WaitUntil(() => transform.position.y < colorChangeThreshold);
        // Change la couleur une fois que le carré est en-dessous du seuil
        spriteRenderer.color = Color.red;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public float _rayOffset = 0.5f; // Décalage du raycast par rapport aux pieds du personnage
    public float _rayCastLenght = 0.5f; // Longueur du raycast
    public LayerMask _layerMask; // La couche du sol
    public float jumpForce = 5f; // La force du saut
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Définir l'origine et la direction du Raycast
        Vector2 origine = (Vector2)transform.position + new Vector2(0, -_rayOffset);
        Vector2 direction = Vector2.down;

        // Effectuer le Raycast
        RaycastHit2D hit = Physics2D.Raycast(origine, direction, _rayCastLenght, _layerMask);

        // Dessiner le Raycast pour le débogage (visible dans la vue Scene)
        Debug.DrawLine(origine, origine + direction * _rayCastLenght, Color.red);

        // Vérifier si le Raycast touche le sol
        isGrounded = hit.collider != null;

        // Afficher un message de débogage si le Raycast touche quelque chose
        if (isGrounded)
        {
            string objectName = hit.collider.gameObject.name;

            if (objectName == "Base")
            {
                Debug.Log("Touched the: " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("Rien touché");
        }

        // Si le personnage est au sol, permettre le saut
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}

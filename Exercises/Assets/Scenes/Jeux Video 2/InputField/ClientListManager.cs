using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Assure-toi d'importer le namespace TextMeshPro

public class ClientListManager : MonoBehaviour
{
    [SerializeField] public InputField _clientNameInput; // Référence à l'InputField
    [SerializeField] public Transform _clientListContainer; // Conteneur pour les entrées de la liste
    [SerializeField] public GameObject _clientNamePrefab; // Prefab d'une entrée de client (nommé ClientName)
    [SerializeField] public Vector2 _preferredSize = new Vector2(200, 50); // Taille préférée des entrées de la liste

    private List<GameObject> clientEntries = new List<GameObject>();

    public void AddClient()
    {
        Debug.Log("AddClient function called."); // Débogage

        string clientName = _clientNameInput.text;
        if (!string.IsNullOrEmpty(clientName))
        {
            Debug.Log($"Client name entered: {clientName}"); // Débogage

            GameObject clientEntry = Instantiate(_clientNamePrefab, _clientListContainer);
            clientEntry.transform.SetParent(_clientListContainer, false);

            // Configurer les informations du client
            TextMeshProUGUI clientNameText = clientEntry.transform.Find("ClientNameText").GetComponent<TextMeshProUGUI>();
            if (clientNameText != null)
            {
                Debug.Log("ClientNameText found."); // Débogage
                clientNameText.text = clientName;
            }
            else
            {
                Debug.LogError("ClientNameText not found."); // Débogage
            }

            // Ajouter une image de client (par exemple une icône)
            Image clientImage = clientEntry.transform.Find("ClientImage").GetComponent<Image>();
            if (clientImage != null)
            {
                Debug.Log("ClientImage found."); // Débogage
                clientImage.color = Random.ColorHSV(); // Couleur aléatoire
            }
            else
            {
                Debug.LogError("ClientImage not found."); // Débogage
            }

            // Configurer le bouton de suppression
            Button deleteButton = clientEntry.transform.Find("DeleteButton").GetComponent<Button>();
            if (deleteButton != null)
            {
                Debug.Log("DeleteButton found."); // Débogage
                deleteButton.onClick.AddListener(() => RemoveClient(clientEntry));

                // Chercher le texte du bouton s'il utilise TextMeshProUGUI
                TextMeshProUGUI buttonText = deleteButton.transform.Find("DeleteButtonText").GetComponent<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    Debug.Log("DeleteButton Text found."); // Débogage
                }
                else
                {
                    Debug.LogError("DeleteButton Text not found."); // Débogage
                }
            }
            else
            {
                Debug.LogError("DeleteButton not found."); // Débogage
            }

            // Ajuster la taille de l'entrée
            RectTransform entryRect = clientEntry.GetComponent<RectTransform>();
            if (entryRect != null)
            {
                entryRect.sizeDelta = _preferredSize;
            }

            // Ajouter à la liste
            clientEntries.Add(clientEntry);
            _clientNameInput.text = ""; // Effacer le champ InputField après ajout

            // Mettre à jour le layout pour s'assurer que tous les éléments s'ajustent correctement
            LayoutRebuilder.ForceRebuildLayoutImmediate(_clientListContainer.GetComponent<RectTransform>());
        }
        else
        {
            Debug.LogWarning("Client name is empty."); // Débogage
        }
    }

    public void RemoveClient(GameObject clientEntry)
    {
        clientEntries.Remove(clientEntry);
        Destroy(clientEntry);

        // Mettre à jour le layout après suppression d'un élément
        LayoutRebuilder.ForceRebuildLayoutImmediate(_clientListContainer.GetComponent<RectTransform>());
    }
}

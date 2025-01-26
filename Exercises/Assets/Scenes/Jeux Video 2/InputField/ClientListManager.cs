using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Assure-toi d'importer le namespace TextMeshPro

public class ClientListManager : MonoBehaviour
{
    [SerializeField] public InputField _clientNameInput; // R�f�rence � l'InputField
    [SerializeField] public Transform _clientListContainer; // Conteneur pour les entr�es de la liste
    [SerializeField] public GameObject _clientNamePrefab; // Prefab d'une entr�e de client (nomm� ClientName)
    [SerializeField] public Vector2 _preferredSize = new Vector2(200, 50); // Taille pr�f�r�e des entr�es de la liste

    private List<GameObject> clientEntries = new List<GameObject>();

    public void AddClient()
    {
        Debug.Log("AddClient function called."); // D�bogage

        string clientName = _clientNameInput.text;
        if (!string.IsNullOrEmpty(clientName))
        {
            Debug.Log($"Client name entered: {clientName}"); // D�bogage

            GameObject clientEntry = Instantiate(_clientNamePrefab, _clientListContainer);
            clientEntry.transform.SetParent(_clientListContainer, false);

            // Configurer les informations du client
            TextMeshProUGUI clientNameText = clientEntry.transform.Find("ClientNameText").GetComponent<TextMeshProUGUI>();
            if (clientNameText != null)
            {
                Debug.Log("ClientNameText found."); // D�bogage
                clientNameText.text = clientName;
            }
            else
            {
                Debug.LogError("ClientNameText not found."); // D�bogage
            }

            // Ajouter une image de client (par exemple une ic�ne)
            Image clientImage = clientEntry.transform.Find("ClientImage").GetComponent<Image>();
            if (clientImage != null)
            {
                Debug.Log("ClientImage found."); // D�bogage
                clientImage.color = Random.ColorHSV(); // Couleur al�atoire
            }
            else
            {
                Debug.LogError("ClientImage not found."); // D�bogage
            }

            // Configurer le bouton de suppression
            Button deleteButton = clientEntry.transform.Find("DeleteButton").GetComponent<Button>();
            if (deleteButton != null)
            {
                Debug.Log("DeleteButton found."); // D�bogage
                deleteButton.onClick.AddListener(() => RemoveClient(clientEntry));

                // Chercher le texte du bouton s'il utilise TextMeshProUGUI
                TextMeshProUGUI buttonText = deleteButton.transform.Find("DeleteButtonText").GetComponent<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    Debug.Log("DeleteButton Text found."); // D�bogage
                }
                else
                {
                    Debug.LogError("DeleteButton Text not found."); // D�bogage
                }
            }
            else
            {
                Debug.LogError("DeleteButton not found."); // D�bogage
            }

            // Ajuster la taille de l'entr�e
            RectTransform entryRect = clientEntry.GetComponent<RectTransform>();
            if (entryRect != null)
            {
                entryRect.sizeDelta = _preferredSize;
            }

            // Ajouter � la liste
            clientEntries.Add(clientEntry);
            _clientNameInput.text = ""; // Effacer le champ InputField apr�s ajout

            // Mettre � jour le layout pour s'assurer que tous les �l�ments s'ajustent correctement
            LayoutRebuilder.ForceRebuildLayoutImmediate(_clientListContainer.GetComponent<RectTransform>());
        }
        else
        {
            Debug.LogWarning("Client name is empty."); // D�bogage
        }
    }

    public void RemoveClient(GameObject clientEntry)
    {
        clientEntries.Remove(clientEntry);
        Destroy(clientEntry);

        // Mettre � jour le layout apr�s suppression d'un �l�ment
        LayoutRebuilder.ForceRebuildLayoutImmediate(_clientListContainer.GetComponent<RectTransform>());
    }
}

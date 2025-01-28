using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClientListManager : MonoBehaviour
{
    [SerializeField] private InputField _clientNameInput;
    [SerializeField] private Transform _clientListContainer;
    [SerializeField] private GameObject _clientNamePrefab;
    [SerializeField] private float _clientNameHeight = 30f; // Altura da caixa de texto do nome do cliente

    private List<GameObject> clientEntries = new List<GameObject>();

    public void AddClient()
    {
        Debug.Log("AddClient function called.");

        string clientName = _clientNameInput.text;
        if (!string.IsNullOrEmpty(clientName))
        {
            Debug.Log($"Client name entered: {clientName}");

            GameObject clientEntry = Instantiate(_clientNamePrefab, _clientListContainer);
            clientEntry.transform.SetParent(_clientListContainer, false);

            TextMeshProUGUI clientNameText = clientEntry.transform.Find("ClientNameText").GetComponent<TextMeshProUGUI>();
            if (clientNameText != null)
            {
                Debug.Log("ClientNameText found.");
                clientNameText.text = clientName;

                // Ajustar a altura da caixa de texto do nome do cliente
                RectTransform clientNameRect = clientNameText.GetComponent<RectTransform>();
                if (clientNameRect != null)
                {
                    Vector2 originalSize = clientNameRect.sizeDelta;
                    clientNameRect.sizeDelta = new Vector2(originalSize.x, _clientNameHeight);
                }
            }
            else
            {
                Debug.LogError("ClientNameText not found.");
            }

            Image clientImage = clientEntry.transform.Find("ClientImage").GetComponent<Image>();
            if (clientImage != null)
            {
                Debug.Log("ClientImage found.");
                clientImage.color = Random.ColorHSV();
            }
            else
            {
                Debug.LogError("ClientImage not found.");
            }

            Button deleteButton = clientEntry.transform.Find("DeleteButton").GetComponent<Button>();
            if (deleteButton != null)
            {
                Debug.Log("DeleteButton found.");
                deleteButton.onClick.AddListener(() => RemoveClient(clientEntry));

                TextMeshProUGUI buttonText = deleteButton.transform.Find("DeleteButtonText").GetComponent<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    Debug.Log("DeleteButton Text found.");
                }
                else
                {
                    Debug.LogError("DeleteButton Text not found.");
                }
            }
            else
            {
                Debug.LogError("DeleteButton not found.");
            }

            RectTransform entryRect = clientEntry.GetComponent<RectTransform>();
            if (entryRect != null)
            {
                Vector2 originalSize = entryRect.sizeDelta;
                entryRect.sizeDelta = new Vector2(originalSize.x, _clientNameHeight); // Ajuste da altura do clientEntry
            }

            clientEntries.Add(clientEntry);
            _clientNameInput.text = "";

            LayoutRebuilder.ForceRebuildLayoutImmediate(_clientListContainer.GetComponent<RectTransform>());
        }
        else
        {
            Debug.LogWarning("Client name is empty.");
        }
    }

    public void RemoveClient(GameObject clientEntry)
    {
        clientEntries.Remove(clientEntry);
        Destroy(clientEntry);

        LayoutRebuilder.ForceRebuildLayoutImmediate(_clientListContainer.GetComponent<RectTransform>());
    }
}

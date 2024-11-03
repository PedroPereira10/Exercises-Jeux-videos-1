using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SquareSpawner : MonoBehaviour
{
    public GameObject squarePrefab; // Le prefab du carr� blanc
    public Transform spawnPoint; // Point de d�part pour l�instanciation des carr�s
    public float spawnInterval = 1f; // Intervalle d�apparition

    private Coroutine spawnCoroutine;

    // R�f�rences aux boutons
    public Button startButton;
    public Button stopButton;

    private void Start()
    {
        // Assigne les fonctions aux boutons
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartSpawning);
        }
        if (stopButton != null)
        {
            stopButton.onClick.AddListener(StopSpawning);
        }
    }

    public void StartSpawning()
    {
        // Si la coroutine est d�j� en cours, arr�te-la d'abord
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        // D�marre une nouvelle coroutine pour l�instanciation
        spawnCoroutine = StartCoroutine(SpawnSquares());
    }

    public void StopSpawning()
    {
        // Arr�te la coroutine si elle est en cours
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    private IEnumerator SpawnSquares()
    {
        while (true)
        {
            GameObject square = Instantiate(squarePrefab, spawnPoint.position, Quaternion.identity);
            square.AddComponent<SquareFall>(); // Ajoute le script pour g�rer la couleur du carr�
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}


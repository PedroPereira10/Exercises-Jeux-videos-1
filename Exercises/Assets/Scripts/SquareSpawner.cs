using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SquareSpawner : MonoBehaviour
{
    public GameObject squarePrefab; // Le prefab du carré blanc
    public Transform spawnPoint; // Point de départ pour l’instanciation des carrés
    public float spawnInterval = 1f; // Intervalle d’apparition

    private Coroutine spawnCoroutine;

    // Références aux boutons
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
        // Si la coroutine est déjà en cours, arrête-la d'abord
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
        // Démarre une nouvelle coroutine pour l’instanciation
        spawnCoroutine = StartCoroutine(SpawnSquares());
    }

    public void StopSpawning()
    {
        // Arrête la coroutine si elle est en cours
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
            square.AddComponent<SquareFall>(); // Ajoute le script pour gérer la couleur du carré
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}


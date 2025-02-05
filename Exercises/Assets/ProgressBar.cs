using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    private float fillAmount = 0f;

    private void OnEnable()
    {
        Trigger._OnCubePressed += IncreaseProgress;
    }

    private void OnDisable()
    {
        Trigger._OnCubePressed -= IncreaseProgress;
    }

    private void IncreaseProgress()
    {
        if (_progressBar == null)
        {
            Debug.LogError("ProgressBar reference is not set!");
            return;
        }

        fillAmount += 0.1f; // Incrementando 10% (0.1 no sistema de 0 a 1)
        if (fillAmount > 1f) fillAmount = 1f; // Limita o valor máximo a 1 (100%)

        _progressBar.fillAmount = fillAmount;

        Debug.Log("Progress increased to: " + (fillAmount * 100) + "%"); // Mostra a porcentagem correta
    }
}

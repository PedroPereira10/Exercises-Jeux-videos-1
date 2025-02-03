using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    private float fillAmount = 0;

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
        fillAmount += 1f; 
        if (fillAmount > 1) fillAmount = 1; 
        progressBar.fillAmount = fillAmount;
    }
}

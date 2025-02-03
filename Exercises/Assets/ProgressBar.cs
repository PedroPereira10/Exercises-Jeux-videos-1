using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
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
        if (_progressBar == null)
        {
            Debug.LogError("ProgressBar reference is not set!");
            return;
        }

        fillAmount += 0.1f; 
        if (fillAmount > 1) fillAmount = 1; 
        _progressBar.fillAmount = fillAmount;

        Debug.Log("Progress increased to: " + fillAmount); 
    }
}
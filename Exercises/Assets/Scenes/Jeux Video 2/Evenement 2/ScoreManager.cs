using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Image _progressBar; 
    [SerializeField] private int maxScore = 10;  

    private void OnEnable()
    {
        Trigger._OnCubePressed += IncrementScore;
    }

    private void OnDisable()
    {
        Trigger._OnCubePressed -= IncrementScore;
    }

    private void IncrementScore()
    {
        score++;
        _scoreText.text = score.ToString();

        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        if (_progressBar == null)
        {
            Debug.LogError("ProgressBar reference is not set!");
            return;
        }

        
        float progress = (float)score / maxScore;
        progress = Mathf.Clamp01(progress); 

        _progressBar.fillAmount = progress;

        Debug.Log("Progresso: " + (progress * 100) + "%");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text _scoreText;

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
        _scoreText.text = "" + score.ToString();
    }
}


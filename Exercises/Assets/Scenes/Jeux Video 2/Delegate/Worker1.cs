using UnityEngine;
using UnityEngine.UI;
using System;

public class Worker1 : MonoBehaviour
{
    public enum WorkType { Miner, Lumberjack, Farmer }
    public WorkType _currentWorkType;
    public Button _workButton;

    private delegate void WorkDelegate();
    private WorkDelegate _workDelegate;

    void Start()
    {
        if (_workButton != null)
        {
            _workButton.onClick.AddListener(() => Work1());

        }
    }

    public void Work1()
    {
        // Désabonner toutes les fonctions
        _workDelegate = null;

        // Abonner la bonne fonction en fonction du type de travail
        switch (_currentWorkType)
        {
            case WorkType.Miner:
                _workDelegate = Mining;
                break;
            case WorkType.Lumberjack:
                _workDelegate = Lumbering;
                break;
            case WorkType.Farmer:
                _workDelegate = Farming;
                break;
        }

        // Appeler la fonction correspondante via le delegate
        _workDelegate?.Invoke();
    }

    private void Mining()
    {
        Debug.Log(" Woker is Mining");
    }

    private void Lumbering()
    {
        Debug.Log("Woker is Lumbering");
    }

    private void Farming()
    {
        Debug.Log("Woker is Farming");
    }
}

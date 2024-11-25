using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField] private TextMeshProUGUI _text;

    private int _numberOfObject;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance == this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(this);
    }

    public void IncreaseNbOfObject()
    {
        _numberOfObject++;
        UpdateDisplay();
    }

    public void DecreaseNbOfObject()
    {
        _numberOfObject--;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _text.text = _numberOfObject.ToString();
    }
}

using TMPro;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _nameTxt;
    [SerializeField] private TextMeshProUGUI _dateTxt;

    private SaveLoadJSON _saveLoadJSON;

    public void UpdateSaveSlot(string name, string date,SaveLoadJSON saveloadJSON)
    {
        _nameTxt.text = name;
        _dateTxt.text = date;
        _saveLoadJSON = saveloadJSON;
    }

    public void Load()
    {
        
    }

    public void Delete()
    {

    }
}

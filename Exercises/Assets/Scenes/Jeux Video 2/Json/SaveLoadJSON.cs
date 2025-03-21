using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerData
{
    public string _name;
    public string _time;
    public string _gold;
    public Vector3 _position;
    public List<Ressource> _ressourceList;
}

[Serializable]
public class Ressource
{
    public string _name;
    public int _value;
}

public class SaveLoadJSON : MonoBehaviour
{

    [SerializeField] private PlayerData _currentData = new();
    [SerializeField] private TMP_InputField _InputField;
    [SerializeField] private SaveSlot _saveSlotPrefab;
    [SerializeField] private Transform _verticalLayoutGroup;

    void Start()
    {
        LoadAllPreviousSavedSlot();

    }

     private void LoadAllPreviousSavedSlot()
    {
        if (Directory.Exists(Application.persistentDataPath))
        {
            Debug.Log("Directory exist: " + Application.persistentDataPath);
            string folderPath = Application.persistentDataPath;
            DirectoryInfo d = new DirectoryInfo(folderPath);
            var files = d.GetFiles("*.json");

            Debug.Log("All files found: " + files.Length);

            foreach (var file in files)
            {
                Debug.Log("File found:" + file.Name);
                PlayerData data = LoadFromJson(Application.persistentDataPath + "/" + file.Name);
                CreateSaveSlot(data._name, data._time);
            }
        }
        else
        {
            Debug.Log("Directory doesn't exist: " + Application.persistentDataPath);
        }
    }

    public void CreateNewSave()
    {
        _currentData._time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _currentData._name = _InputField.text;
        CreateSaveSlot(_currentData._name, _currentData._time);
        SaveCurrentPlayerData();
    }

    public void CreateSaveSlot(string name, string time)
    {
        SaveSlot newSaveSLot = Instantiate(_saveSlotPrefab);
        newSaveSLot.UpdateSaveSlot(name, time, this);
        newSaveSLot.transform.SetParent(_verticalLayoutGroup);
        newSaveSLot.transform.SetSiblingIndex(transform.childCount - 2);
    }

    public void SaveCurrentPlayerData()
    {
        string savePlayerData = JsonUtility.ToJson(_currentData);
        File.WriteAllText(Application.persistentDataPath + $"/{_currentData._name}.json", savePlayerData);
        Debug.Log("Save File created at:" + Application.persistentDataPath + $"{_currentData._name}.json");
    }

    public PlayerData LoadFromJson(string adress)
    {
        Debug.Log($"Loading at {adress}");
        if (File.Exists(adress))
        {
            string playerData = File.ReadAllText(adress);
            _currentData = JsonUtility.FromJson<PlayerData>(playerData);
            return _currentData;
        }
        else
        {
            Debug.Log($"File not found at {adress}");
            return null;
        }
    }

    public void DeleteSavefile(string name)
    {
        if(File.Exists(Application.persistentDataPath + $"/{name}.json"))
        {
            File.Delete(Application.persistentDataPath + $"/{name}.json");
        }
        else
        {
            Debug.Log("File to delete not found");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZoneTool : MonoBehaviour
{
    public int _zoneIndex;

    [SerializeField] private List<List<Vector3>> _listOfPoints = new List<List<Vector3>>();
    [SerializeField] private float _collapsePointRange = 1f;
    
    private List<Vector3> _currentList;
    public void CreateNewZone()
    {
        _currentList = new List<Vector3>();
        _listOfPoints.Add(_currentList);
        _zoneIndex = _listOfPoints.Count - 1;
    }

    public void NextZone()
    {
        _zoneIndex++;

        if (_zoneIndex >= _listOfPoints.Count)
        {
            _zoneIndex = 0;
        }

        _currentList = _listOfPoints[_zoneIndex];
    }

    public void SetDirty()
    {
        EditorUtility.SetDirty(this);
    }

    public void PrevZone()
    {
        _zoneIndex--;

        if (_zoneIndex < 0)
        {
            _zoneIndex = _listOfPoints.Count - 1;
        }

        _currentList = _listOfPoints[_zoneIndex];
    }
    public void AddPointToZone(Vector3 point)
    {

        Vector3 positionToAdd = point;

        foreach(Vector3 pointToCheck in _currentList)
        {
            if((point-pointToCheck).magnitude <= _collapsePointRange)
            {
                positionToAdd = point;
                break;
            }
        }

        _currentList.Add(positionToAdd);
    }

    public void ClearCurrentZone()
    {
        _listOfPoints.Remove(_currentList);
        _currentList.Clear();
    }

    public List<List<Vector3>> GetAllZone()
    {
        return _listOfPoints;
    }

    public int GetCurrentZoneIndex()
    { 
        return _zoneIndex;
    }
}
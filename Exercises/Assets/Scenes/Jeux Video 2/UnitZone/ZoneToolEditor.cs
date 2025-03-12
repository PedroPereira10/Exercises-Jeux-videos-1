using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ZoneTool))]

public class ZoneToolEditor : Editor
{

    private ZoneTool _zoneTool;


    private void OnEnable()
    {
        _zoneTool = (ZoneTool)target;
        SceneView view = SceneView.lastActiveSceneView;
        

        if (view != null )
        {
            view.in2DMode = true;
            view.orthographic = true;
        }

        SceneView.lastActiveSceneView.size = 45;
    }

    private void OnDisable()
    {
        SceneView view = SceneView.lastActiveSceneView;
        view.in2DMode = false;

        if (view != null)
        {
            view.orthographic = false;
        }
        HandleUtility.AddDefaultControl(EditorGUIUtility.GetControlID(FocusType.Keyboard));
    }

    private void OnSceneGUI()
    {
        List<List<Vector3>> list = _zoneTool.GetAllZone();
        HandleUtility.AddDefaultControl(EditorGUIUtility.GetControlID(FocusType.Passive));
        Vector3 Pos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
        Vector3 MouseWorldPos = new Vector3(Pos.x, Pos.y, 0);

        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            _zoneTool.AddPointToZone(MouseWorldPos);
            _zoneTool.SetDirty();
        }

        DrawAllZone(list);
    }

    private void DrawAllZone(List<List<Vector3>> pointlist)
    {
        for (int j = 0; j < pointlist.Count; j++)
        {
            List<Vector3> zone = pointlist[j];

            for (int i = 0; i < zone.Count - 1; i++)
            {
                DrawLineBetweenNod(zone[i], zone[i + 1], _zoneTool.GetCurrentZoneIndex()==j);
            }
        }
    }

    private void DrawLineBetweenNod(Vector3 pos1, Vector3 pos2, bool isCurrentZone)
    {
        if (isCurrentZone)
        {
            Handles.DrawBezier(pos1,pos2,pos1,pos2,Color.blue,null,20);
        }
        else
        {
            Handles.DrawBezier(pos1, pos2, pos1, pos2, Color.blue, null, 5);

        }
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        Color basicColor = GUI.color;
        GUILayout.BeginVertical();
        GUI.color = Color.red;

        if (_zoneTool.GetAllZone().Count > 0)
        {
            if(GUILayout.Button("Clear Current Zone"))
            {
                _zoneTool.ClearCurrentZone();
            }
        }

        GUI.color = Color.green;

        if (GUILayout.Button("Create a new zone"))
        {
            _zoneTool.CreateNewZone();
        }

        GUI.color = basicColor;

        if (GUILayout.Button("Next Zone"))
        {
            _zoneTool.NextZone();
        }

        GUI.color = basicColor;

        if (GUILayout.Button("Prev Zone"))
        {
            _zoneTool.PrevZone();
        }

        GUILayout.BeginHorizontal();
        GUILayout.TextField("Left Mouse Click", GUILayout.Width(150));
        GUILayout.TextField("-> Add point", GUILayout.Width(150));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.TextField("Arrow Key", GUILayout.Width(150));
        GUILayout.TextField("-> Move Around Sene Camera", GUILayout.Width(150));
        GUILayout.EndHorizontal();

        int newValue = EditorGUILayout.IntField(_zoneTool._zoneIndex, GUILayout.Width(150));
        _zoneTool._zoneIndex = newValue;

        GUILayout.EndVertical();

        DrawDefaultInspector();

    }
}

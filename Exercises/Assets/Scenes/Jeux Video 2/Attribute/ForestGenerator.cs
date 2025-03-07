using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Tree
{
    public float radius = 1f; // Scale X, Z
    public float height = 2f; // Scale Y
}

public class ForestGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("List of trees with editable parameters")]
    private List<Tree> treeList = new List<Tree>();

    [SerializeField] private GameObject treePrefab;
    [SerializeField, Range(1, 5)] private float forestRange = 5f;
    private List<GameObject> spawnedTrees = new List<GameObject>();

    public void AddTrees()
    {
        if (treePrefab == null) return;
        DestroyAllTrees();

        foreach (var tree in treeList)
        {
            Vector3 position = new Vector3(
                Random.Range(-forestRange, forestRange),
                transform.position.y + 0.5f,  // Ajuste la hauteur pour éviter qu’ils soient sous le sol
                Random.Range(-forestRange, forestRange)
            ) + transform.position;

            GameObject newTree = Instantiate(treePrefab, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            newTree.transform.localScale = new Vector3(tree.radius, tree.height, tree.radius);
            spawnedTrees.Add(newTree);

            Debug.Log("Tree Scale: " + tree.radius + ", " + tree.height);
            newTree.transform.localScale = new Vector3(Mathf.Max(tree.radius, 0.5f), Mathf.Max(tree.height, 1f), Mathf.Max(tree.radius, 0.5f));

        }
    }

    public void DestroyAllTrees()
    {
        foreach (var tree in spawnedTrees)
        {
            DestroyImmediate(tree);
        }
        spawnedTrees.Clear();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ForestGenerator))]
public class ForestGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ForestGenerator generator = (ForestGenerator)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("treePrefab"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("forestRange"));

        SerializedProperty treeList = serializedObject.FindProperty("treeList");
        EditorGUILayout.PropertyField(treeList, new GUIContent("Tree List", "Editable list of trees"), true);

        if (GUILayout.Button("Add Trees"))
        {
            generator.AddTrees();
        }
        if (GUILayout.Button("Destroy All Trees"))
        {
            generator.DestroyAllTrees();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif

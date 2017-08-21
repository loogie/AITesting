using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIComponent))]
public class AIControllerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AIComponent myComponent = (AIComponent)target;
    }
}
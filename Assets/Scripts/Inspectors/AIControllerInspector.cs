using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIComponent))]
public class AIControllerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AIComponent myComponent = (AIComponent)target;
        if (GUILayout.Button("Move To Work"))
        {
            myComponent.MoveTo("WorkArea");
        }

        if (GUILayout.Button("Move To Rest"))
        {
            myComponent.MoveTo("RestArea");
        }

        if (GUILayout.Button("Abort Action"))
        {
            myComponent.AbortAction();
        }

        if (GUILayout.Button("Add Work Desire"))
        {
            myComponent.AddDesire("work", 0.1f);
        }

        if (GUILayout.Button("remove Work Desire"))
        {
            myComponent.AddDesire("work", -0.1f);
        }
    }
}
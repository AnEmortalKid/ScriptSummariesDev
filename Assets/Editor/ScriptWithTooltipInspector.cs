using Snoutical.ScriptSummaries.API;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TooltipableScript))]
public class ScriptWithTooltipInspector : Editor
{
    public override void OnInspectorGUI()
    {
        MonoBehaviour targetScript = (MonoBehaviour)target;
        string summary = ScriptSummaries.GetSummary(targetScript);

        EditorGUILayout.HelpBox("This uses the runtime api conditionally", MessageType.None);
        // If the script has a summary, display it as a tooltip at the top
        if (!string.IsNullOrEmpty(summary))
        {
            EditorGUILayout.HelpBox(summary, MessageType.Info);
        }

        // Draw default Inspector UI
        DrawDefaultInspector();
    }
}
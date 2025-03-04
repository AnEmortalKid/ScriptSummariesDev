using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

namespace Snoutical.ScriptSummaries.Setup.Debugging
{
    public class ScriptSummariesDebugMenu
    {
        private const string DefineSymbol = "SCRIPT_SUMMARIES_INSTALLED";
        private const string MenuPath = "Tools/Script Summaries/Debug/Toggle Installed Define";

        [MenuItem(MenuPath)]
        private static void ToggleScriptSummariesDefine()
        {
            string defines = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.Standalone);

            if (defines.Contains(DefineSymbol))
            {
                // ✅ Remove define
                defines = defines.Replace(DefineSymbol, "").Replace(";;", ";").Trim(';');
                Debug.Log("❌ Removed " + DefineSymbol);
            }
            else
            {
                // ✅ Add define
                defines = string.IsNullOrEmpty(defines) ? DefineSymbol : defines + ";" + DefineSymbol;
                Debug.Log("✅ Added " + DefineSymbol);
            }

            // Apply the new define symbols
            PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, defines);
            AssetDatabase.Refresh();
        }

        [MenuItem(MenuPath, true)]
        private static bool ValidateMenu()
        {
            string defines =
                PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.Standalone);
            Menu.SetChecked(MenuPath, defines.Contains(DefineSymbol));
            return true;
        }
    }
}
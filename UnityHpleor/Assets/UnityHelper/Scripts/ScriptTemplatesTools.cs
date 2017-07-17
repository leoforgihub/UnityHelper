using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityHelper
{
    public class ScriptTemplatesTools : MonoBehaviour
    {

#if UNITY_EDITOR
        [MenuItem("UnityHelper/Script/C# ")]
        public static void CreateCScript()
        {
            string prjPath = Application.dataPath + "/";

            string from = "ScriptTemplates/81-C# Script-NewBehaviourScript.cs.txt";
            string to = "NewBehaviourScript.cs";

            FileUtil.CopyFileOrDirectory(prjPath+from, prjPath+to);

            AssetDatabase.Refresh();
        }

        [MenuItem("UnityHelper/Script/JS ")]
        public static void CreateJSScript()
        {
            string prjPath = Application.dataPath + "/";
            
            string from = "ScriptTemplates/82-Javascript-NewBehaviourScript.js";
            string to = "NewBehaviourScript.js";
            
            FileUtil.CopyFileOrDirectory(prjPath + from, prjPath + to);
            
            AssetDatabase.Refresh();
        }

#endif

    }
}


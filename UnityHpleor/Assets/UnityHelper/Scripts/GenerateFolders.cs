using UnityEngine;
using System.Collections;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityHelper
{

    public class GenerateFolders : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("UnityHelper/Folder/CreateBasicFolder #&_b")]
        private static void CreateBasicFolder()
        {
            GenerateFolder();
            Debug.Log("Folders Created");
        }

        [MenuItem("UnityHelper/Folder/CreateALLFolder")]
        private static void CreateAllFolder()
        {
            GenerateFolder(1);
            Debug.Log("Folders Created");
        }

        [MenuItem("UnityHelper/Folder/CreateFile")]
        private static void CreateFile()
        {
            string prjPath = Application.dataPath + "/";

            string fileName = "NewText";

            int num = 0;

            while (true)
            {
                string temp = fileName + num +".txt";

                if (!File.Exists(prjPath + temp))
                {
                    File.Create(prjPath + temp).Close();
                    break;
                }
                else
                {
                    num++;
                }
            }

            AssetDatabase.Refresh();

        }

        private static void GenerateFolder(int flag = 0)
        {
            // 文件路径
            string prjPath = Application.dataPath + "/";
            Directory.CreateDirectory(prjPath + "Audio");
            Directory.CreateDirectory(prjPath + "Prefabs");
            Directory.CreateDirectory(prjPath + "Materials");
            Directory.CreateDirectory(prjPath + "Resources");
            Directory.CreateDirectory(prjPath + "Scripts");
            Directory.CreateDirectory(prjPath + "Textures");
            Directory.CreateDirectory(prjPath + "Scenes");
            Directory.CreateDirectory(prjPath + "Fonts");
            if (1 == flag)
            {
                Directory.CreateDirectory(prjPath + "Meshes");
                Directory.CreateDirectory(prjPath + "Shaders");
                Directory.CreateDirectory(prjPath + "GUI");
                Directory.CreateDirectory(prjPath + "Plugins");
                Directory.CreateDirectory(prjPath + "StreamingAssets");
                Directory.CreateDirectory(prjPath + "Editor");
            }

            AssetDatabase.Refresh();
        }


#endif


    }
}


using UnityEditor;
using UnityEngine;
using System.IO;

namespace UnityHelper
{
    public class AddFileHeadComment : UnityEditor.AssetModificationProcessor
    {
        /// <summary>  
        /// �˺�����asset�������꣬�ļ��Ѿ����ɵ������ϣ�����û������.meta�ļ���import֮ǰ������  
        /// </summary>  
        /// <param name="newFileMeta">newfilemeta ���ɴ����ļ���path����.meta��ɵ�</param>  
        public static void OnWillCreateAsset(string newFileMeta)
        {
            string newFilePath = newFileMeta.Replace(".meta", "");
            string fileExt = Path.GetExtension(newFilePath);
            if (fileExt != ".cs")
            {
                return;
            }
            //ע�⣬Application.datapath�����ʹ��ƽ̨��ͬ����ͬ  
            string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
            string scriptContent = File.ReadAllText(realPath);

            //����ʵ���Զ����һЩ����  
            scriptContent = scriptContent.Replace("#SCRIPTFULLNAME#", Path.GetFileName(newFilePath));
            scriptContent = scriptContent.Replace("#COMPANY#", PlayerSettings.companyName);
            scriptContent = scriptContent.Replace("#AUTHOR#", "Passion");
            scriptContent = scriptContent.Replace("#VERSION#", "1.0");
            scriptContent = scriptContent.Replace("#UNITYVERSION#", Application.unityVersion);
            scriptContent = scriptContent.Replace("#DATE#", System.DateTime.Now.ToString("yyyy-MM-dd"));

            File.WriteAllText(realPath, scriptContent);
        }

    }

}


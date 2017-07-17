using UnityEngine;
using System.Collections;

namespace  UnityHelper
{
    //路径工具类
    public class PathKit
    {

        /** 后缀常量字符 */
        public const string SUFFIX = ".txt";
        const string PREFIX = "file://";
        const string FORMAT = ".unity3d";
        public static string RESROOT = Application.persistentDataPath + "/";

        public static string GetStreamingAssetsPath(string p_filename)
        {
            string _strPath = "";
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                _strPath = "file://" + Application.streamingAssetsPath + "/" + p_filename + ".unity3d";
            else if (Application.platform == RuntimePlatform.Android)
                _strPath = Application.streamingAssetsPath + "/" + p_filename + ".unity3d";
            else if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.IPhonePlayer)
                _strPath = "file://" + Application.streamingAssetsPath + "/" + p_filename + ".unity3d";

            return _strPath;
        }



        public static string GetOSDataPath(string p_filename)
        {
            string path;
            path = "";

            if (Application.platform == RuntimePlatform.OSXEditor)
                path = Application.persistentDataPath + p_filename;

            if (Application.platform == RuntimePlatform.IPhonePlayer)
                path = RESROOT + p_filename;


            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
                path = Application.dataPath + "/cache/" + p_filename;


            if (Application.platform == RuntimePlatform.Android)
                path = RESROOT + p_filename;

            //    Debug.LogWarning("===========path:"+path);
            return path;
        }

        public static string GetURLPath(string p_filename, bool needPreFix, bool needFormat)
        {
            string path;
            path = "";

            if (Application.platform == RuntimePlatform.OSXEditor)
                path = Application.persistentDataPath + "/" + p_filename;

            if (Application.platform == RuntimePlatform.IPhonePlayer)
                path = RESROOT + p_filename;


            if (Application.platform == RuntimePlatform.WindowsEditor)
                path = Application.dataPath + "/cache/" + p_filename;

            if (Application.platform == RuntimePlatform.WindowsPlayer)
                path = Application.dataPath + "/cache/" + p_filename;

            if (Application.platform == RuntimePlatform.Android)
                path = RESROOT + p_filename;

            if (needPreFix) path = PREFIX + path;
            if (needFormat) path = path + FORMAT;
            //Debug.LogWarning("===========path:"+path);
            return path;
        }

        public static string getFileName(string path)
        {

            string[] _list = path.Split(new char[] { '/' });



            if (_list.Length > 0) return _list[_list.Length - 1];
            else
                return "";

        }

        public static string getFileDir(string path)
        {
            path = path.Replace("\\", "/");
            path = path.Substring(0, path.LastIndexOf("/"));
            return path;
        }

        public static void CreateDirIfNotExists(string path)
        {
            string dir = getFileDir(path);
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
        }

    }

}

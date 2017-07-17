using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;

namespace UnityHelper
{
    public static class Tools 
    {

        public static void DecompressToDirectory(string targetPath, string zipFilePath)//targetPath是我们解压到哪里，zipFilePath是我们的zip压缩文件目录(包括文件名和后缀)
        {
            if (File.Exists(zipFilePath))
            {
                var compressed = File.OpenRead(zipFilePath);
                compressed.DecompressToDirectory(targetPath);
            }
            else
            {
                Debug.LogError("Zip不存在: " + zipFilePath);
            }
        }

        public static void DecompressToDirectory(this Stream source, string targetPath)//自己写stream的扩展方法，不懂的童鞋自行百度什么是扩展方法
        {
            targetPath = Path.GetFullPath(targetPath);
            using (ZipInputStream decompressor = new ZipInputStream(source))
            {
                ZipEntry entry;

                while ((entry = decompressor.GetNextEntry()) != null)
                {
                    string name = entry.Name;
                    if (entry.IsDirectory && entry.Name.StartsWith("\\"))
                        name = entry.Name.Replace("\\", "");
                    
                    string filePath = Path.Combine(targetPath, name);
                    string directoryPath = Path.GetDirectoryName(filePath);

                    if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                        Directory.CreateDirectory(directoryPath);

                    if (entry.IsDirectory)
                        continue;

                    byte[] data = new byte[2048];
                    using (FileStream streamWriter = File.Create(filePath))
                    {
                        int bytesRead;
                        while ((bytesRead = decompressor.Read(data, 0, data.Length)) > 0)
                        {
                            streamWriter.Write(data, 0, bytesRead);
                        }
                    }
                }
            }
        }

        public static Vector3 ScreenToUiPoint(Vector3 screen)
        {
            Vector3 ui = screen;
            ui.y = Mathf.Abs(screen.y - Screen.height);
            return ui;
        }

        /// <summary>  
        /// 获取游戏对象的大小  
        /// </summary>  
        /// <returns>  
        /// The size.  
        /// </returns>  
      public static Vector3 GetObjectSize(GameObject gameObject)
        {
            Vector3 realSize = Vector3.zero;

            Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
            if (mesh == null)
            {
                return realSize;
            }
            // 它模型网格的大小  
            Vector3 meshSize = mesh.bounds.size;
            // 它的放缩  
            Vector3 scale = gameObject.transform.lossyScale;
            // 它在游戏中的实际大小  
            realSize = new Vector3(meshSize.x * scale.x, meshSize.y * scale.y, meshSize.z * scale.z);
           
            return realSize;
        }

        public static Type GetType(string TypeName)
        {

            // Try Type.GetType() first. This will work with types defined
            // by the Mono runtime, etc.
            var type = Type.GetType(TypeName);

            // If it worked, then we‘re done here
            if (type != null)
                return type;

            // Get the name of the assembly (Assumption is that we are using
            // fully-qualified type names)
            var assemblyName = TypeName.Substring(0, TypeName.IndexOf('.'));

            // Attempt to load the indicated Assembly
            var assembly = Assembly.LoadWithPartialName(assemblyName);
            if (assembly == null)
                return null;

            // Ask that assembly to return the proper Type
            return assembly.GetType(TypeName);
        }
    }
}


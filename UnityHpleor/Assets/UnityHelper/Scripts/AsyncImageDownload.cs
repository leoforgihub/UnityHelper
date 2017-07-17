using UnityEngine;
using System.Collections;
using System.IO;

namespace UnityHelper
{
    public class AsyncImageDownload : MonoBehaviour
    {

        public Texture placeholder;
        public static AsyncImageDownload Instance = null;

        private string path = Application.persistentDataPath + "/ImageCache/";

        //构建单例  
        public static AsyncImageDownload CreateSingleton()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/ImageCache/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/ImageCache/");
            }

            GameObject obj = new GameObject();
            obj.AddComponent<AsyncImageDownload>();

            AsyncImageDownload loader = obj.GetComponent<AsyncImageDownload>();
            Instance = loader;
            loader.placeholder = Resources.Load("placeholder") as Texture;
            return loader;

        }


        public void SetAsyncImage(string url, Texture texture)
        {


            //开始下载图片前，将UITexture的主图片设置为占位图  
            texture = placeholder;

            //判断是否是第一次加载这张图片  

            if (!File.Exists(path + url.GetHashCode()))
            {
                //如果之前不存在缓存文件  


                StartCoroutine(DownloadImage(url, texture));


            }
            else
            {

                StartCoroutine(LoadLocalImage(url, texture));

            }

        }

        IEnumerator DownloadImage(string url, Texture texture)
        {
            Debug.Log("downloading new image:" + path + url.GetHashCode());
            WWW www = new WWW(url);
            yield return www;

            Texture2D image = www.texture;
            //将图片保存至缓存路径  
            byte[] pngData = image.EncodeToPNG();
            File.WriteAllBytes(path + url.GetHashCode(), pngData);

            texture = image;

        }

        IEnumerator LoadLocalImage(string url, Texture texture)
        {
            string filePath = "file:///" + path + url.GetHashCode();

            Debug.Log("getting local image:" + filePath);
            WWW www = new WWW(filePath);
            yield return www;


            //直接贴图  
            texture = www.texture;

        }
    }

}

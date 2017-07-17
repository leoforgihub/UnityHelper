using UnityEngine;
using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;

namespace  UnityHelper
{
    //<summary>
    //HTTP ÍøÂçÁ¬½ÓÆ÷
    //</summary>
    public class HttpUtils : MonoBehaviour
    {

        //public Action<string> onFailure;
        //public Action<ResponseInfo> onSuccess;

        public bool isProtect;

        public static HttpUtils Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject("net", typeof(HttpUtils));
                    instance = obj.GetComponent<HttpUtils>();
                }

                return instance;
            }
        }

        private static HttpUtils instance;

        public void send(string url, HttpRequest r, RequestCallBack callback)
        {
            StartCoroutine(request(url, r, callback));
        }

        public void send(string url, RequestCallBack callback)
        {
            StartCoroutine(request(url, callback));
        }

        public void send(string url, WWWForm form, RequestCallBack callback)
        {
            StartCoroutine(request(url, form, callback));
        }

        private IEnumerator getProgress(WWW www, RequestCallBack callback)
        {
            while (!www.isDone)
            {

                int p = ((int)(www.progress * 100)) % 100;

                if (callback.onProgress != null)
                    callback.onProgress(p);

                yield return 1;
            }

        }

        public IEnumerator request(string url, RequestCallBack callback)
        {
            WWW www = new WWW(url);

            if (callback.onBegin != null)
                callback.onBegin(www);

            yield return StartCoroutine(getProgress(www, callback));

            if (www.error != null)
            {
                if (callback.onFailure != null)
                    callback.onFailure(www.error);

                if (www.isDone && callback.onEnd != null)
                    callback.onEnd(false);
            }
            else
            {
                ResponseInfo info = new ResponseInfo();

                info.result = www.text;
                info.texture = www.texture;
                info.data = www.bytes;

                if (callback.onSuccess != null)
                    callback.onSuccess(info);

                if (www.isDone && callback.onEnd != null)
                    callback.onEnd(true);
            }


        }

        public IEnumerator request(string url, WWWForm form, RequestCallBack callback)
        {
            WWW www = new WWW(url, form);

            if (callback.onBegin != null)
                callback.onBegin(www);

            yield return StartCoroutine(getProgress(www, callback));

            if (www.error != null)
            {
                if (callback.onFailure != null)
                    callback.onFailure(www.error);


                if (www.isDone && callback.onEnd != null)
                    callback.onEnd(false);
            }
            else
            {
                ResponseInfo info = new ResponseInfo();

                info.result = www.text;
                info.texture = www.texture;
                info.data = www.bytes;

                if (callback.onSuccess != null)
                    callback.onSuccess(info);

                if (www.isDone && callback.onEnd != null)
                    callback.onEnd(true);
            }

        }

        public IEnumerator request(string url, HttpRequest request, RequestCallBack callback)
        {
            WWW www;

            if (request.method == HttpRequest.HttpMethod.GET)
            {
                www = new WWW(url, null, request.headers);
                request.www = www;
            }
            else
            {
                www = new WWW(url, request.rewData, request.headers);
                request.www = www;
            }

            if (callback.onBegin != null)
                callback.onBegin(www);

            yield return StartCoroutine(getProgress(www, callback));

            if (www.error != null)
            {
                if (callback.onFailure != null)
                    callback.onFailure(www.error);

                if (www.isDone && callback.onEnd != null)
                    callback.onEnd(false);
            }
            else
            {
                ResponseInfo info = new ResponseInfo();

                info.result = www.text;
                info.texture = www.texture;
                info.data = www.bytes;

                if (callback.onSuccess != null)
                    callback.onSuccess(info);

                if (www.isDone && callback.onEnd != null)
                    callback.onEnd(true);
            }


        }

        public class HttpRequest
        {
            public enum HttpMethod
            {
                GET, POST
            }

            public HttpMethod method;

            public byte[] rewData;

            public WWW www;

            public Dictionary<String, String> headers;

            public long timeout
            {
                set
                {
                    timeout = value;

                }
            }

            public HttpRequest()
            {
                headers = new Dictionary<string, string>();
            }

            public static HttpRequest getDefaultHttpRequest()
            {
                HttpRequest instance = new HttpRequest();

                instance.method = HttpMethod.GET;

                string value = PlayerPrefs.GetString("token");

                instance.setHeader("Authorization", value);

                return instance;
            }

            public void setHeader(string key, string value)
            {
                headers[key] = value;
            }

            public void setStringData(string data)
            {
                rewData = Encoding.UTF8.GetBytes(data);
            }

            public void setIntData(int data)
            {
                rewData = Encoding.UTF8.GetBytes("" + data);
            }

        }

        public class RequestCallBack
        {
            public Action<ResponseInfo> onSuccess;
            public Action<string> onFailure;
            public Action<int> onProgress;

            public Action<WWW> onBegin;
            public Action<bool> onEnd;

            public RequestCallBack()
            {
                onFailure += OnFailure;
                onSuccess += OnSuccess;
            }

            private void OnFailure(string msg)
            {
                Debug.Log("OnFailure = " + msg);
            }

            private void OnSuccess(ResponseInfo info)
            {
                Debug.Log("OnSuccess = " + info.result);
            }

            //public abstract void onSuccess(ResponseInfo responseInfo);

            //public abstract void onFailure(string msg);

            //public void onProgress(int progress)
            //{
            //    //Debug.Log("progress=" + progress);
            //}
            //public void onBegin(WWW www)
            //{

            //}
            //public void onEnd()
            //{

            //}
        }

        public class ResponseInfo
        {
            public string result;
            public Texture2D texture;
            public byte[] data;

        }

        public void Update()
        {

        }
    }
}


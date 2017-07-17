using UnityEngine;
using System.Collections;

namespace  UnityHelper
{
    //<summary>
    //多媒体管理器
    //</summary>
    public class AudioManager : MonoBehaviour
    {

        private static AudioManager instance = null;

        private AudioSource audioMgr;

        private AudioClip ac;

        private string curMusicName = "";

        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject("Sound", typeof(AudioManager));

                    DontDestroyOnLoad(obj);
                }

                return instance;
            }
        }

        void Awake()
        {

            instance = this;

            audioMgr = this.gameObject.AddComponent<AudioSource>();

            this.gameObject.AddComponent<AudioListener>();

            //if (instance != null && instance != this)
            //{
            //    Destroy(this.gameObject);
            //}
            //else
            //{
            //    instance = this;
            //    this.gameObject.AddComponent<AudioListener>();
            //}

            //DontDestroyOnLoad(this.gameObject);
        }

        public void Play(string fileName)
        {
            if (!fileName.Equals(curMusicName))
            {
                ac = Resources.Load(fileName) as AudioClip;
                audioMgr.clip = ac;
                audioMgr.Play();
                curMusicName = fileName;
            }
        }

        public void Stop()
        {
            audioMgr.Stop();
            curMusicName = "";
            Debug.Log("Stop background music");
        }

        public void Loop(bool b)
        {
            audioMgr.loop = b;
        }

        public void RePlay()
        {
            audioMgr.Play();
        }

        public void Pause()
        {
            audioMgr.Pause();
        }
    }

}

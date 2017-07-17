using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace  UnityHelper
{
    //<summary>
    //消息分发器
    //<summary>
    public class MessageHandler
    {

        public delegate void OneMessage();

        public delegate void TwoMessage(object sender);

        private Dictionary<string, OneMessage> one_event_group;

        private Dictionary<string, TwoMessage> two_event_group;

        private static MessageHandler instance;

        public static MessageHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageHandler();
                }
                return instance;
            }
        }

        //<summary>
        //定制消息
        //</summary>
        public void BuildMessage(string functionName, OneMessage msg)
        {
            if (one_event_group == null)
            {
                one_event_group = new Dictionary<string, OneMessage>();
            }

            if (one_event_group.ContainsKey(functionName))
            {
                one_event_group[functionName] += msg;
            }
            else
            {
                one_event_group.Add(functionName, msg);
            }
        }

        public void BuildMessage(string functionName, TwoMessage msg)
        {
            if (two_event_group == null)
            {
                two_event_group = new Dictionary<string, TwoMessage>();
            }

            if (two_event_group.ContainsKey(functionName))
            {
                two_event_group[functionName] += msg;
            }
            else
            {
                two_event_group.Add(functionName, msg);
            }
        }
        //    //<summer>
        //    //订阅
        //    //</summer>
        //    public void RigisterObserver(string functionName,OneMessage msg)
        //    {
        //        //if(one_event_group.ContainsKey(functionName))
        //    }

        public void LogoutMessage(string func)
        {
            if (one_event_group.ContainsKey(func))
            {
                one_event_group.Remove(func);
            }
        }
        public void LogoutObserver(string func, OneMessage msg)
        {
            if (one_event_group.ContainsKey(func))
            {
                one_event_group[func] -= msg;
            }
        }
        //<summer>
        //执行
        //</summer>
        public void Execute(string func)
        {
            if (one_event_group != null)
            {
                if (one_event_group.ContainsKey(func))
                {
                    if (one_event_group[func] != null)
                        one_event_group[func].Invoke();
                }
            }

        }

        public void Execute(string func, object sender)
        {
            if (two_event_group != null)
            {
                if (two_event_group.ContainsKey(func))
                {
                    two_event_group[func].Invoke(sender);
                }
            }
        }


    }
}


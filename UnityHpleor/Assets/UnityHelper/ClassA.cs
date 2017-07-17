using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityHelper;

namespace Assets
{
    class ClassA
    {
        public ClassA()
        {
            MessageHandler.Instance.BuildMessage("Myfunction", Myfunc);
          
        }

        public void Myfunc()
        {
            Debug.Log("Myfunc");
            MessageHandler.Instance.LogoutObserver("Myfunction", Myfunc);
        }
    }
}

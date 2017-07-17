using UnityEngine;
using System.Collections;

namespace UnityHelper
{
    //GameObject 工厂
    public class GameObjectCreator
    {

        public static GameObject CopyGameObject(GameObject from)
        {
            GameObject newObj = GameObject.Instantiate(from);

            newObj.transform.Reset();

            return newObj;
        }

        public static GameObject CreateChild(GameObject parent)
        {
            GameObject newObj = GameObject.Instantiate(parent);

            newObj.transform.parent = parent.transform;

            newObj.transform.ResetLocal();

            return newObj;
        }

        public static GameObject CreateChild(GameObject parent, GameObject child)
        {
            GameObject newObj = GameObject.Instantiate(child);

            newObj.transform.parent = parent.transform;

            newObj.transform.ResetLocal();

            return newObj;
        }


    }

}


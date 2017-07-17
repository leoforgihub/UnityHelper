using UnityEngine;
using System.Collections;

namespace  UnityHelper
{
    //C#3.0新加入一个特性，就是通过this关键字动态的向某个类注入静态函数
    public static class ExtraTransform
    {

        public static void SetX(this Transform transform, float x)
        {
            Vector3 newPosition =
                new Vector3(x, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }

        public static void SetY(this Transform transform, float y)
        {
            Vector3 newPosition =
                new Vector3(transform.position.x, y, transform.position.z);
            transform.position = newPosition;
        }

        public static void SetZ(this Transform transform, float z)
        {
            Vector3 newPosition =
                new Vector3(transform.position.x, transform.position.y, z);
            transform.position = newPosition;
        }

        public static float GetX(this Transform transform)
        {
            return transform.position.x;
        }

        public static float GetY(this Transform transform)
        {
            return transform.position.y;
        }

        public static float GetZ(this Transform transform)
        {
            return transform.position.z;
        }

        public static void Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static void ResetLocal(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }


    }
}

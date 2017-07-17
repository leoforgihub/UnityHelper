using UnityEngine;
using System.Collections;

namespace  UnityHelper
{

    //碰撞工具类 AABB包围盒算法
    public static class CollisionTools
    {

        //AABB包围盒算法,2D 碰撞检查
        public static bool AABB2D(Rect box, Rect rect)
        {
            if (CollisionTools.isContain(box, rect.x, rect.y) || //第一个点是否进入包围盒
                CollisionTools.isContain(box, rect.x + rect.width, rect.y) || //第二个点是否进入包围盒
                CollisionTools.isContain(box, rect.x, rect.y + rect.height) || //第三个点是否进入包围盒
                CollisionTools.isContain(box, rect.x + rect.width, rect.y + rect.height)//第四个点是否进入包围盒
                )
            {
                return true;
            }
            else
            {

                return false;
            }

        }

        //AABB包围盒算法3D 碰撞检查
        public static bool AABB3D(Transform box, Vector3 point)
        {
            //        float minX = box.position.x;
            //        float minY = box.position.y;
            //        float minZ = box.position.z;

            Vector3 min = box.position - (box.localScale / 2);
            Vector3 max = box.position + (box.localScale / 2);

            //        if (point.x > min.x && point.x < max.x &&
            //            point.y > min.y && point.y < max.y &&
            //            point.z > min.z && point.z < max.z
            //            )
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }

            if (point.more(min) && point.less(max))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool more(this Vector3 vt1, Vector3 vt2)
        {
            if (vt1.x > vt2.x && vt1.y > vt2.y && vt1.z > vt2.z)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool less(this Vector3 vt1, Vector3 vt2)
        {
            if (vt1.x < vt2.x && vt1.y < vt2.y && vt1.z < vt2.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isContain(Rect rect, float x, float y)
        {

            if (x > rect.xMin && x < rect.xMax && y > rect.yMin && y < rect.yMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}


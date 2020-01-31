using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public static class ChaniscoLib{
    
        /// <summary>
        /// A mini shuffle that 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iList"></param>
        public static void Shuffle<T>(this List<T> iList) {
            int n = iList.Count;
            while (n > 1) {
                n--;
                int k = Random.Range(n,1);
                T value = iList[k];
                iList[k] = iList[n];
                iList[n] = value;
            }
        }

        /// <summary>
        /// Shuffle a target list...but then HARD >: P
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iList"></param>
        public static void HeavyShuffle<T>(this List<T> iList) {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = iList.Count;
            while (n > 1) {
                byte[] box = new byte[1];
                do
                    provider.GetBytes(box);
                while (!(box[0] < n * (byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = iList[k];
                iList[k] = iList[n];
                iList[n] = value;
            }
        }

    public static void DeleteCopies<T>(this List<T> iList) {
        int i = 0;
        int j = 0;
        while (i < iList.Count) {
            while(j < iList.Count) {
                if ((object)iList[i] == (object)iList[j]) {
                    if (i != j) {
                        iList.RemoveAt(j);
                    }
                }
                j++;
            }
            i++;
        }
    }


    public static float pixelOffSet;
    /// <summary>
    /// Function that returns the List but with its values backwards
    /// </summary>
    /// <param name="targetList">targetList you want to be set backwards</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>The inserted list but with its values backwards</returns>
    public static List<T> BackwardList<T>(this List<T> targetList)
    {
        int n = targetList.Count;
        List<T> temp = new List<T>();

        while (n > 0)
        {
            n--;
            temp.Add(targetList[n]);

        }

        return temp;
    }

    public static float cameraDistance(Camera targetCamera,Vector3 Pos1) {
        Vector3 p = targetCamera.ScreenToWorldPoint(Pos1);
        return p.x-(targetCamera.pixelWidth - targetCamera.transform.position.x);
    }

    public static void CheckPixelDifference(Camera targetCamera) {
        Vector3 p1 = targetCamera.WorldToScreenPoint(new Vector3(0,0,0));
        Vector3 p2 = targetCamera.WorldToScreenPoint(new Vector3(1,0,0));
        pixelOffSet = 1 / (p2.x - p1.x);
    }


    public static SpriteRenderer CreateDuplicatedSpriteRenderer(SpriteRenderer originalSpriteRenderer) {
        SpriteRenderer result = new GameObject("temporaryDuplicatedSpriteRenderer").AddComponent<SpriteRenderer>();
        result.transform.position = originalSpriteRenderer.transform.position;
        result.transform.rotation = originalSpriteRenderer.transform.rotation;
        result.transform.localScale = originalSpriteRenderer.transform.localScale;

        result.sprite = originalSpriteRenderer.sprite;
        result.color = originalSpriteRenderer.color;
        result.hideFlags = originalSpriteRenderer.hideFlags;
        result.sortingLayerID = originalSpriteRenderer.sortingLayerID;
        result.sortingOrder = originalSpriteRenderer.sortingOrder;
        return result;
    }

}

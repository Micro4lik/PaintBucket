using System;
using System.Collections.Generic;
using UnityEngine;

public class NewBucket : MonoBehaviour  // TODO: generate random bucket type, remove bucket from list, remove all buckets of the same type
{
    private static List<NewBucket> buckets; // Holds a refernces to all active buckets
    private static GameObject initGameObject; // Global gameobjects used for initializing class, is destoyed on scene change

    private static void InitIfNeeded()
    {
        if (initGameObject == null)
        {
            initGameObject = new GameObject("BucketsInit");
            buckets = new List<NewBucket>();
        }
    }

    public static NewBucket Create(Cell cell, Color32 paintColor, string bucketName = null)
    {
        InitIfNeeded();

        GameObject gameObject = new GameObject("Bucket" + bucketName, typeof(BucketBase));
        NewBucket bucket = new NewBucket(cell, paintColor, gameObject);

        buckets.Add(bucket);

        return bucket;
    }

    public static NewBucketHorizontal CreateBucketHorizontal(GameObject _obj, Cell _cell, Color32 _paintColor, string _bucketName = null)
    {
        NewBucketHorizontal copy = _obj.AddComponent<NewBucketHorizontal>();

        copy.bucketName = _bucketName;
        copy.cell = _cell;
        copy.paintColor = _paintColor;

        //buckets.Add(bucket);

        return copy;
    }


    // Dummy class to have access to MonoBehaviour functions
    public class BucketBase : MonoBehaviour
    {
        /*public virtual void OnPress()
        {
        }*/
    }

    public Cell cell = null;
    public Color32 paintColor;
    private string bucketName;
    private GameObject gameObject;

    public NewBucket(Cell _cell, Color32 _paintColor, GameObject _gameObject, string _bucketName = null)
    {
        cell = _cell;
        paintColor = _paintColor;
        bucketName = _bucketName;
        gameObject = _gameObject;
    }

    /*public void GenerateBucket(GameObject gameObject, List<Bucket> list)
    {
        int min = 0, max = 1000;
        System.Random random = new System.Random();
        int ranNum = random.Next(min, max);

        //randomManager.RandomList(list).AddToGameObject(gameObject);
        RandomList(list).AddToGameObject(gameObject);
    }


    public Bucket RandomList(List<Bucket> list)
    {
        System.Random random = new System.Random();
        return list[random.Next(list.Count)];
    }*/

    public void Update()
    {

    }

}

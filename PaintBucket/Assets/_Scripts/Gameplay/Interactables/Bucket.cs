﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Bucket  // TODO: generate random bucket type, remove bucket from list, remove all buckets of the same type
{
    private static Bucket bucket;

    public enum BucketType
    {
        Horizontal = 0,
        Vertical = 1,
        Random = 2,
    }

    public static Bucket Create(BucketType bucketType, Cell cell, Color32 paintColor, string bucketName = null)
    {
        switch (bucketType)
        {
            case BucketType.Horizontal:

                bucket = new BucketHorizontal(cell, paintColor);
                bucket.bucketName = bucketName;
                bucket.cell = cell;
                bucket.paintColor = paintColor;

                break;
            case BucketType.Vertical:
                break;
            case BucketType.Random:
                break;
            default:
                break;
        }

        return bucket;
    }

    /*public BucketHorizontal CreateBucketHorizontal(GameObject _obj, Cell _cell, Color32 _paintColor, string _bucketName = null)
    {
        bucketType = BucketType.Horizontal;

        //BucketHorizontal copy = _obj.AddComponent<BucketHorizontal>();

        //copy.bucketName = _bucketName;
        //copy.cell = _cell;
        //copy.paintColor = _paintColor;

        //buckets.Add(bucket);

        //return copy;
    }*/


    public class BucketBase : MonoBehaviour
    {
        /*public virtual void OnPress()
        {
        }*/
    }

    public virtual void OnPress()
    {
    }

    private BucketType bucketType;

    public Cell cell = null;
    public Color32 paintColor;
    public string bucketName;

    public Bucket(Cell _cell, Color32 _paintColor, string _bucketName = null, BucketType _bucketType = BucketType.Random)
    {
        bucketType = _bucketType;
        cell = _cell;
        paintColor = _paintColor;
        bucketName = _bucketName;
    }

}

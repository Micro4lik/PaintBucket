using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBucketHorizontal : NewBucket
{
    public NewBucketHorizontal(Cell cell, Color32 paintColor, GameObject gameObject) : base(cell, paintColor, gameObject)
    {

    }

    //public Cell cell = null;
    //public Color32 paintColor;

    public virtual void OnPress()
    {
    }
}

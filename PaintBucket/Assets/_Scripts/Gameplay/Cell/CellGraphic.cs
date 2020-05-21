using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellGraphic :  SerializedMonoBehaviour, IPaintable
{
    [SerializeField]
    private Image _cellImage;



    public void SetStyle(CellGraphicStyle cellGraphicStyle, int colorId)
    {

    }

    public void SetColor (Color32 _color)
    {
        _cellImage.color = _color;
    }
}

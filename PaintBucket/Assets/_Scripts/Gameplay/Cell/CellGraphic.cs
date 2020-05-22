using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellGraphic :  SerializedMonoBehaviour
{
    [SerializeField]
    public Button button;

    [SerializeField]
    private Image _cellImage;
    [SerializeField]
    private Cell _cell;




    public void SetColor (Color32 _color)
    {
        _cellImage.color = _color;
    }
}

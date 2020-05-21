using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPaintable
{
    void SetStyle(CellGraphicStyle cellGraphicStyle, int colorId);
}

public enum CellGraphicStyle
{
    Clean,
    Painted,

}

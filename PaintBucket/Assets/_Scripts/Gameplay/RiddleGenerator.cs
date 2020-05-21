using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleGenerator : Singleton<RiddleGenerator>
{
    [SerializeField]
    private GameObject _emptyCell;

    [SerializeField]
    private GridLayoutGroup _riddleGrid;

    public Dictionary<int, Color32> ColorPalette = new Dictionary<int, Color32>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateColors(5);
        CreateEmptyBase(new Vector2Int(5, 5));
    }

    private void GenerateColors(int colorsAmount=3)
    {
        var baseColor = UnityEngine.Random.ColorHSV(0,1,0.5f,1f,1f,1f,1f,1f);
        Color.RGBToHSV(baseColor, out float baseH, out float baseS, out float baseV);
        for (int i = 0; i < colorsAmount; i++)
        {
            var covertedColor = Color.HSVToRGB((baseH + ((float)i)/colorsAmount) %1f, baseS, baseV);
            ColorPalette.Add(i, new Color32((byte)(covertedColor.r * 255), (byte)(covertedColor.g * 255), (byte)(covertedColor.b * 255), 255));
            Debug.Log($"Generated H {baseH + i / colorsAmount}");
            Debug.Log($"Generated Color {covertedColor}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEmptyBase(Vector2Int size)
    {
        for (int i = 0; i < size.x*size.y; i++)
        {
            var _tile = Instantiate(_emptyCell, _riddleGrid.transform);
            var _cellGraphic = _tile.GetComponentInChildren<CellGraphic>();
            _cellGraphic.SetColor(ColorPalette[UnityEngine.Random.Range(0, ColorPalette.Count)]);
            
        }
    }
}

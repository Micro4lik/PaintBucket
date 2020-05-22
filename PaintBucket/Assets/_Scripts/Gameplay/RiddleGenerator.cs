using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;



public class RiddleGenerator : Singleton<RiddleGenerator>
{
    [SerializeField]
    private GameObject _emptyCell;

    [SerializeField]
    private GridLayoutGroup _riddleGrid;
    [SerializeField]
    private List<Bucket> _bucketsLibrary = new List<Bucket>();

    public Dictionary<int, Color32> ColorPalette = new Dictionary<int, Color32>();

    public UnityAction<RiddleInfo> onRiddleGenerated;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void GenerateRiddle()
    {
        GenerateColors(5);
        var riddle = CreateEmptyBase(new Vector2Int(5, 5));
        PopulateBaseWithBuckets(riddle);
        onRiddleGenerated(riddle);
    }


    private void GenerateColors(int colorsAmount = 3)
    {
        var baseColor = UnityEngine.Random.ColorHSV(0, 1, 0.5f, 1f, 1f, 1f, 1f, 1f);
        Color.RGBToHSV(baseColor, out float baseH, out float baseS, out float baseV);
        for (int i = 0; i < colorsAmount; i++)
        {
            var covertedColor = Color.HSVToRGB((baseH + ((float)i) / colorsAmount) % 1f, baseS, baseV);
            ColorPalette.Add(i, new Color32((byte)(covertedColor.r * 255), (byte)(covertedColor.g * 255), (byte)(covertedColor.b * 255), 255));
            Debug.Log($"Generated H {baseH + i / colorsAmount}");
            Debug.Log($"Generated Color {covertedColor}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public RiddleInfo CreateEmptyBase(Vector2Int size)
    {
        var _riddle = new RiddleInfo();
        _riddle.riddleBounds = size;

        for (int i = 0; i < size.y; i++)
        {
            for (int j = 0; j < size.x; j++)
            {
                var _tile = Instantiate(_emptyCell, _riddleGrid.transform);
                var _cell = _tile.GetComponentInChildren<Cell>();
                _cell.coordinates = new Vector2Int(j, i);
                _tile.name = $"Cell {j}x{i}";
                var _cellGraphic = _tile.GetComponentInChildren<CellGraphic>();
                _riddle.riddleCells.Add(_cell);
            }
        }
        return _riddle;
    }

    //Bucket bak;
    public GameObject test;
    private void PopulateBaseWithBuckets(RiddleInfo riddle)
    {
        /*var randomCell = riddle.riddleCells[Random.Range(0, riddle.riddleCells.Count)];
        var _bucket = _bucketsLibrary[Random.Range(0, _bucketsLibrary.Count)];
        _bucket.paintColor = ColorPalette[Random.Range(0, ColorPalette.Count)];
        randomCell.SetInteractable(_bucket);*/

        /*for (int i = 0; i < 3; i++) // just genarate bucket of horizontal type, work fine
        {
            var randomCell = riddle.riddleCells[Random.Range(0, riddle.riddleCells.Count)];
            var _bucket = gameObject.AddComponent(typeof(BucketHorizontal)) as Bucket;
            _bucket.paintColor = ColorPalette[Random.Range(0, ColorPalette.Count)];
            randomCell.SetInteractable(_bucket);
        }*/

        for (int i = 0; i < 3; i++)
        {
            var randomCell = riddle.riddleCells[Random.Range(0, riddle.riddleCells.Count)];
            var randomColor = ColorPalette[Random.Range(0, ColorPalette.Count)];

            //NewBucket.Create(randomCell, ColorPalette[Random.Range(0, ColorPalette.Count)], "FirstBucket");
            NewBucket.CreateBucketHorizontal(gameObject, randomCell, randomColor, "HorizontalBucket"); // TODO: change horizontal bucket to bucket

            //randomCell.SetInteractable(_bucket);
        }

    }

}

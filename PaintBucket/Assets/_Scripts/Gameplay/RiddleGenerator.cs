using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleGenerator : Singleton<RiddleGenerator>
{
    [SerializeField]
    private GameObject EmptyTile;

    [SerializeField]
    private GridLayout riddleGrid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEmptyBase(Vector2Int size)
    {
        for (int i = 0; i < size.x*size.y; i++)
        {
            var tile = Instantiate(EmptyTile, riddleGrid.transform);
            
        }
    }
}

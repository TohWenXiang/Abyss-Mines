using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Map Data")]
    public Vector2Int mapSize;
    public int seed;

    [Header("Map Initialization")]
    [Range(0, 100)]
    public int percentageFill;
    private System.Random prng;

    [Header("Cellular Automata Controls")]
    [Range(0, 10)]
    public int simulationSteps;
    [Range(1, 8)]
    public int creationLimit;
    [Range(1, 8)]
    public int destructionLimit;

    [Header("Map Generator Controls")]
    public bool autoUpdate;
    public MapData theMapData;

    public void GenerateMap()
    {
        theMapData.size = mapSize;
        theMapData.seed = seed;

        //initialize stuff
        prng = new System.Random(theMapData.seed);
        theMapData.cells = new bool[theMapData.size.x, theMapData.size.y];

        //generate a randomly filled map with the edges filled in
        for (int x = 0; x < theMapData.size.x; x++)
        {
            for (int y = 0; y < theMapData.size.y; y++)
            {
                if (x == 0 || y == 0 || x == (theMapData.size.x - 1) || y == (theMapData.size.y - 1))
                {
                    theMapData.cells[x, y] = true;
                }
                else
                {
                    if (prng.Next(0, 100) < percentageFill)
                    {
                        theMapData.cells[x, y] = true;
                    }
                    else
                    {
                        theMapData.cells[x, y] = false;
                    }
                }
            }
        }
    }

    public void OnValidate()
    {
        if (mapSize.x < 1)
        {
            mapSize.x = 1;
        }
        if (mapSize.y < 1)
        {
            mapSize.y = 1;
        }
        if (simulationSteps < 0)
        {
            simulationSteps = 0;
        }
    }
}

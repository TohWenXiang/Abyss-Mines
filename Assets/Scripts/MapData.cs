using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "Abyss-Mines/Map")]
public class MapData : ScriptableObject
{
    public Vector2Int size;
    public int seed;
    public bool[,] cells;

    public List<Vector2Int> FindNeighbour(Vector2Int currentCellIndex)
    {
        List<Vector2Int> neighbours = new List<Vector2Int>();

        //search through a three by three area around the current cell index
        for (int a = -1; a < 2; a++)
        {
            for (int b = -1; b < 2; b++)
            {
                //calculate neighbour index that we are visiting
                Vector2Int neighbourIndex = new Vector2Int(currentCellIndex.x + a, currentCellIndex.y + b);

                //we are visiting the current cell, so do nothing
                if (a == 0 && b == 0)
                {
                    continue;
                }
                //if the neighbour we are visiting is within the map, add it to the list.
                else if (neighbourIndex.x >= 0 && neighbourIndex.x < size.x && neighbourIndex.y >= 0 && neighbourIndex.y < size.y)
                {
                    neighbours.Add(neighbourIndex);
                }
                //otherwise wrap around the neighbour's index
                else
                {
                    neighbours.Add(WrapAroundIndex(neighbourIndex, size));
                }
            }
        }

        return neighbours;
    }

    public List<Vector2Int> FindNeighbouringWalls(Vector2Int currentCellIndex)
    {
        List<Vector2Int> neighbouringWalls = new List<Vector2Int>();

        //get all the neighbouring cells
        List<Vector2Int> neighbours = FindNeighbour(currentCellIndex);

        //search through them for walls
        for (int i = 0; i < neighbours.Count; i++)
        {
            if (cells[neighbours[i].x, neighbours[i].y] == true)
            {
                neighbouringWalls.Add(neighbours[i]);
            }
        }

        return neighbouringWalls;
    }

    public int GetNeighbouringWallCount(Vector2Int currentCellIndex)
    {
        return FindNeighbouringWalls(currentCellIndex).Count;
    }

    public Vector2Int WrapAroundIndex(Vector2Int index, Vector2Int size)
    {
        return new Vector2Int(WrapAround(index.x, size.x), WrapAround(index.y, size.y));
    }

    public int WrapAround(int index, int size)
    {
        while (index < 0)
        {
            index += size;
        }

        return index % size;
    }
}

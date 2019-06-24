using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public MapData theMap;
    public Color defaultColor;
    public Color wallColor;
    public Color selectedCellColor;
    public Color selectedNeighbouringCellDefaultColor;
    public Color selectedNeighbouringWallColor;

    private void OnDrawGizmos()
    {
        if (theMap.cells != null)
        {
            for (int x = 0; x < theMap.size.x; x++)
            {
                for (int y = 0; y < theMap.size.y; y++)
                {
                    if (theMap.cells[x, y] == true)
                    {
                        Gizmos.color = wallColor;
                    }
                    else if (theMap.cells[x, y] == false)
                    {
                        Gizmos.color = defaultColor;
                    }

                    Vector3 pos = new Vector3(-(theMap.size.x * 0.5f) + x + 0.5f, 0, -(theMap.size.y * 0.5f) + y + 0.5f);

                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}

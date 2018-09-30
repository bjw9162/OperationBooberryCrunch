using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalUtilityScripts  {

    public static int CoordToIndex(int x, int y, int w)
    {
        return (y * w) + x;
    }

    public static Vector2 IndexToCoord(int i, int w)
    {
        return new Vector2(i % w, i / w);
    }

    public static Vector2 PosToCoord(Vector2 p, float tileW, float tileH)
    {
        Vector2 coord = Vector2.zero;
        coord.x = (p.x / tileW);
        coord.y = (p.y / tileH);
        return coord;
    }

    public static int PosToIndex(Vector2 p, float tileW, float tileH, int gridW)
    {
        Vector2 coord = PosToCoord(p, tileW, tileH);
        return CoordToIndex((int)coord.x, (int)coord.y, gridW);
    }
}

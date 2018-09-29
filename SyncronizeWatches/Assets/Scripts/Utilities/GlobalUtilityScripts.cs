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
}

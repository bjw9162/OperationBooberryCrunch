using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public enum TileType
    {
        VOID,
        FLOOR,
        WALL,
        PLAYERSPAWN,
        ENEMYSPAWN
    }

    private int xPos;
    public int XPos { get { return xPos; } set { xPos = value; } }

    private int yPos;
    public int YPos { get { return yPos; } set { yPos = value; } }

    public TileType type;
    public bool passable = true;
    public SpriteRenderer image;
    public bool init = false;
}

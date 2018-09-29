﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    private int xPos;
    public int XPos { get { return xPos; } set { xPos = value; } }

    private int yPos;
    public int YPos { get { return yPos; } set { yPos = value; } }

    public bool passable = true;
    public Sprite image;
    public bool init = false;
}

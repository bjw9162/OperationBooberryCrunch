using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPiece : MonoBehaviour {

    [SerializeField]
    private int width;
    public int Width { get { return width; } }

    [SerializeField]
    private int height;
    public int Height { get { return height; } }

    public List<TileScript> grid = new List<TileScript>();
    public List<GamePiece> objects = new List<GamePiece>();
}

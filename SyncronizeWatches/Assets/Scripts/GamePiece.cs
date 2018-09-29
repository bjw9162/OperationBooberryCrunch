using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour {

    private Vector3 position;
    public Vector3 Position { get { return position; } set { position = value; } }

    Sprite sprite;

    private string state;
    public string State { get { return state;} set { state = value; } }

    private Vector3 velocity;
    public Vector3 Velocity { get { return velocity; } set { velocity = value; } }

    public bool stationary;
    public bool canRotate;

    public string pieceName;

	// Use this for initialization
	void Start () {
        Position = Vector3.zero;
        Velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

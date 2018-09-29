using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : GamePiece {

    public List<Interactable> interactables;
    public List<Collectable> inventory;
    
    public float moneyAmount; // make sure you round the money amount up two places after decimal

    public string classType;
    public string subClassType;

    public float speed;
    public Vector3 direction;

	// Use this for initialization
	void Start () {
        moneyAmount = 0f;
        direction = Vector3.right;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Collect(Collectable collectable) {
        collectable.SetStateCollected();
        // collectable.moneyValue; // add value to the money pool 
    }
}

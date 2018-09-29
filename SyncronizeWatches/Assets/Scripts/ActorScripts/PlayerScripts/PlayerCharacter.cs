using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Root class for all characters, Theif, Hacker, etc.
/// </summary>
public class PlayerCharacter : ActorBase {

    public List<Interactable> interactables;
    
    public float moneyAmount; // make sure you round the money amount up two places after decimal

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
